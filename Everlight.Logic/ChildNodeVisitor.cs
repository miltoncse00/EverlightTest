using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.Logic
{
    public class ChildNodeVisitor:NodeVisitor
    {
        public List<Node> ChildNodes = new List<Node>();

        public override void Visit(Node node)
        {
           if(node.Left==null && node.Right == null)
            {
                ChildNodes.Add(node);
            }
        }
    }
}
