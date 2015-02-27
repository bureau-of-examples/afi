using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Find the floor of the square root of an unsigned integer.
    /// </summary>
    public static class Q1FindSquareRoot
    {
        public static uint FloorOfSquare(uint a)
        {
            //binary search in [0, min(a, 65535)]
            //because floor(sqrt(unit.MaxValue)) <= 65535
            uint start = 0;
            uint end = ushort.MaxValue;

            while (start <= end)
            {
                uint m = start + (end - start) / 2;//lower median of [start, end]
                uint square = m * m;
                if (square == a)
                    return m;
                if (square < a)
                    start = m + 1;
                else
                    end = m - 1;
            }

            return end;//sqrt(a) in (end, start), start = end + 1
        }
    }
}
