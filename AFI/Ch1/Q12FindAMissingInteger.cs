using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Find any integer that is not in an integer list.
    /// </summary>
    public static class Q12FindAMissingInteger
    {
        public static int MissingInteger(IList<int> integers)
        {
            BitArray bitArray = new BitArray(integers.Count + 1);
            for (int i = 0; i < integers.Count; i++)
            {
                bitArray[integers[i] % bitArray.Count] = true;
            }

            for (int i = 0; i < bitArray.Count; i++)
            {
                if (!bitArray[i])
                    return i;
            }
            throw new ArgumentException(); //no missing
        }
    }
}
