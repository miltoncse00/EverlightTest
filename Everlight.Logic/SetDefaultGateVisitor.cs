namespace Everlight.Logic
{
    public class SetDefaultGateVisitor : NodeVisitor
    {
        public bool GateToLeft = true;
        public override void Visit(Node node)
        {
            node.GateToLeft = GateToLeft;
        }
    }
}
