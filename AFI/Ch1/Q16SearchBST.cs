using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    public class Q16SearchBST
    {
        public class BSTNode
        {
            public BSTNode(int value)
            {
                this.Value = value;
            }

            public BSTNode Parent
            {
                get;
                set;
            }

            public BSTNode Left
            {
                get;
                set;
            }

            public BSTNode Right
            {
                get;
                set;
            }

            public int Value
            {
                get;
                set;
            }
        }

        public static BSTNode SearchRecursive(BSTNode root, int value)
        {
            if (root == null)
                return null;

            if (root.Value == value)
                return root;

            if (value < root.Value)
                return SearchRecursive(root.Left, value);
            else
                return SearchRecursive(root.Right, value);

        }

        public static BSTNode SearchIterative(BSTNode root, int value)
        {
            while (root != null)
            {
                if (root.Value == value)
                    return root;

                if (value < root.Value)
                    root = root.Left;
                else
                    root = root.Right;
            }
            return root;
        }
    }
}
