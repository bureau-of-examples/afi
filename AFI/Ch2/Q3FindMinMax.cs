using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch2
{
    public static class Q3FindMinMax
    {
        /// <summary>
        /// Find both min and max with no more than 3N/2-1 comparisions.
        /// </summary>
        /// <param name="integers"></param>
        public static void MoveMinMax(IList<int> integers)
        {
            if (integers == null || integers.Count <= 1)
                return;

            int segmentSize = 1;//segment size = 1, 2, 4, 8...
            while (segmentSize < integers.Count)
            {
                int segmentCount = (integers.Count - 1) / segmentSize + 1;//number of segments in the list, the last one might be incomplete
                for (int i = 0; i < segmentCount - 1; i+=2)//dont start on the last segment so that i is always a complete segment and there is possibly incomeplete subsequent segment i+1
                {   //for each segment, min is the first item and max the last
                    int first1 = i * segmentSize;
                    int first2 = first1 + segmentSize;

                    if (integers[first1] > integers[first2])//put the smaller min in the start of first segment (effectively merge the 2 neighbouring segments)
                    {//swap 
                        var temp = integers[first1];
                        integers[first1] = integers[first2];
                        integers[first2] = temp;
                    }

                    if (segmentSize == 1) //no need to process max
                        continue;

                    int last1 = first2 - 1;
                    int last2 = first2 + segmentSize - 1;
                    if (last2 >= integers.Count)
                        last2 = integers.Count - 1;

                    if (integers[last1] > integers[last2])
                    {//swap 
                        var temp = integers[last1];
                        integers[last1] = integers[last2];
                        integers[last2] = temp;
                    }

                }
                segmentSize <<= 1;
            }


        }
    }
}
