using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// More than 1/2 items in array is the same item. Find that item.
    /// </summary>
    public static class Q14FindMajorityItem
    {
        public static int MajorityItem(IList<int> integers)
        {
            if (integers.Count < 2)
                return integers[0];

            int? candidate = null;
            int candidateCount = 0;

            for(int i=0; i<integers.Count;i++)
            {
                if (candidateCount == 0)
                {
                    candidate = integers[i];
                    candidateCount = 1;
                }
                else if (candidate == integers[i])
                    candidateCount++;
                else
                    candidateCount--;
            }

            return candidate.Value;
        }
    }
}
