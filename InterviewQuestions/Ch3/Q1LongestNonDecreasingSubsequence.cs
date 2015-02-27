using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch3
{
    /// <summary>
    /// Find the longest non-decreasing subsequence of <paramref name="sequence"/>.
    /// </summary>
    public static class Q1LongestNonDecreasingSubsequence
    {
        /// <summary>
        /// Bottom up DP.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns>Returns the indices of the longest non-decreasing subsequence in order.</returns>
        public static IList<int[]> Find(int[] sequence)
        {
            if (sequence == null || sequence.Length == 0)
                return null;

            var from = new LinkedList<int>[sequence.Length]; //previous item to achieve maxLength
            var maxLength = new int[sequence.Length]; //maxLength = previous maxLength + 1
            int globalMaxLength = 1;

            maxLength[0] = 1;
            from[0] = new LinkedList<int>();//empty

            for (int i = 1; i < sequence.Length; i++)
            {
                from[i] = new LinkedList<int>(); //default when i is the strictly smallest element
                maxLength[i] = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (sequence[i] >= sequence[j] && maxLength[j] >= maxLength[i])
                    {
                        if (from[i].First != null && maxLength[from[i].First.Value] < maxLength[j])
                        {
                            from[i].Clear();
                        }
                        from[i].AddFirst(j);
                        maxLength[i] = maxLength[j] + 1;
                        if (maxLength[i] > globalMaxLength)
                        {
                            globalMaxLength = maxLength[i];
                        }
                    }
                }
            }

            PathTracer tracer = new PathTracer(from, globalMaxLength);
            for (int i = 0; i < sequence.Length; i++)
            {
                if (maxLength[i] == globalMaxLength)
                {
                    tracer.Trace(i);
                }
            }
            return tracer.Result;
        }

        private class PathTracer
        {
            private LinkedList<int>[] nodes;
            private int pathLength;
            private List<int[]> result;

            public PathTracer(LinkedList<int>[] nodes, int pathLength)
            {
                this.nodes = nodes;
                this.pathLength = pathLength;
                result = new List<int[]>();
            }

            public void Trace(int i)
            {
                Trace(i, 0, new int[pathLength]);
            }

            private void Trace(int nodeIndex, int pathPosition, int[] path)
            {
                if (pathPosition == pathLength)
                {
                    result.Add(path);
                    return;
                }

                var child = nodes[nodeIndex].First;
                if (child == null)
                {
                    path[this.pathLength - 1 - pathPosition] = nodeIndex;
                    result.Add(path);
                    return;
                }

                do
                {
                    int[] newPath;
                    if (child == nodes[nodeIndex].First)
                    {
                        newPath = path;
                    }
                    else
                    {
                        newPath = new int[this.pathLength];
                        for (int i = 0; i < pathPosition; i++)
                        {
                            int index = this.pathLength - 1 - i;
                            newPath[index] = path[index];
                        }
                    }
                    newPath[this.pathLength - 1 - pathPosition] = nodeIndex;
                    Trace(child.Value, pathPosition + 1, newPath);

                    child = child.Next;
                } while (child != null);

            }

            public List<int[]> Result
            {
                get
                {
                    return result;
                }
            }
        }







    }
}
