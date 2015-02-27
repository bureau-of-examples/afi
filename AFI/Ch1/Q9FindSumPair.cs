using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Find the first pair of integers whose sum is sum.
    /// </summary>
    public class Q9FindSumPair
    {
        public static KeyValuePair<int, int> SumPair(IList<int> integers, int sum)
        {
            var scanned = new Dictionary<int, int>(integers.Count);
            for (int i = 0; i < integers.Count; i++)
            {
                int other = sum - integers[i];
                scanned[integers[i]] = i;
                if (scanned.ContainsKey(other))
                {
                    return new KeyValuePair<int, int>(scanned[other], i);
                }
            }

            return new KeyValuePair<int, int>(-1, -1);
        }
    }
}
