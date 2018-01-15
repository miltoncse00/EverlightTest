using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
