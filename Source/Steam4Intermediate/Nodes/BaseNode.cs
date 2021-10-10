using System;
using System.Xml;
using Steam4Intermediate.NodeBehavior;

namespace Steam4Intermediate.Nodes
{
    class BaseNode : LinkBehavior
    {
        public BaseNode(XmlAttributeCollection collection)
            : base(collection)
        {

        }
    }
}
