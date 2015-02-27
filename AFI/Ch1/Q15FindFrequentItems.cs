using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Find all integers in an array of n elements
    /// that occur MORE THAN n/k times.
    /// You can read the array twice.
    /// 
    /// c > n/k => c - 1 > (n-k)/k
    /// </summary>
    public static class Q15FindFrequentItems
    {
        public static IList<int> FrequentItems(IList<int> integers, int k)
        {
            var candidates = new Dictionary<int, int>(k);
            for (int i = 0; i < integers.Count; i++) //keep removing k distinct items
            {
                if (candidates.ContainsKey(integers[i]))
                    candidates[integers[i]]++;
                else
                    candidates[integers[i]] = 1;

                if (candidates.Count == k) //reduce size by at least 1
                {
                    int min = -1;
                    foreach (var count in candidates.Values)
                    {
                        if (min == -1)
                            min = count;
                        else if (count < min)
                            min = count;
                    }

                    foreach (var key in candidates.Keys.ToArray())
                    {
                        if (candidates[key] == min)
                            candidates.Remove(key);
                        else
                            candidates[key] -= min;
                    }
                }
            }

            //return those meet criteria
            foreach (var key in candidates.Keys.ToArray())
                candidates[key] = 0;

            for (int i = 0; i < integers.Count; i++)
            {
                if (candidates.ContainsKey(integers[i]))
                {
                    candidates[integers[i]]++;
                }
            }

            double boundary = (double)integers.Count / k;
            return candidates.Where(pair => pair.Value > boundary).Select(pair => pair.Key).ToArray();

        }
    }
}
