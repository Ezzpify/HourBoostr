using System;
using System.Xml;

namespace Steam4Intermediate.NodeBehavior
{
    class FunctionLayerBehavior : LinkBehavior
    {
        public FunctionLayerBehavior(XmlAttributeCollection collection)
            : base(collection)
        {
        }

        public override void LinkNode(Generator generator)
        {
            base.LinkNode( generator );

            string id = GetAttribute("result_type");

            if ( id != null )
            {
                typeNode = generator.GetNodeByID( id );
                typeNode.AddChild(this);
            }
        }

        public override string ResolveType( int depth, out INode type, out bool constness, out bool pointer )
        {
            pointer = true;
            constness = false;
            type = this;

            return "IntPtr";

            /*
            type = this;
            constness = false;
            pointer = false;

            INode returntype;
            bool retconstness, retpointer;
            return "Func return: (" + base.ResolveType( depth + 1, out returntype, out retconstness, out retpointer ) + ")";
             */
        }


    }
}
