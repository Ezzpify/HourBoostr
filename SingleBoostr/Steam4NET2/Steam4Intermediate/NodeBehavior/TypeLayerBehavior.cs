using System;
using System.Xml;

namespace Steam4Intermediate.NodeBehavior
{
    class TypeLayerBehavior : LinkBehavior
    {
        public TypeLayerBehavior(XmlAttributeCollection collection)
            : base(collection)
        {
        }

        public override string ResolveType( int depth, out INode type, out bool constness, out bool pointer )
        {
            return base.ResolveType( depth - 1, out type, out constness, out pointer );
        }


    }
}
