using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch2
{
    /// <summary>
    /// Get unique elements from a list.
    /// </summary>
    public static class Q9RemoveDuplicateFirstnames
    {
        public static IList<int> GetDistinct(IList<int> source)
        {
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < source.Count; i++)
            {
                result.Add(source[i]);
            }

            return result.ToList();
        }

        //or for small input sort inplace and do a linear scan to check for duplicates

        public static void RetainDistinct(List<int> source)
        {
            QuickSort(source, 0, source.Count - 1);
            for (int i = 1; i < source.Count; i++)
            {
                if (source[i] == source[i - 1])
                {
                    source.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void QuickSort(IList<int> source, int start, int end)
        { 
            if(start >= end)
                return;

            //partition
            int partitionSize = 1;
            for (int i = start + 1; i <= end; i++)
            {
                if (source[i] <= source[start])
                {
                    int newPos = partitionSize + start;
                    if (i != newPos)
                    {
                        var temp = source[newPos];
                        source[newPos] = source[i];
                        source[i] = temp;
                    }
                    partitionSize++;
                }
            }

            int m = start + partitionSize - 1;
            var temp2 = source[start];
            source[start] = source[m];
            source[m] = temp2;

            QuickSort(source, start, m - 1);
            QuickSort(source, m + 1, end);


            
        }
    }
}
