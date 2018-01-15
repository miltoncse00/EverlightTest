namespace Everlight.Logic
{
    public class MaxNodeVisitor:NodeVisitor
    {
        public int MaxValue;
        public override void Visit(Node node)
        {
            if (node.Value > MaxValue)
            {
                MaxValue = node.Value;
            }
        }
    }
}
