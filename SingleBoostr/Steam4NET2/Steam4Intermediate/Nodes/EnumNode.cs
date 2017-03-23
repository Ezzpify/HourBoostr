using System;
using System.Xml;
using System.Collections.Generic;
using Steam4Intermediate.NodeBehavior;

namespace Steam4Intermediate.Nodes
{
    class EnumNode : TypeLayerBehavior
    {
        public EnumNode(XmlAttributeCollection collection)
            : base(collection)
        {
        }

        private static Dictionary<string, string> EnumShortCodes = new Dictionary<string, string>()
        {
            { "Byte", "byte" },
            { "SByte", "sbyte" },
            { "Int16", "short" },
            { "UInt16", "ushort" },
            { "Int32", "int" },
            { "UInt32", "int" },
        };

        public override void EmitCode(Generator generator, int depth, int ident)
        {
            if ( String.IsNullOrEmpty( GetName() ) )
                return;

            INode returntype;
            bool constness, pointer;

            string types = base.ResolveType( 1, out returntype, out constness, out pointer );

            types = generator.ResolveType( types, constness, pointer, true, false );

            generator.EmitLine( "public enum " + name + " : " + EnumShortCodes[types], depth );
            generator.EmitLine( "{", depth );

            foreach( INode child in children )
            {
                if ( child is EnumConstantNode )
                {
                    generator.EmitLine( String.Format( "{0} = {1},", child.GetName(), child.GetAttribute( "value" ) ), depth + 1 );
                }
            }

            generator.EmitLine( "};", depth );
            generator.EmitLine( "", depth );
        }

        public int EmitCodeInnerStructCallback(Generator generator, int depth)
        {
            // don't emit an anonymous enum reference, the real enum is attached through the context
            if (typeNode is EnumNode)
                return -1;

            INode returntype;
            bool constness, pointer;

            string types = base.ResolveType(1, out returntype, out constness, out pointer);

            types = generator.ResolveType(types, constness, pointer, true, false);

            foreach (INode child in children)
            {
                if (child is EnumConstantNode)
                {
                    generator.EmitLine(String.Format("public const {0} {1} = {2};", EnumShortCodes[types], child.GetName(), child.GetAttribute("value")), depth);
                    return Convert.ToInt32(child.GetAttribute("value"));
                }
            }

            return -1;
        }

    }
}
