using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Find an index i where A[i]==i.
    /// A is a sorted array of distinct integers.
    /// </summary>
    public static class Q4FindValueEqualsToIndex
    {
        public static int ValueEqualsToIndex(IList<int> sortedIntegers)
        {
            int start = 0;
            int end = sortedIntegers.Count - 1;
            while (start <= end)
            {
                int m = start + (end - start) / 2;
                if (m == sortedIntegers[m])
                    return m;

                if (m < sortedIntegers[m]) //search left half
                    end = m - 1;
                else
                    start = m + 1;//search right half
            }
            return -1;
        }
    }
}
