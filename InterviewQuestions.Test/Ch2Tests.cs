using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewQuestions.Ch2;
using System.Collections.Generic;
using System.Linq;

namespace InterviewQuestions.Test
{
    [TestClass]
    public class Ch2Tests
    {
        [TestMethod]
        public void TestQ3FindMinMax()
        {
            Q3FindMinMax.MoveMinMax(null);

            int[] list = new int[] { };
            Q3FindMinMax.MoveMinMax(list);

            list = new int[] { 1, 1000 };
            Q3FindMinMax.MoveMinMax(list);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(1000, list[list.Length - 1]);

            list = new int[] { 1000, 1 };
            Q3FindMinMax.MoveMinMax(list);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(1000, list[list.Length - 1]);

            list = new int[] { 1, 1000, 500 };
            Q3FindMinMax.MoveMinMax(list);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(1000, list[list.Length - 1]);

            list = new int[] { 500, 1, 1000 };
            Q3FindMinMax.MoveMinMax(list);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(1000, list[list.Length - 1]);

            list = new int[] { 15, 500, 1, 1000 };
            Q3FindMinMax.MoveMinMax(list);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(1000, list[list.Length - 1]);

            list = new int[] { 15, 500, 1, 1000, 9 };
            Q3FindMinMax.MoveMinMax(list);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(1000, list[list.Length - 1]);

            list = new int[] { 15, 500, 100, 1000, 9, 1 };
            Q3FindMinMax.MoveMinMax(list);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(1000, list[list.Length - 1]);

            list = new int[] { 15, 500, 100, 1000, 9, 13, 1 };
            Q3FindMinMax.MoveMinMax(list);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(1000, list[list.Length - 1]);
        }


        [TestMethod]
        public void TestQ12RunningMean()
        {
            var list = new float[] { };
            var result = Q12RunningMean.CalculateRunningMean(list, 1);
            Assert.AreEqual(null, result);

            list = new float[] { 1 };
            result = Q12RunningMean.CalculateRunningMean(list, 1);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0]);

            list = new float[] { 1, 5, 3 };
            result = Q12RunningMean.CalculateRunningMean(list, 2);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(3, result[0]);
            Assert.AreEqual(4, result[1]);

            list = new float[] { 1, 5, 3, 9 };
            result = Q12RunningMean.CalculateRunningMean(list, 3);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual((1 + 5 + 3) / 3.0f, result[0]);
            Assert.AreEqual((5 + 3 + 9) / 3.0f, result[1]);


        }

        [TestMethod]
        public void TestQ9RemoveDuplicateFirstnames()
        {
            var result = Q9RemoveDuplicateFirstnames.GetDistinct(new int[] { 5, 4, 3, 3, 2, 5, 1 });
            Assert.AreEqual(5, result.Count);

            var source = new List<int>() { 9, 8, 7, 8, 6, 5, 5, 3, 9 };
            Q9RemoveDuplicateFirstnames.RetainDistinct(source);
            Assert.AreEqual(6, source.Count);

            source = new List<int>() { 9,9,9,9,9 };
            Q9RemoveDuplicateFirstnames.RetainDistinct(source);
            Assert.AreEqual(1, source.Count);

            source = new List<int>() { 6,5,4,3,2,1 };
            Q9RemoveDuplicateFirstnames.RetainDistinct(source);
            Assert.AreEqual(6, source.Count);

        }

        [TestMethod]
        public void TestQ10MultiwayMerge()
        {
            var result = Q10MultiwayMerge.Merge(new List<IList<int>>() { new int[]{}, new int[]{} }).ToList();
            Assert.AreEqual(0, result.Count);

            result = Q10MultiwayMerge.Merge(new List<IList<int>>() { new int[] {1,2,3 }, new int[] { 4} }).ToList();
            TestHelper.IsSorted(result);
            Assert.AreEqual(4, result.Count);

            result = Q10MultiwayMerge.Merge(new List<IList<int>>() { new int[] { 1, 2, 3, 7 }, new int[] { 1, 3, 4 } }).ToList();
            TestHelper.IsSorted(result);
            Assert.AreEqual(7, result.Count);
            
        }
    }
}
