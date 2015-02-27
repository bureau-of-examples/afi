using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Find a missing value in 300 million 32 bit integers. You only have 2m memory.
    /// </summary>
    public static class Q6FindMissingNumberIn300M
    {
        //Allocate an int array of length 65536 = 256k
        //Scan the file once, if a value's first 16 bits is i (unsigned short), then array[i]++
        //if a bucket has a count of less than 65536, than bucket has a missing value
        //use the array as bit map to find which value in that bucket is not present.
        
    }
}
