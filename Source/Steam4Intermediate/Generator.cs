using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using Steam4Intermediate.Nodes;
using System.Diagnostics;

namespace Steam4Intermediate
{
    class Generator
    {
        private static Dictionary<string, Type> NodeTypeMap = new Dictionary<string, Type>()
            {
                { "TranslationUnit", typeof( TranslationUnitNode ) },

                { "Typedef", typeof( TypedefNode ) },
                { "CXXRecord", typeof( CXXRecordNode ) },
                { "Record", typeof( RecordNode ) },

                { "Field", typeof( FieldNode ) },
                { "CXXMethod", typeof( CXXMethodNode ) },
                { "CXXDestructor", typeof( CXXDestructorNode ) },
                { "CXXConstructor", typeof( CXXConstructorNode ) },
                { "Function", typeof( FunctionNode ) },

                { "FunctionType", typeof( FunctionTypeNode ) },
                { "ReferenceType", typeof( ReferenceTypeNode ) },
                { "PointerType", typeof( PointerTypeNode ) },
                { "ArrayType", typeof( ArrayTypeNode ) },
                { "ElaboratedType", typeof( ElaboratedTypeNode ) },
                { "FundamentalType", typeof( FundamentalTypeNode ) },
                { "CvQualifiedType", typeof( CvQualifiedTypeNode ) },

                { "EnumConstant", typeof( EnumConstantNode) },
                { "ParmVar", typeof( ParmVarNode ) },

                { "Base", typeof( BaseNode ) },
                { "Var", typeof( VarNode ) },

                { "Enum", typeof( EnumNode ) },
                { "Template", typeof( TemplateNode ) },

                { "LinkageSpec", typeof( LinkageSpecNode ) },

                { "File", typeof( FileNode ) },
            };

        private static Dictionary<string, string> CTypeMap = new Dictionary<string, string>()
            {
                { "char", "SByte" },
                { "signed char", "SByte" },
                { "unsigned char", "Byte" },

                { "short", "Int16" },
                { "unsigned short", "UInt16" },
                { "int16", "Int16" },
                { "uint16", "UInt16" },

                { "int", "Int32" },
                { "int32", "Int32" },
                { "uint32", "UInt32" },
                { "unsigned int", "UInt32" },
                { "long", "Int32" },
                { "unsigned long", "UInt32" },

                { "int64", "Int64" },
                { "uint64", "UInt64" },
                { "unsigned long long", "UInt64" },
                { "long long", "Int64" },

                { "IConCommandBaseAccessor", "IntPtr" }, // a
            };

        private Dictionary<String, INode> NodesByID = new Dictionary<String, INode>();
        private Dictionary<Type, List<INode>> NodesByType = new Dictionary<Type, List<INode>>();
        private Dictionary<string, string> MacroDefinitions = new Dictionary<string, string>();

        private StringBuilder buffer = new StringBuilder();

        public void ParseXMLDoc( XmlDocument doc )
        {
            XmlNode root = doc.ChildNodes[1];

            RecursiveAddNode( root );

            foreach( INode node in NodesByID.Values )
            {
                node.LinkNode( this );
            }

            foreach (INode node in NodesByType[typeof(FileNode)])
            {
                if (node.name.Contains("Open Steamworks"))
                {
                    node.EmitCode(this, 0, 0);
                }
            }
        }

        public void FlushToFile( string file )
        {
            File.WriteAllText( "../../../autogen/" + file + ".cs", buffer.ToString() );
            buffer = new StringBuilder();
        }

        public void EmitLine( string line, int depth )
        {
            buffer.AppendFormat( "{0}{1}\r\n", new String( '\t', depth ), line );
        }

        public int GetMarker()
        {
            return buffer.Length;
        }

        public void InsertLine( string line, int marker, int depth)
        {
            buffer.Insert(marker, String.Format("{0}{1}\r\n", new String('\t', depth), line));
        }

        public string ResolveType( string inputtype, bool constness, bool pointer, bool returntype, bool allow_ref )
        {
            string outtype;

            Debug.Assert(inputtype != null);

            if ( !CTypeMap.TryGetValue( inputtype, out outtype ) )
            {
                outtype = inputtype;
            }

            if ( pointer )
            {
                if ( outtype == "SByte" )
                {
                    if (constness || returntype)
                    {
                        outtype = "string";
                    }
                    else
                    {
                        outtype = "StringBuilder";
                    }
                }
                else if (outtype == "Byte" || outtype == "void")
                {
                    outtype = "Byte[]";
                }
                else if (allow_ref)
                {
                    outtype = "ref " + outtype;
                }
            }

            //Debug.Assert(outtype != "SByte");
            return outtype;
        }

        private void RecursiveAddNode( XmlNode node )
        {
            Type parserType;

            if( !NodeTypeMap.TryGetValue( node.Name, out parserType ) )
            {
                if(node.Name == "MacroDefine")
                {
                    MacroDefinitions.Add(node.Attributes["name"].Value, node.Attributes["value"].Value);
                } else
                {
                    Console.WriteLine("Unhandled node type " + node.Name);
                }
                
            }

            if ( parserType != null )
            {
                XmlNode idnode = node.Attributes.GetNamedItem( "id" );

                if ( idnode != null )
                {

                    INode currentNode;
                    if ( NodesByID.TryGetValue( idnode.Value, out currentNode ) )
                    {
                        currentNode.SetContextAttributes( node.Attributes );
                    }
                    else
                    {
                        INode newNode = parserType.GetConstructor(new System.Type[] { typeof(XmlAttributeCollection) }).Invoke(new object[] { node.Attributes }) as INode;

                        NodesByID.Add( idnode.Value, newNode );

                        List<INode> types = GetNodesByType( newNode.GetType() );

                        if ( types == null )
                        {
                            types = new List<INode>();
                            NodesByType.Add(newNode.GetType(), types);
                        }

                        types.Add(newNode);
                    }

                }
            }

            foreach( XmlNode child in node.ChildNodes )
            {
                RecursiveAddNode( child );
            }
        }


        public INode GetNodeByID(string id)
        {
            INode node;
            if (NodesByID.TryGetValue(id, out node))
            {
                return node;
            }

            return null;
        }

        public List<INode> GetNodesByType(Type type)
        {
            List<INode> nodes;

            if (NodesByType.TryGetValue(type, out nodes))
            {
                return nodes;
            }

            return null;
        }

        public string FindMacroByName(string name)
        {
            string value;

            if(MacroDefinitions.TryGetValue(name, out value))
                return value;

            return null; 
        }
    }
}
