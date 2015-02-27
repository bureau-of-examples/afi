using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Find the minimum battery capacity needed to complete the route.
    /// </summary>
    public static class Q13RobotBattery
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="routeHeights">The height coordinate of points in route.</param>
        /// <returns></returns>
        public static int CalculateCapacity(IList<int> routeHeights)
        {
            if (routeHeights.Count < 2)
                return 0;

            int minHeightB4i = routeHeights[0];
            int result = 0;

            for (int i = 1; i < routeHeights.Count; i++)
            {
                if (routeHeights[i] - minHeightB4i > result)
                {
                    result = routeHeights[i] - minHeightB4i;
                }

                if (routeHeights[i] < minHeightB4i)
                {
                    minHeightB4i = routeHeights[i];
                }
            }
            return result;
        }
    }
}
