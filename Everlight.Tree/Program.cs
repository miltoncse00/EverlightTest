using Everlight.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int depth;
            Console.WriteLine("Please enter the depth of Tree");
            depth = Convert.ToInt32(Console.ReadLine());
            BinaryTreeModel model = new BinaryTreeModel();
             var tree =model.CreateFullTree(depth,1);
            
            BinaryTreeTranversal traversal = new PreOrderTraversal();
            traversal.Traverse(tree);
            var randomGateVisitor = new RandomGateSetterVisitor();
            traversal.Traverse(tree, randomGateVisitor);

            Console.WriteLine("Please enter number of balls");
            var ballCount = Convert.ToInt32(Console.ReadLine());
            BallStrategy strategy = new BallStrategy(tree);
            for (int i = 0; i < ballCount; i++)
            {
                strategy.SetBall();
            }
            var childNodeVisitor = new ChildNodeVisitor();
            traversal.Traverse(tree, childNodeVisitor);
            Console.WriteLine("Position of the hole from left to right which is empty");
            for(int i=0; i<childNodeVisitor.ChildNodes.Count;i++)
            {
                if(childNodeVisitor.ChildNodes[i].HasBall==false)
                {
                    Console.WriteLine(string.Format("Position {0} is empty", i + 1));
                }
            }
            Console.ReadLine();
        }
    }
}
