using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    public static class Q20ContainedInterval
    {

        public static IntervalPair FindContainedIntervalPair(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count <= 1)
                return null;

            QuickSortIntervals(intervals, 0, intervals.Count - 1);

            float previousTo = intervals[0].To;
            for (int i = 1; i < intervals.Count; i++)
            {
                float currentTo = intervals[i].To;
                if (currentTo <= previousTo)
                {
                    return new IntervalPair() { Interval1 = intervals[i - 1], Interval2 = intervals[i] };
                }

                previousTo = currentTo;
            }
            return null;

        }

        private static void QuickSortIntervals(IList<Interval> intervals, int start, int end)
        {
            if (start >= end)
                return;

            Interval temp;

            //partition
            int partitionSize = 1;
            for (int i = start + 1; i <= end; i++)
            {
                if (intervals[i].From <= intervals[start].From)
                {
                    int newPos = start + partitionSize;
                    if (i != newPos)
                    {
                        temp = intervals[newPos];
                        intervals[newPos] = intervals[i];
                        intervals[i] = temp;
                    }
                    partitionSize++;
                }
            }

            int m = start + partitionSize - 1;
            temp = intervals[start];
            intervals[start] = intervals[m];
            intervals[m] = temp;

            QuickSortIntervals(intervals, start, m - 1);
            QuickSortIntervals(intervals, m + 1, end);

        }

        public class IntervalPair
        {
            public Interval Interval1
            {
                get;
                set;
            }

            public Interval Interval2
            {
                get;
                set;
            }
        }

        public class Interval
        {
            public Interval(float from, float to)
            {
                if (from > to)
                    throw new ArgumentException();

                this.from = from;
                this.to = to;

            }

            private float from;
            private float to;

            public float From
            {
                get
                {
                    return from;
                }
            }

            public float To
            {
                get
                {
                    return to;
                }
            }
        }
    }
}
