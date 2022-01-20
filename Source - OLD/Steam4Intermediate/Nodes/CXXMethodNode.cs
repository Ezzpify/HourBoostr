using System;
using System.Xml;
using Steam4Intermediate.NodeBehavior;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace Steam4Intermediate.Nodes
{
    class CXXMethodNode : LinkBehavior
    {
        public CXXMethodNode(XmlAttributeCollection collection)
            : base(collection)
        {

        }

        public override void EmitCode(Generator generator, int depth, int ident)
        {
            bool genericwrapper = false, returnbystack = false, returnbystack_special = false;
            int sidarg_count = 0;
            List<int> maskedparams = new List<int>();



            INode returntype;
            bool constness, pointer;

            string returns_base = base.ResolveType( 0, out returntype, out constness, out pointer );

            Debug.Assert(returns_base != null);

            if ( returns_base == null )
            {
                returns_base = "(null)";
            }

            string returns = returns_base;

            if ( pointer )
            {
                if ((returntype is RecordNode && returntype.GetAttribute("kind") == "class" && returntype.GetName().StartsWith("I") ) ||
                        (returntype is FundamentalTypeNode && returns == "void"))
                {
                    genericwrapper = true;
                    returns = "IntPtr";
                }
            }
            else if ( returntype is RecordNode )
            {
                returnbystack = true;
                if (returntype.GetName() == "CSteamID" || returntype.GetName() == "CGameID")
                {
                    returnbystack_special = true;
                }
            }

            returns = generator.ResolveType( returns, constness, pointer, true, false );

            /*if (returns == "UInt64" || returns == "Int64")
            {
                returnbystack = true;
            }
            */

            List<INode> args = new List<INode>();

            foreach( INode child in children )
            {
                if ( child is ParmVarNode )
                {
                    args.Add( child );
                }
            }

            List<string> arg = new List<string>();
            List<string> arg_native = new List<string>();
            List<string> arg_native_pure = new List<string>();

            arg_native.Add( "IntPtr thisptr" );

            if (returnbystack)
            {
                if (returnbystack_special)
                    arg_native.Add("ref UInt64 retarg");
                else
                    arg_native.Add("ref " + returns + " retarg");
            }

            bool prevarg_sb = false;

            for (int i = 0; i < args.Count; i++)
            {
                INode argtype;
                bool argconst, argpointer;

                string argname = args[i].GetName();

                string argtypes = args[i].ResolveType(0, out argtype, out argconst, out argpointer);

                Debug.Assert(argtypes != null);

                argtypes = generator.ResolveType(argtypes, argconst, argpointer, false, true);


                if ( argtypes == "StringBuilder" || argtypes == "Byte[]" )
                {
                    prevarg_sb = true;
                }
                else if ((argtypes == "Int32" || argtypes == "UInt32")
                    && prevarg_sb
                    && (argname.StartsWith("c") || argname.StartsWith("u") || argname.StartsWith("i") )
                    )
                {
                    maskedparams.Add(i);

                    prevarg_sb = false;
                }
                else
                {
                    prevarg_sb = false;
                }

                if ( genericwrapper && argtypes == "string" )
                {
                    maskedparams.Add( i );
                }

                if ( String.IsNullOrEmpty( argname ) )
                {
                    argname = "arg" + i;
                }

                if ( !maskedparams.Contains( i ) )
                    arg.Add( argtypes + " " + argname );

                arg_native_pure.Add(argtypes);

                if (argtypes.Contains("CSteamID") || argtypes.Contains("CGameID"))
                {
                    argtypes = argtypes.Replace("CSteamID", "UInt64").Replace("CGameID", "UInt64");

                    if(argtypes.StartsWith("ref"))
                        sidarg_count++;
                }

                if ( argtypes == "bool" )
                    argtypes = "[MarshalAs(UnmanagedType.I1)] " + argtypes;

                arg_native.Add( argtypes + " " + argname );
            }

            if (returns == "bool")
            {
                generator.EmitLine("[return: MarshalAs(UnmanagedType.I1)]", depth);
            }

            var innerReturns = returns;
            if (returns == "string")
            {
                innerReturns = "IntPtr";
            }
            generator.EmitLine( String.Format( "[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate {0} Native{1}{2}( {3} );", returnbystack ? "void" : innerReturns, GetName(), GetArgIdent(arg_native_pure), String.Join( ", ", arg_native.ToArray() ) ), depth );

            string methodname = GetName();
            string extra = "";

            if ( genericwrapper )
            {
                returns = "TClass";
                methodname = methodname + "<TClass>";
                extra = "where TClass : InteropHelp.INativeWrapper, new()";
            }

            generator.EmitLine( String.Format( "public {0} {1}( {2} ) {3}", returns, methodname, String.Join(", ", arg.ToArray() ), extra), depth );

            generator.EmitLine( "{", depth );

            StringBuilder method = new StringBuilder();

            for (int i = 0; i < sidarg_count; i++)
            {
                method.Append("UInt64 s" + i + " = 0; ");
            }

            if ( returnbystack )
            {
                if(returnbystack_special)
                    method.Append("UInt64 ret = 0; ");
                else
                    method.Append(returns + " ret = new " + returns + "();");
            }
            else if ( returns != "void" )
            {
                if (sidarg_count == 0)
                {
                    method.Append("return ");
                }
                else
                {
                    method.Append("var result = ");
                }
            }

            if ( returns == "string" )
            {
                method.Append( "InteropHelp.DecodeANSIReturn( Marshal.PtrToStringAnsi( " );
            }

            if ( genericwrapper )
            {
                method.Append( "InteropHelp.CastInterface<TClass>( " );
            }

            method.AppendFormat( "this.GetFunction<Native{0}{1}>( this.Functions.{0}{2} )( ", GetName(), GetArgIdent(arg_native_pure), ident );

            List<string> impl_args = new List<string>();
            StringBuilder footer = new StringBuilder();

            impl_args.Add( "this.ObjectAddress" );

            if ( returnbystack )
            {
                impl_args.Add( "ref ret" );
            }

            int native_arg_offset = 0;
            int sidarg_slot = 0;
            for ( int i = 0; i < args.Count; i++ )
            {
                string argname = args[i].GetName();

                if ( String.IsNullOrEmpty( argname ) )
                {
                    argname = "arg" + i;
                }

                var methodargname = argname;

                int corrected_arg = i - native_arg_offset;

                if (arg_native_pure[i].StartsWith("ref"))
                {
                    argname = "ref " + argname;
                }

                if ( i < arg_native.Count )
                {
                    if (corrected_arg < arg.Count && (arg[corrected_arg].Contains("CSteamID") || arg[corrected_arg].Contains("CGameID")))
                    {
                        if (argname.StartsWith("ref"))
                        {
                            argname = "ref s" + sidarg_slot;
                            footer.Append(methodargname + " = new " + arg_native_pure[i].Replace("ref", "").Trim() + "(s" + sidarg_slot + "); ");
                            sidarg_slot++;
                        }
                        else
                        {
                            argname = argname + ".ConvertToUint64()";
                        }
                    }
                    else if (maskedparams.Contains(i + 1) && !genericwrapper)
                    {
                        native_arg_offset++;

                        if (arg_native_pure[i] == "StringBuilder")
                        {
                            argname = String.Join(", ", new string[] { argname, "(" + arg_native_pure[i + 1] + ") " + argname + ".Capacity" });
                        }
                        else
                        {
                            argname = String.Join(", ", new string[] { argname, "(" + arg_native_pure[i + 1] + ") " + argname + ".Length" });
                        }
                    }
                    else if (maskedparams.Contains(i) && genericwrapper)
                    {
                        argname = "InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) )";
                    }
                }

                if ( genericwrapper || !maskedparams.Contains( i ) )
                {
                    impl_args.Add( argname );
                }
            }

            method.AppendFormat( "{0} )", String.Join( ", ", impl_args.ToArray() ) );

            if ( genericwrapper )
            {
                method.Append( " )" );
            }

            if ( returns == "string" )
            {
                method.Append(" ) )");
            }

            method.Append( "; " );
            method.Append(footer);

            if (returnbystack)
            {
                if (returnbystack_special)
                {
                    method.Append("return new " + returns + "(ret);");
                }
                else
                {
                    method.Append("return (" + returns + ")ret;");
                }
            }
            else if(sidarg_count > 0)
            {
                method.Append("return result;");
            }

            generator.EmitLine( method.ToString(), depth + 1 );

            generator.EmitLine( "}", depth );
            generator.EmitLine( "", depth );

        }


        private string GetArgIdent( List<string> args )
        {
            StringBuilder ident = new StringBuilder();

            foreach( string arg in args )
            {
                //ident.Append( arg.Substring(0, 1).ToUpper() );
        
                ident.Append( arg.Replace("ref", "").Trim().Substring(0, 1).ToUpper() );
            }

            return ident.ToString();
        }

    }
}
