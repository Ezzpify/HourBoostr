using System;
using System.Xml;
using Steam4Intermediate.NodeBehavior;

namespace Steam4Intermediate.Nodes
{
    class FundamentalTypeNode : LinkBehavior
    {
        public FundamentalTypeNode(XmlAttributeCollection collection)
            : base(collection)
        {
            name = GetAttribute( "kind" );
        }
    }
}
