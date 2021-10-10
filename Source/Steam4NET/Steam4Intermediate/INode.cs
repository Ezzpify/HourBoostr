using System;
using System.Xml;
using System.Collections.Generic;

namespace Steam4Intermediate
{
    abstract class INode : INodeBehavior
    {
        public string id;
        public string name;

        protected List<INode> children;

        private XmlAttributeCollection attributes;
        private XmlAttributeCollection context_attributes;

        public INode(XmlAttributeCollection collection)
        {
            children = new List<INode>();

            attributes = collection;

            id = GetAttribute( "ptr" );
            name = GetAttribute( "name" );
        }




        public virtual void LinkNode( Generator generator )
        {
        }

        public virtual string GetName()
        {
            return name;
        }

        public virtual string ResolveType( int depth, out INode type, out bool constness, out bool pointer )
        {
            type = this;
            constness = false;
            pointer = false;

            return GetName();
        }

        public virtual void EmitCode( Generator generator, int depth, int ident )
        {
        }



        public void AddChild( INode child )
        {
            children.Add( child );
        }

        public string GetContextAttribute( string attribute )
        {
            if ( context_attributes == null )
                return null;

            XmlNode attribnode = context_attributes.GetNamedItem(attribute);

            if (attribnode == null)
                return null;

            return attribnode.Value;
        }

        public string GetAttribute( string attribute )
        {
            XmlNode attribnode = attributes.GetNamedItem( attribute );

            if ( attribnode == null )
                return null;

            return attribnode.Value;
        }

        public void SetContextAttributes( XmlAttributeCollection context )
        {
            context_attributes = context;
        }

        public override string ToString()
        {
            INode extra;
            bool constness, pointer;

            return "[" + this.GetType().Name + "]#" + id + " = " + GetName() + " :: " + ResolveType( 1, out extra, out constness, out pointer ); 
        }
    }
}
