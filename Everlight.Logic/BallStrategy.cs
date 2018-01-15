namespace Everlight.Logic
{
    public class BallStrategy
    {
        Node _tree;
        public BallStrategy(Node tree)
        {
            _tree = tree;
        }

        public void SetBall()
        {
            SetBall(_tree);
        }
        private void SetBall(Node tree)
        {
            if (tree != null)
            {
                if (tree.Left == null && tree.Right == null)
                {
                    tree.HasBall = true;
                    return;
                }
                else if (tree.GateToLeft)
                {
                    tree.GateToLeft = false;
                    SetBall(tree.Left);

                }
                else
                {
                    tree.GateToLeft = true;
                    SetBall(tree.Right);

                }
            }
            return;

        }
    }
}
