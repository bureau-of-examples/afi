using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewQuestions.Ch3;

namespace InterviewQuestions.Test
{
    [TestClass]
    public class Ch3Tests
    {
        [TestMethod]
        public void TestQ1LongestNonDecreasingSubsequence()
        {
            var result = Q1LongestNonDecreasingSubsequence.Find(new int[] { });
            Assert.IsNull(result);

            result = Q1LongestNonDecreasingSubsequence.Find(new int[] { 1 });
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(0, result[0][0]);

            result = Q1LongestNonDecreasingSubsequence.Find(new int[] { 1, 2, 3 });
            Assert.AreEqual(3, result[0].Length);
            Assert.IsTrue(TestHelper.AreEqual(result[0], new int[] { 0, 1, 2 }));

            result = Q1LongestNonDecreasingSubsequence.Find(new int[] { 1, 2, 3, 1 });
            Assert.AreEqual(3, result[0].Length);
            Assert.IsTrue(TestHelper.AreEqual(result[0], new int[] { 0, 1, 2 }));

            result = Q1LongestNonDecreasingSubsequence.Find(new int[] { 9, 1, 2, 3, 1 });
            Assert.AreEqual(3, result[0].Length);
            Assert.IsTrue(TestHelper.AreEqual(result[0], new int[] { 1, 2, 3 }));

            //todo more

        }
    }
}
