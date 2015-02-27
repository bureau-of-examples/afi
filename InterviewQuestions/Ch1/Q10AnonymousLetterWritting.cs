using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Check if you can use letters in m to write l.
    /// </summary>
    public static class Q10AnonymousLetterWritting
    {
        public static bool CanWriteLfromM(string l, string m)
        {
            Dictionary<char, int> letterCounts = new Dictionary<char, int>();
            foreach (char c in m)
            {
                if (letterCounts.ContainsKey(c))
                {
                    letterCounts[c]++;
                }
                else
                {
                    letterCounts[c] = 1;
                }
            }

            foreach (char c in l)
            {
                if (!letterCounts.ContainsKey(c) || letterCounts[c] == 0)
                    return false;

                letterCounts[c]--;
            }

            return true;
        }
    }
}
