using System;
using System.Xml;

namespace Steam4Intermediate.NodeBehavior
{
    class LinkBehavior : INode
    {
        public INode fileNode;
        public INode contextNode;
        public INode typeNode;
        public INode constIdentNode;

        public LinkBehavior(XmlAttributeCollection collection)
            : base(collection)
        {
            fileNode = null;
            contextNode = null;
            typeNode = null;
        }

        public override void LinkNode( Generator generator )
        {
            string id = GetAttribute( "file" );

            if ( id != null )
            {
                fileNode = generator.GetNodeByID( id );
                fileNode.AddChild( this );
            }

            id = GetAttribute( "context" );

            if ( id != null )
            {
                contextNode = generator.GetNodeByID( id );
                contextNode.AddChild( this );
            }

            id = GetAttribute( "type" );

            if (id != null)
            {
                typeNode = generator.GetNodeByID(id);
                typeNode.AddChild(this);
            }


            string context_id = GetContextAttribute("type");

            if (context_id != null && id != context_id)
            {
                LinkBehavior linknode = generator.GetNodeByID(context_id) as LinkBehavior;
                linknode.typeNode = this;

                this.AddChild(linknode);
            }
        }

        public override string ResolveType( int depth, out INode type, out bool constness, out bool pointer )
        {
            type = this;
            constness = false;
            pointer = false;

            if ( typeNode == null || depth < 0 )
            {
                if ( constIdentNode != null )
                    constness = true;

                return GetName();
            }

            return typeNode.ResolveType( depth, out type, out constness, out pointer );
        }


    }
}
