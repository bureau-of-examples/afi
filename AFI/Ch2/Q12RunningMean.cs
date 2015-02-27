using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch2
{
    public static class Q12RunningMean
    {
        public static IList<float> CalculateRunningMean(IList<float> source, int windowSize)
        {
            if (windowSize <= 0 || source == null || source.Count < windowSize)
                return null;

            IList<float> result = new List<float>();

            //init
            float sum = 0;
            for (int i = 0; i < windowSize - 1; i++)
            {
                sum += source[i];
            }

            for (int i = windowSize - 1; i < source.Count; i++)
            {
                sum += source[i];
                result.Add(sum/windowSize);
                sum -= source[i-windowSize+1];
            }
            return result;
        }
    }
}
