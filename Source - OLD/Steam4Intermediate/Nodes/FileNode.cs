﻿using System;
using System.Xml;
using Steam4Intermediate.NodeBehavior;
using System.IO;

namespace Steam4Intermediate.Nodes
{
    class FileNode : LinkBehavior
    {
        public FileNode(XmlAttributeCollection collection)
            : base(collection)
        {

        }

        public override void EmitCode(Generator generator, int depth, int ident)
        {
            generator.EmitLine( "// This file is automatically generated.", depth );
            generator.EmitLine( "using System;", depth );
            generator.EmitLine( "using System.Text;", depth );
            generator.EmitLine( "using System.Runtime.InteropServices;", depth );
            generator.EmitLine( "", depth );
            generator.EmitLine( "namespace Steam4NET", depth );
            generator.EmitLine( "{", depth );
            generator.EmitLine( "", depth );

            foreach( INode child in children )
            {
                if ( child is CXXRecordNode )
                {
                    CXXRecordNode recordnode = child as CXXRecordNode;

                    INode basetype;
                    bool constness, pointer;

                    recordnode.ResolveType( 1, out basetype, out constness, out pointer );

                    if ( basetype.GetAttribute( "kind" ) == "class" && recordnode.ContainsVirtualMethods() )
                    {
                        recordnode.EmitCode( generator, depth + 1, 0 );
                    }
                    else if (recordnode.GetChildCount() > 0)
                    {
                        recordnode.EmitCode( generator, depth + 1, 1 );
                    }
                }
                else if ( child is EnumNode )
                {
                    EnumNode enumnode = child as EnumNode;

                    enumnode.EmitCode( generator, depth + 1, ident );
                }
            }

            generator.EmitLine( "}", depth );
            generator.FlushToFile( Path.GetFileNameWithoutExtension( name ) );
        }

    }
}