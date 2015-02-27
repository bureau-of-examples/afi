using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Find the intersection of 2 sorted list.
    /// The reuslt should contain no duplicates.
    /// </summary>
    public static class Q7IntersectNoDuplicate
    {
        /// <summary>
        /// Use binary search to find if the items the shorter list is also in the longer list.
        /// This applies when one list is significantly smaller than the other:
        /// m * lg(n) <= m + n
        /// </summary>
        /// <param name="sortedIntegers1"></param>
        /// <param name="sortedIntegers2"></param>
        /// <returns></returns>
        public static IList<int> IntersectBin(IList<int> sortedIntegers1, IList<int> sortedIntegers2)
        {
            IList<int> shorter = sortedIntegers1;
            IList<int> longer = sortedIntegers2;

            if (sortedIntegers1.Count > sortedIntegers2.Count)
            {//swap 
                var temp = shorter;
                shorter = longer;
                longer = temp;
            }

            List<int> result = new List<int>();
            for (int i = 0; i < shorter.Count; i++)
            {
                if (i > 0 && shorter[i] == shorter[i - 1])
                    continue; //bypass duplicates

                int k = shorter[i];
                int start = 0;
                int end = longer.Count - 1;

                while (start <= end)
                {
                    int m = start + (end - start) / 2;
                    if (longer[m] == k)
                    {
                        result.Add(k);
                        break;
                    }

                    if (longer[m] < k)
                        start = m + 1;
                    else
                        end = m - 1;
                }
            }

            return result;
        }

        /// <summary>
        /// Get intersection of two lists via merging.
        /// Complexity is O(m+n).
        /// </summary>
        /// <param name="sortedIntegers1"></param>
        /// <param name="sortedIntegers2"></param>
        /// <returns></returns>
        /// 

        public static IList<int> IntersectMerge(IList<int> sortedIntegers1, IList<int> sortedIntegers2)
        {
            List<int> result = new List<int>();

            int index1 = 0;
            int index2 = 0;
            while (index1 < sortedIntegers1.Count && index2 < sortedIntegers2.Count)
            {
                int value;
                if (sortedIntegers1[index1] == sortedIntegers2[index2])
                {
                    value = sortedIntegers1[index1];
                    index1++;
                    index2++;

                    if (result.Count == 0 || result[result.Count - 1] != value)
                        result.Add(value);

                }
                else if (sortedIntegers1[index1] < sortedIntegers2[index2])
                    index1++;
                else
                    index2++;
               
            }

            return result;
        }


        /// <summary>
        /// Union 2 lists, result contains no duplicates.
        /// </summary>
        /// <param name="sortedIntegers1"></param>
        /// <param name="sortedIntegers2"></param>
        /// <returns></returns>
        public static IList<int> UnionMerge(IList<int> sortedIntegers1, IList<int> sortedIntegers2)
        {
            List<int> result = new List<int>();

            int index1 = 0;
            int index2 = 0;
            while (index1 < sortedIntegers1.Count && index2 < sortedIntegers2.Count)
            {
                int value;
                if (sortedIntegers1[index1] <= sortedIntegers2[index2])
                    value = sortedIntegers1[index1++];
                else
                    value = sortedIntegers2[index2++];

                if (result.Count == 0 || result[result.Count - 1] != value)
                    result.Add(value);
            }

            //add rest no dup
            while (index1 < sortedIntegers1.Count)
            {
                int value = sortedIntegers1[index1++];
                if (result.Count == 0 || result[result.Count - 1] != value)
                    result.Add(value);
            }

            while (index2 < sortedIntegers2.Count)
            {
                int value = sortedIntegers2[index2++];
                if (result.Count == 0 || result[result.Count - 1] != value)
                    result.Add(value);
            }

            return result;
        }
    }
}
