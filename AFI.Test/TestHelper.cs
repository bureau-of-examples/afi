using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Test
{
    public static class TestHelper
    {
        public static bool AreEqual<T>(IList<T> list1, IList<T> list2)
        {
            if (list1 == null && list2 != null)
                return false;

            if (list1 != null && list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (!Object.Equals(list1[i], list2[i]))
                    return false;
            }

            return true;
        }

        public static bool IsSorted(IList<int> source)
        {
            for (int i = 1; i < source.Count; i++)
            {
                if (source[i - 1] > source[i])
                    return false;
            }
            return true;
        }
    }
}
