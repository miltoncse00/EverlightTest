using System;

namespace Everlight.Logic
{
    public class DisplayVisitor : NodeVisitor
    {
        public override void Visit(Node node)
        {
            Console.WriteLine(node.Value);
        }
    }
}