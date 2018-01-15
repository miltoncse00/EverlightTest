using Microsoft.VisualStudio.TestTools.UnitTesting;
using Everlight.Logic;
using FluentAssertions;

namespace Everlight.Tree.Tests
{
    /// <summary>
    /// Summary description for BinaryTreeTest
    /// </summary>
    [TestClass]
    public class BinaryTreeTest
    {
         public BinaryTreeTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GivenATreeWithDepthCheckTheDepthOfTree()
        {
            BinaryTreeModel model = new BinaryTreeModel();
            var depth = 4;
            var node = model.CreateFullTree(depth, 0);
            var maxNodeVisitor = new MaxNodeVisitor();
            var traversal = new PreOrderTraversal();
            traversal.Traverse(node, maxNodeVisitor);
           
            maxNodeVisitor.MaxValue.Should().Be(depth);
        }

        [TestMethod]
        public void GivenATreeWithDepth1WhenGetIsSetLeftThenRightShouldReceiveBall()
        {

            BinaryTreeModel model = new BinaryTreeModel();
            var depth = 1;
            var node = model.CreateFullTree(depth, 0);
            var nodeTraversal = new PreOrderTraversal();
            var defaultGateVisitor = new SetDefaultGateVisitor();
            defaultGateVisitor.GateToLeft = true;
            nodeTraversal.Traverse(node, defaultGateVisitor);
            BallStrategy strategy = new BallStrategy(node);
            strategy.SetBall();

            var childNodeVisitor = new ChildNodeVisitor();
            nodeTraversal.Traverse(node, childNodeVisitor);
            childNodeVisitor.ChildNodes.Count.Should().Be(2);
            childNodeVisitor.ChildNodes[0].HasBall.Should().BeTrue();
            node.GateToLeft.Should().BeFalse();
        }

        [TestMethod]
        public void GivenATreeWithDepth2WhenGetIsSetLeftThenRightShouldReceiveBall()
        {

            BinaryTreeModel model = new BinaryTreeModel();
            var depth = 2;
            var node = model.CreateFullTree(depth, 0);
            var nodeTraversal = new PreOrderTraversal();
            var defaultGateVisitor = new SetDefaultGateVisitor();
            defaultGateVisitor.GateToLeft = true;
            nodeTraversal.Traverse(node, defaultGateVisitor);

            BallStrategy strategy = new BallStrategy(node);
            var ballCount = 2;
            for (int i = 0; i < ballCount; i++)
            {
                strategy.SetBall();
            }
            var childNodeVisitor = new ChildNodeVisitor();
            nodeTraversal.Traverse(node, childNodeVisitor);
            childNodeVisitor.ChildNodes.Count.Should().Be(4);
            childNodeVisitor.ChildNodes[0].HasBall.Should().BeTrue();
            childNodeVisitor.ChildNodes[1].HasBall.Should().BeFalse();

            childNodeVisitor.ChildNodes[2].HasBall.Should().BeTrue();
            childNodeVisitor.ChildNodes[3].HasBall.Should().BeFalse();

            node.GateToLeft.Should().BeTrue();
        }


        [TestMethod]
        public void GivenATreeWithDepth2WhenGetIsSetGateRightDrop3BallShouldReceiveBall()
        {

            BinaryTreeModel model = new BinaryTreeModel();
            var depth = 2;
            var node = model.CreateFullTree(depth, 0);
            var nodeTraversal = new PreOrderTraversal();
            var defaultGateVisitor = new SetDefaultGateVisitor();
            defaultGateVisitor.GateToLeft = false;
            nodeTraversal.Traverse(node, defaultGateVisitor);

            BallStrategy strategy = new BallStrategy(node);
            var ballCount = 3;
            for (int i = 0; i < ballCount; i++)
            {
                strategy.SetBall();
            }
            var childNodeVisitor = new ChildNodeVisitor();
            nodeTraversal.Traverse(node, childNodeVisitor);
            childNodeVisitor.ChildNodes.Count.Should().Be(4);
            childNodeVisitor.ChildNodes[0].HasBall.Should().BeFalse();
            childNodeVisitor.ChildNodes[1].HasBall.Should().BeTrue();

            childNodeVisitor.ChildNodes[2].HasBall.Should().BeTrue();
            childNodeVisitor.ChildNodes[3].HasBall.Should().BeTrue();

            node.GateToLeft.Should().BeTrue();
        }

    }
}
