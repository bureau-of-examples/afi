using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Find kth statistics in 2 sorted arrays in O(lg m + lg n) time.
    /// The 2 arrays can have duplicate items.
    /// </summary>
    public static class Q18KthStatisticsOf2Arrays
    {
        /// <summary>
        ///<![CDATA[
        /// Of the k smallest elements in a and b (two sorted arrays),
        /// u items are in a and k-u items are in b.
        /// The on the right boundary of the k-smallest region, we have these 2 conditions:
        /// a[u-1]<=b[k-u] and b[k-u-1]<=a[u]
        /// That is:
        /// a a a a a[u-1]    | a[u] a a a a
        /// b b     b[k-u-1]  | b[k-u] b b b
        /// 
        /// u in [0, k] and -
        /// k-u<=b.count <=> u>=k-b.count
        /// u<=a.count
        /// This u can be binary searched (when checking that k/2 is not u we can eliminate left or right half of the range).
        /// ]]>
        /// </summary>
        /// <returns></returns>
        public static int KthStatistics(IList<int> a, IList<int> b, int k)
        {
            Contract.Requires(k > 0);
            Contract.Requires(a.Count + b.Count >= k);

            //bin search range, minus 1 to convert to index
            int start = Max(0, k - b.Count);
            int end = Min(k, a.Count);
            int u = start;

            while (start <= end)
            {
                u = start + (end - start) / 2;
                //if (u == 0 || u == k)//if u = 0 or k, search reaches end - check is successful becuase u must exist.
                //    break;

                bool noGreaterThanA2B = k - u == b.Count || u == 0 || a[u - 1] <= b[k - u]; //could still break lower bound
                bool noGreaterThanB2A = u == a.Count || k == u || b[k - u - 1] <= a[u];

                if (noGreaterThanA2B && !noGreaterThanB2A) //more small elements in a
                    start = u + 1;
                else if (!noGreaterThanA2B && noGreaterThanB2A) //more small elements in b
                    end = u - 1;
                else
                    break;//found

            }

            if (u == 0)
                return b[k - 1];
            if (u == k)
                return a[k - 1];
            return Max(a[u - 1], b[k - u - 1]);
        }

        private static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        private static int Min(int a, int b)
        {
            return a < b ? a : b;
        }

    }
}
