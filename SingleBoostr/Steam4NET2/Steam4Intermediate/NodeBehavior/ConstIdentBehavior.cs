using System;
using System.Xml;

namespace Steam4Intermediate.NodeBehavior
{
    class ConstIdentBehavior : LinkBehavior
    {
        public ConstIdentBehavior(XmlAttributeCollection collection)
            : base(collection)
        {
        }

        public override void LinkNode(Generator generator)
        {
            base.LinkNode(generator);

            string isconst = GetAttribute("const");

            if (isconst != null)
            {
                constIdentNode = this;
            }
        }

        public override string ResolveType(int depth, out INode type, out bool constness, out bool pointer)
        {
            string ret_type = base.ResolveType(depth, out type, out constness, out pointer);

            constness = true;
            return ret_type;
        }
    }
}
