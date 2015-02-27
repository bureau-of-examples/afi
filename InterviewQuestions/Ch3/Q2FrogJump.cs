using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch3
{
    /// <summary>
    /// There is a river n meters wide. At every meter there may or may not be a stone.
    /// A frog can jump x-1 to x+1 meters if the last jump is x meter.
    /// The first jump is 1 meter.
    /// Given a river, check if the frog can cross.
    /// </summary>
    public static class Q2FrogJump
    {
        public static bool CanPass(int[] steps)
        {
            if (steps == null)
                throw new ArgumentException();

            if (steps.Length == 0)
                return true;

            if (steps[0] != 1)
                return false;

            return CanPass(1, steps, 1);
        }

        private static bool CanPass(int lastStep, int[] steps, int pos)
        {
            if (pos >= steps.Length)
                return true;

            if (steps[pos] <= lastStep + 1 && steps[pos] >= lastStep - 1)
            {
                return CanPass(steps[pos], steps, pos + 1);
            }
            else
                return false;
        }
    }
}
