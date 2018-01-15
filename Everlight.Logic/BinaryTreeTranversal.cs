namespace Everlight.Logic
{
    public abstract class BinaryTreeTranversal
    {
        NodeVisitor nodeVisitor;
        public BinaryTreeTranversal()
        {
            nodeVisitor = new DisplayVisitor();
        }

        public abstract void Traverse(Node tree, NodeVisitor visitor);

        public void Traverse(Node tree)
        {
            Traverse(tree, nodeVisitor);
        }
    }
}
