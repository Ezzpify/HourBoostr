using System;

namespace Steam4Intermediate
{
    interface INodeBehavior
    {
        void LinkNode( Generator generator );

        string GetName();
        string ResolveType( int depth, out INode type, out bool constness, out bool pointer );

        void EmitCode( Generator generator, int depth, int ident );
    }
}
