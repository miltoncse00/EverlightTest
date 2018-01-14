using System;

namespace Everlight.Logic
{
    public class BinaryTreeModel
    {

        public Node CreateFullTree(int depth, int tag)
        {
            var random = new Random();
            var currentNode = CreateNode(random);
            currentNode.value = tag;
            tag++;
            if (depth == 0) return currentNode;
            currentNode.left = CreateFullTree(depth - 1, tag);
            currentNode.right = CreateFullTree(depth - 1, tag);
            return currentNode;
        }

        private Node CreateNode(Random random)
        {
            return new Node
            {
                left = null,
                right = null
            };

        }

        public void PreOrder(Node tree)
        {
            if (tree != null)
            {
                Console.WriteLine(tree.value);
                PreOrder(tree.left);
                PreOrder(tree.right);
            }
            return;
        }

        public void SetGate(Node tree, bool isLeft)
        {
            if (tree != null)
            {
                tree.gateToLeft = isLeft;
                SetGate(tree.left, isLeft);
                SetGate(tree.right, isLeft);
            }
            return;
        }
    }
}

