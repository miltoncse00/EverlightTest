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
            Console.ReadLine();
        }
    }
}
