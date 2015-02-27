using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Given a set of lines on a 2d plane, check if they interct in a rectangle.
    /// For the sake of simplicity assume the rectangle is aligned with the axises.
    /// The answer to this question is actually for a different problem..which is
    /// Given a set of straight lines that intersect both x=0 and x=1, check if they intersect.
    /// </summary>
    public static class Q19LinesInterctInRectangle
    {

        /// <summary>
        /// Test if a set of lines intersect between x = 0 and x = 1.
        /// All lines given must intersect x = 0 and x = 1.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public static bool IntersectBetweenX01(IList<LineF> lines)
        {
            if (lines == null || lines.Count <= 1) //trivial cases
                return false;

            IList<LineSlopeYIntercept> items = new List<LineSlopeYIntercept>();
            for (int i = 0; i < lines.Count; i++)
            {
                items.Add(new LineSlopeYIntercept(lines[i]));
            }

            QuickSOrtYIntercept(items, 0, items.Count - 1);
            float previousSlope = items[0].Slope;
            float previousYIntercept = items[0].YIntercept;

            //check neibourghing lines
            for (int i = 1; i < items.Count; i++)
            {
                float currentSlope = items[i].Slope;
                float currentYIntercept = items[i].YIntercept;
                if (currentSlope + currentYIntercept <= previousSlope + previousYIntercept)
                    return true;

                previousSlope = currentSlope;
                previousYIntercept = currentYIntercept;
            }

            return false;
        }

        private static void QuickSOrtYIntercept(IList<LineSlopeYIntercept> items, int start, int end)
        {
            if (start >= end)
                return;

            //partition using the lower middle element
            int m = start + (end - start) / 2;
            var temp = items[start]; //swap
            items[start] = items[m];
            items[m] = temp;

            //partition
            int partitionSize = 1;
            for (int i = start + 1; i <= end; i++)
            {
                if (items[i].YIntercept <= items[start].YIntercept)
                {
                    int nextPos = start + partitionSize;
                    if (i != nextPos)
                    { //swap
                        temp = items[nextPos];
                        items[nextPos] = items[i];
                        items[i] = temp;
                    }
                    partitionSize++;
                }
            }
            m = start + partitionSize - 1;//partitioning element new location
            temp = items[start]; //swap
            items[start] = items[m];
            items[m] = temp;

            QuickSOrtYIntercept(items, start, m - 1);
            QuickSOrtYIntercept(items, m + 1, end);
        }

        public struct PointF : IEquatable<PointF>
        {
            private float x, y;

            public PointF(float x, float y)
            {
                this.x = x;
                this.y = y;
            }

            public float X
            {
                get
                {
                    return x;
                }
            }

            public float Y
            {
                get
                {
                    return y;
                }
            }



            public bool Equals(PointF other)
            {
                return this.x == other.x && this.y == other.y;
            }

            public override bool Equals(object obj)
            {
                if (obj is PointF)
                {
                    return Equals((PointF)obj);
                }
                return false;
            }

            public override int GetHashCode()
            {
                return this.x.GetHashCode() ^ this.y.GetHashCode();
            }
        }

        public class LineF
        {
            public LineF(PointF a, PointF b)
            {
                this.PointA = a;
                this.PointB = b;
            }

            public PointF PointA
            {
                get;
                private set;
            }

            public PointF PointB
            {
                get;
                private set;
            }

            //equals ignored

            public float Slope
            {
                get
                {
                    float deltaX = PointB.X - PointA.X;
                    if (deltaX == 0)
                        return float.PositiveInfinity;//is vertical

                    float deltaY = PointB.Y - PointA.Y;

                    return deltaY / deltaX;
                }
            }

            public static float GetYIntercept(float slope, PointF p)
            {
                if (float.IsInfinity(slope))
                    return float.NaN;

                return p.Y - p.X * slope;
            }
        }

        public class RectangleF
        {
            public RectangleF(PointF leftTop, PointF rightBottom)
            {
                this.LeftTop = leftTop;
                this.RightBottom = rightBottom;
            }

            public PointF LeftTop
            {
                get;
                private set;
            }

            public PointF RightBottom
            {
                get;
                private set;
            }

            /// <summary>
            /// Returns null if the line does not intercept this rectangle; else
            /// if the line is vertical, returns the top intercept + bottom intercept; else
            /// returns p1 and p2 where: 
            /// p1 is the intersection betwen the line and the rectangle's extended left edge 
            /// p2 is the first point on the rectangle that you meet along the ray from p1 in the direction of the line.
            /// All points in the returned line are transformed so that the bottom left of the rectangle is the origin.
            /// </summary>
            /// <param name="line"></param>
            /// <returns></returns>
            private LineF InterceptYTransform(LineF line)
            {
                //line equation:
                //(y-y1)(x2-x1)=(x-x1)(y2-y1)
                float deltaX = line.PointB.X - line.PointA.X;
                float deltaY = line.PointB.Y - line.PointA.Y;

                if (deltaX == 0)//if is vertical
                {
                    if (line.PointA.X >= this.LeftTop.X && line.PointA.X <= this.RightBottom.X)//intercepts the rect
                    {
                        float left = line.PointA.X - this.LeftTop.X;
                        return new LineF(new PointF(left, this.LeftTop.Y - this.RightBottom.Y), new PointF(left, 0));//top down
                    }

                    return null;
                }

                //p1 is 0, interceptY
                float interceptY = (this.LeftTop.X - line.PointA.X) * deltaY / deltaX + line.PointA.Y - RightBottom.Y;

                //try to find p2 in the order of top down right

                if (deltaY != 0) //not horizontal
                {
                    //top
                    float interceptX = (this.LeftTop.Y - line.PointA.Y) * deltaX / deltaY + line.PointA.X;
                    if (interceptX >= this.LeftTop.X && interceptX <= this.RightBottom.X)
                    {
                        float left = interceptX - this.LeftTop.X;
                        return new LineF(new PointF(0, interceptY), new PointF(interceptX, this.LeftTop.Y));
                    }

                    //bottom
                    interceptX = (this.RightBottom.Y - line.PointA.Y) * deltaX / deltaY + line.PointA.X;
                    if (interceptX >= this.LeftTop.X && interceptX <= this.RightBottom.X)
                    {
                        float left = interceptX - this.LeftTop.X;
                        return new LineF(new PointF(0, interceptY), new PointF(interceptX, this.RightBottom.Y));
                    }
                }

                //right
                float interceptY2 = (this.RightBottom.X - line.PointA.X) * deltaY / deltaX + line.PointA.Y - RightBottom.Y;
                if (interceptY2 >= this.RightBottom.Y && interceptY2 <= this.LeftTop.Y)
                {
                    return new LineF(new PointF(0, interceptY), new PointF(this.RightBottom.X - this.LeftTop.X, interceptY2));
                }

                return null;

            }

            /// <summary>
            /// Get lines that intersect this rectangle from a set of lines.
            /// The intersecting lines will be transformed according to the description of InterceptYTransform(LineF line).
            /// </summary>
            /// <param name="lines"></param>
            /// <returns></returns>
            public IList<LineSlopeYIntercept> InterceptYTransform(IList<LineF> lines)
            {
                var items = new List<LineSlopeYIntercept>();

                if (lines == null || lines.Count <= 1) //trivial cases
                    return items;

                for (int i = 0; i < lines.Count; i++)
                {
                    var intercepts = this.InterceptYTransform(lines[i]); //get the normalized clip of the line in the rectangle
                    if (intercepts != null) //get null if the line does not intercept the rectangle
                        items.Add(new LineSlopeYIntercept(intercepts));
                }

                return items;
            }

            //equals ignored
        }

        public class LineSlopeYIntercept
        {
            public LineSlopeYIntercept(LineF line)
            {
                this.Line = line;
                this.Slope = this.Line.Slope;
                this.YIntercept = LineF.GetYIntercept(this.Slope, this.Line.PointA);
            }

            public LineF Line
            {
                get;
                private set;
            }

            public float Slope
            {
                get;
                private set;
            }

            public float YIntercept
            {
                get;
                private set;
            }
        }
    }
}
