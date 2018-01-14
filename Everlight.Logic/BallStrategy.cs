using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (tree.left == null && tree.right == null)
                {
                    tree.hasBall = true;
                    return;
                }
                else if (tree.gateToLeft)
                {
                    tree.gateToLeft = false;
                    SetBall(tree.left);

                }
                else
                {
                    tree.gateToLeft = true;
                    SetBall(tree.right);

                }
            }
            return;

        }
    }
}
