using System;
using System.Text;
using System.Collections.Generic;
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
        static int max;

        public List<Node> ChildNodeList = new List<Node>();
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
            max = 0;
            FindMaxNodeValue(node);
            max.Should().Be(depth);
        }

        [TestMethod]
        public void GivenATreeWithDepth1WhenGetIsSetLeftThenRightShouldReceiveBall()
        {

            BinaryTreeModel model = new BinaryTreeModel();
            var depth = 1;
            var node = model.CreateFullTree(depth, 0);
            model.SetGate(node, true);
            max = 0;
            BallStrategy strategy = new BallStrategy(node);
            strategy.SetBall();
            ChildNodeList = new List<Node>();
            FindChildNodes(node);
            ChildNodeList.Count.Should().Be(2);
            ChildNodeList[0].hasBall.Should().BeTrue();
            node.gateToLeft.Should().BeFalse();
        }

        [TestMethod]
        public void GivenATreeWithDepth2WhenGetIsSetLeftThenRightShouldReceiveBall()
        {

            BinaryTreeModel model = new BinaryTreeModel();
            var depth = 2;
            var node = model.CreateFullTree(depth, 0);
            model.SetGate(node, true);
            max = 0;
            BallStrategy strategy = new BallStrategy(node);
            var ballCount = 2;
            for (int i = 0; i < 2; i++)
            {
                strategy.SetBall();
            }
            ChildNodeList = new List<Node>();
            FindChildNodes(node);
            ChildNodeList.Count.Should().Be(4);
            ChildNodeList[0].hasBall.Should().BeTrue();
            ChildNodeList[1].hasBall.Should().BeFalse();

            ChildNodeList[2].hasBall.Should().BeTrue();
            ChildNodeList[3].hasBall.Should().BeFalse();

            node.gateToLeft.Should().BeTrue();
        }


        public void FindChildNodes(Node node)
        {
            if (node != null)
            {
                if (node.left==null && node.right==null)
                {
                    ChildNodeList.Add(node);
                }
                FindChildNodes(node.left);
                FindChildNodes(node.right);
            }
        }

        public void FindMaxNodeValue(Node node)
        {
            if (node != null)
            {
                if(node.value >max)
                {
                    max = node.value;
                }
                FindMaxNodeValue(node.left);
                FindMaxNodeValue(node.right);
            }
        }
    }
}
