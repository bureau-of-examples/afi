using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Find the first index whose value is larger than k.
    /// The solution is to bin search k + epsilon, where epsilon is a infinitely small positive number.
    /// </summary>
    public static class Q3FindFirstLargerThan
    {
        public static int FirstLargerThan(IList<int> sortedIntegers, int k)
        {
            int start = 0;
            int end = sortedIntegers.Count - 1;

            while (start <= end)
            {
                int m = start + (end - start) / 2;
                if (sortedIntegers[m] <= k)
                    start = m + 1;
                else
                    end = m - 1;
            }

            if (start >= sortedIntegers.Count)
                return -1;
            return start;
        }
    }
}
