using System;

namespace Everlight.Logic
{
    public class RandomGateSetterVisitor : NodeVisitor
    {
        Random random = new Random();
        public override void Visit(Node node)
        {
            var leftOpen = random.Next() % 2 == 0;
            node.GateToLeft = leftOpen;
        }
    }
}
