using System;
using System.Xml;

namespace Steam4Intermediate.NodeBehavior
{
    class PointerLayerBehavior : TypeLayerBehavior
    {
        public PointerLayerBehavior(XmlAttributeCollection collection)
            : base(collection)
        {
        }

        public override string ResolveType( int depth, out INode type, out bool constness, out bool pointer )
        {
            if ( depth <= 0 )
            {
                type = this;
                pointer = true;
                constness = (constIdentNode != null);

/*
                INode returntype;
                bool retconst, retpointer;

                return base.ResolveType(depth + 1, out returntype, out retconst, out retpointer);
*/
                bool retpointer;

                return base.ResolveType(depth + 1, out type, out constness, out retpointer);
            }

            return typeNode.ResolveType(depth, out type, out constness, out pointer);
        }


    }
}
