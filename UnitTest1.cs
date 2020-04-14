using Black_Red_tree.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Black_Red_tree.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private int[] Nodes = { 20, 23, 26, 19 };
        private RBTree.Node ExpectedRoot = new RBTree.Node();

        [TestMethod]
        public void AddNode_CheckValue()
        {
            SetExpectedRoot();
            ITree tree = new RBTree();
            for (int i = 0; i < Nodes.Length; i++)
            {
                tree.AddNode(Nodes[i]);
            }
            var result = tree.Root;
            Assert.AreEqual(ExpectedRoot.Left.Value, result.Left.Value);
            Assert.AreEqual(ExpectedRoot.Right.Value, result.Right.Value);
            Assert.AreEqual(ExpectedRoot.Left.Left.Value, result.Left.Left.Value);
            Assert.AreEqual(ExpectedRoot.Value, result.Value);
        }

        [TestMethod]
        public void RemoveNode_CheckFullRemove()
        {
            ITree tree = new RBTree();
            for (int i = 0; i < Nodes.Length; i++)
            {
                tree.RemoveNode(Nodes[i]);
            }
            Assert.AreEqual(null, tree.Root);
        }

        [TestMethod]
        public void FindMaxMin_CheckValue()
        {
            ITree tree = new RBTree();
            for (int i = 0; i < Nodes.Length; i++)
            {
                tree.AddNode(Nodes[i]);
            }
            Assert.AreEqual(26, tree.MaxNode().Value);
            Assert.AreEqual(19, tree.MinNode().Value);
        }

        [TestMethod]
        public void GetColorNodeByKey_CheckColor()
        {
            ITree tree = new RBTree();
            for (int i = 0; i < Nodes.Length; i++)
            {
                tree.AddNode(Nodes[i]);
            }
            Assert.AreEqual(Color.R, tree.GetColorNodeByKey(19));
            Assert.AreEqual(Color.B, tree.GetColorNodeByKey(23));
            Assert.AreEqual(Color.B, tree.GetColorNodeByKey(20));
            Assert.AreEqual(Color.B, tree.GetColorNodeByKey(26));
        }

        [TestMethod]
        public void FindNextPrev_CheckValue()
        {
            ITree tree = new RBTree();
            for (int i = 0; i < Nodes.Length; i++)
            {
                tree.AddNode(Nodes[i]);
            }
            Assert.AreEqual(20, tree.FindNextNode(19).Value);
            Assert.AreEqual(19, tree.FindPrevNode(20).Value);
            Assert.AreEqual(null, tree.FindPrevNode(19));
            Assert.AreEqual(26, tree.FindNextNode(23).Value);
            Assert.AreEqual(20, tree.FindPrevNode(23).Value);
        }

        [TestMethod]
        public void FindMinMax_EmptyTree_CheckNull()
        {
            ITree tree = new RBTree();
            Assert.AreEqual(null, tree.MaxNode());
            Assert.AreEqual(null, tree.MinNode());
        }

        [TestMethod]
        public void RemoveNode_NewRoot_CheckNullParent()
        {
            ITree tree = new RBTree();
            int[] nodes = { 25, 8, 52, 46, 22, 78 };
            for (int i = 0; i < nodes.Length; i++)
            {
                tree.AddNode(nodes[i]);
            }
            tree.RemoveNode(25);
            Assert.AreEqual(null, tree.Root.Parent);
            Assert.AreEqual(22, tree.Root.Value);
            tree.RemoveNode(22);
            Assert.AreEqual(null, tree.Root.Parent);
            Assert.AreEqual(52, tree.Root.Value);
            tree.RemoveNode(52);
            Assert.AreEqual(null, tree.Root.Parent);
            Assert.AreEqual(46, tree.Root.Value);
            tree.RemoveNode(46);
            Assert.AreEqual(null, tree.Root.Parent);
            Assert.AreEqual(8, tree.Root.Value);
        }

        private void SetExpectedRoot()
        {
            ExpectedRoot.Value = 23;
            ExpectedRoot.Colour = Color.B;
            ExpectedRoot.Left = new RBTree.Node();
            ExpectedRoot.Right = new RBTree.Node();

            ExpectedRoot.Left.Value = 20;
            ExpectedRoot.Left.Colour = Color.B;
            ExpectedRoot.Left.Left = new RBTree.Node();
            ExpectedRoot.Left.Right = null;
            ExpectedRoot.Left.Parent = ExpectedRoot;

            ExpectedRoot.Right.Value = 26;
            ExpectedRoot.Right.Colour = Color.B;
            ExpectedRoot.Right.Left = null;
            ExpectedRoot.Right.Right = null;
            ExpectedRoot.Right.Parent = ExpectedRoot;

            ExpectedRoot.Left.Left.Value = 19;
            ExpectedRoot.Left.Left.Colour = Color.R;
            ExpectedRoot.Left.Left.Left = null;
            ExpectedRoot.Left.Left.Right = null;
            ExpectedRoot.Left.Left.Parent = ExpectedRoot.Left;
        }
    }
}
