using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    public static class Q17SearchBSTFirstLargeThan
    {
        public static Q16SearchBST.BSTNode FirstLargeThan(Q16SearchBST.BSTNode root, int value)
        {
            Q16SearchBST.BSTNode result = null;

            while (root != null)
            {
                if (root.Value > value)
                {
                    result = root;
                    root = root.Left;
                }
                else
                    root = root.Right;
            }

            return result;
        }
    }
}
