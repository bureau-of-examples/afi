using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Find the index of k in a list whose length is unknown.
    /// </summary>
    public static class Q5FindIndexLengthUnknown
    {
        public static int IndexLengthUnknown(IList<int> sortedIntegers, int k)
        {
            //find an end range in O(lg(n))
            int length = 1;
            while (true)
            {
                try
                {
                    if (sortedIntegers[length - 1] == k)
                        return length - 1;

                    if (sortedIntegers[length - 1] > k)
                        break;

                    length = length << 1;

                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
            }

            //k must be in the follow range
            int start = length >> 1;
            int end = length - 1;
            while (start <= end)
            {
                int m = start + (end - start) / 2;
                try
                {
                    if (sortedIntegers[m] == k)
                        return m;

                    if (sortedIntegers[m] < k)
                        start = m + 1;
                    else
                        end = m - 1;
                }
                catch (ArgumentOutOfRangeException)
                {
                    end = m - 1;
                }
            }

            return -1;


        }
    }
}
