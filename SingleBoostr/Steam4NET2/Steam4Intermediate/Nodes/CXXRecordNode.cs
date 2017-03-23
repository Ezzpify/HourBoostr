using System;
using System.Xml;
using Steam4Intermediate.NodeBehavior;

namespace Steam4Intermediate.Nodes
{
    class CXXRecordNode : LinkBehavior
    {
        public CXXRecordNode(XmlAttributeCollection collection)
            : base(collection)
        {

        }

        private bool ShouldEmitMember( INode member )
        {
            if ( member is CXXMethodNode && ( member.GetName().StartsWith( "operator" ) || member.GetAttribute("virtual") != "1" ) )
            {
                return false;
            }

            return true;
        }

        public bool ContainsVirtualMethods()
        {
            int nvirt = 0;

            foreach (INode child in children)
            {
                if (child is CXXMethodNode && ShouldEmitMember(child))
                {
                    nvirt++;
                }
            }

            return (nvirt > 0);
        }

        public int GetChildCount()
        {
            return children.Count;
        }

        private void EmitCodeClass(Generator generator, int depth, int ident)
        {
            generator.EmitLine("[StructLayout(LayoutKind.Sequential,Pack=4)]", depth);
            generator.EmitLine("public class " + name + "VTable", depth);
            generator.EmitLine("{", depth);

            int index = 0;
            foreach (INode child in children)
            {
                if (child is CXXMethodNode && ShouldEmitMember(child))
                {
                    generator.EmitLine("public IntPtr " + child.GetName() + index++ + ";", depth + 1);
                }
                else if (child is CXXDestructorNode)
                {
                    generator.EmitLine("private IntPtr DTor" + GetName() + index++ + ";", depth + 1);
                }
            }

            generator.EmitLine("};", depth);
            generator.EmitLine("", depth);

            string className = GetName().Substring(1);
            string macroName = null;

            if(className.StartsWith("Steam"))
            {
                string classValue = className.Substring(0, className.Length - 3).ToUpper();
                string intValue = className.Substring(className.Length - 3, 3);

                macroName = classValue + "_INTERFACE_VERSION_" + intValue;
            }
            else if(className.StartsWith("Client"))
            {
                macroName = className.ToUpper() + "_INTERFACE_VERSION";
            }

            if(macroName != null)
            {
                string macroValue = generator.FindMacroByName(macroName);
                
                if(macroValue != null)
                {
                    generator.EmitLine("[InteropHelp.InterfaceVersion(" + macroValue + ")]", depth);
                }
            }

            generator.EmitLine("public class " + GetName() + " : InteropHelp.NativeWrapper<" + GetName() + "VTable>", depth);
            generator.EmitLine("{", depth);

            index = 0;

            foreach (INode child in children)
            {
                if (child is CXXDestructorNode)
                {
                    index++;
                }
                else if (child is CXXMethodNode && ShouldEmitMember(child))
                {
                    child.EmitCode(generator, depth + 1, index++);
                }
            }

            generator.EmitLine("};", depth);
        }


        private void EmitCodeStruct(Generator generator, int depth, int ident)
        {
            if (GetName() == "CSteamID")
                return;

            generator.EmitLine("[StructLayout(LayoutKind.Sequential,Pack=8)]", depth);
            int attribMarker = generator.GetMarker();
            generator.EmitLine("public struct " + GetName(), depth);
            generator.EmitLine("{", depth);

            foreach (INode child in children)
            {
                if ( child is FieldNode && !String.IsNullOrEmpty( child.GetName() ) )
                {
                    INode basetype;
                    bool constness, pointer;
                    bool arraytype = false;

                    string size = "";
                    string types = child.ResolveType( 0, out basetype, out constness, out pointer );

                    if ( basetype is ArrayTypeNode )
                    {
                        size = basetype.GetAttribute("size");
                        types = basetype.ResolveType(1, out basetype, out constness, out pointer);

                        arraytype = true;
                    }

                    types = generator.ResolveType( types, constness, pointer, true, false );

                    if (types == "CSteamID")
                    {
                        types = "SteamID_t";
                    }
                    else if (types == "CGameID")
                    {
                        types = "GameID_t";
                    }

                    if(arraytype)
                    {
                        if (types == "SByte")
                        {
                            types = "string";
                        }
                        else 
                        {
                            types += "[]";
                        }
                    }

                    if ( types == "bool" )
                    {
                        generator.EmitLine( "[MarshalAs(UnmanagedType.I1)]", depth + 1 );
                    }
                    else if ( types == "string" )
                    {
                        if (arraytype)
                        {
                            generator.EmitLine("[MarshalAs(UnmanagedType.ByValTStr, SizeConst = " + size + ")]", depth + 1);
                        }
                        else
                        {
                            types = "string";
                        }
                    }
                    else if ( types == "Byte[]" )
                    {
                        if (arraytype)
                        {
                            generator.EmitLine("[MarshalAs(UnmanagedType.ByValArray, SizeConst = " + size + ")]", depth + 1);
                        }
                        else
                        {
                            types = "IntPtr";
                        }
                    }
                    else if (pointer)
                    {
                        types = "IntPtr";
                    }
                    else if (arraytype)
                    {
                        generator.EmitLine("[MarshalAs(UnmanagedType.ByValArray, SizeConst = " + size + ")]", depth + 1);
                    }
                    else if (types == child.GetName())
                    {
                        continue;
                    }

                    generator.EmitLine( String.Format( "public {0} {1};", types, child.GetName() ), depth + 1 );
                }
                else if(child is EnumNode)
                {
                    // anonymous enum declaration
                    EnumNode innerEnum = child as EnumNode;
                    int callback = innerEnum.EmitCodeInnerStructCallback(generator, depth + 1);

                    if(callback > 0)
                    {
                        generator.InsertLine("[InteropHelp.CallbackIdentity(" + callback + ")]", attribMarker, depth);
                    }
                }
                else if(child is FieldNode)
                {
                    //  anonymous field like union
                    // not implemented!
                }
            }

            generator.EmitLine("};", depth);
            generator.EmitLine("", depth);
        }

        public override void EmitCode(Generator generator, int depth, int ident)
        {
            if (ident == 0)
            {
                EmitCodeClass(generator, depth, ident);
            }
            else if(ident == 1)
            {
                EmitCodeStruct(generator, depth, ident);
            }
        }

    }
}
