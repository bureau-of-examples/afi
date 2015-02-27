using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Search the first index in sorted array whose value is k.
    /// </summary>
    public static class Q2FindFirstIndex
    {
        public static int FirstIndex(IList<int> sortedIntegers, int k)
        {
            int start = 0;
            int end = sortedIntegers.Count - 1;

            while (start <= end)
            {
                int m = start + (end - start) / 2;
                if (sortedIntegers[m] == k)
                {
                    while (m > 0 && sortedIntegers[m - 1] == k) //linear scan forwardly
                        m--;

                    return m;
                }

                if (sortedIntegers[m] < k)
                    start = m + 1;
                else
                    end = m - 1;
            }

            return -1;
        }
    }
}
