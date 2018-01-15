using System;

namespace Everlight.Logic
{
    public class BinaryTreeModel
    {
        public Node CreateFullTree(int depth, int tag)
        {
            var random = new Random();
            var currentNode = CreateNode(random);
            currentNode.Value = tag;
            tag++;
            if (depth == 0) return currentNode;
            currentNode.Left = CreateFullTree(depth - 1, tag);
            currentNode.Right = CreateFullTree(depth - 1, tag);
            return currentNode;
        }

        private Node CreateNode(Random random)
        {
            return new Node
            {
                Left = null,
                Right = null
            };

        }
    }
}

