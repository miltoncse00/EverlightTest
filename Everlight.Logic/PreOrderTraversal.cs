
namespace Everlight.Logic
{
    public class PreOrderTraversal : BinaryTreeTranversal
    {
        public override void Traverse(Node tree, NodeVisitor visitor)
        {
            if(tree !=null)
            {
                visitor.Visit(tree);
                Traverse(tree.Left, visitor);
                Traverse(tree.Right, visitor);
            }
        }
    }
}
