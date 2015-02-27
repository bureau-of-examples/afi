using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewQuestions.Ch1;
using System.Collections.Generic;

namespace InterviewQuestions.Test
{
    [TestClass]
    public class Ch1Tests
    {
        [TestMethod]
        public void TestQ1FindSquareRoot()
        {
            for (uint i = 0; i < 10; i++)
            {
                uint result = Q1FindSquareRoot.FloorOfSquare(i);
                uint answer = (uint)Math.Sqrt(i);
                Assert.AreEqual(answer, result);
            }

            for (uint i = uint.MaxValue; i > uint.MaxValue - 10; i--)
            {
                uint result = Q1FindSquareRoot.FloorOfSquare(i);
                uint answer = (uint)Math.Sqrt(i);
                Assert.AreEqual(answer, result);
            }
        }

        [TestMethod]
        public void TestQ2FindFirstIndex()
        {
            int result = Q2FindFirstIndex.FirstIndex(new int[] { }, 1);
            Assert.AreEqual(-1, result);

            result = Q2FindFirstIndex.FirstIndex(new int[] { 9 }, 1);
            Assert.AreEqual(-1, result);

            result = Q2FindFirstIndex.FirstIndex(new int[] { 9 }, 9);
            Assert.AreEqual(0, result);

            result = Q2FindFirstIndex.FirstIndex(new int[] { 9, 9 }, 9);
            Assert.AreEqual(0, result);

            result = Q2FindFirstIndex.FirstIndex(new int[] { 9, 9, 9 }, 9);
            Assert.AreEqual(0, result);

            result = Q2FindFirstIndex.FirstIndex(new int[] { 8, 9, 9, 9 }, 9);
            Assert.AreEqual(1, result);


            result = Q2FindFirstIndex.FirstIndex(new int[] { 7, 8, 9, 9, 9 }, 9);
            Assert.AreEqual(2, result);


            result = Q2FindFirstIndex.FirstIndex(new int[] { 7, 8, 8, 8, 8, 8, 9, 9, 9, 10 }, 9);
            Assert.AreEqual(6, result);

        }

        [TestMethod]
        public void TestQ3FirstLargerThan()
        {
            int result = Q3FindFirstLargerThan.FirstLargerThan(new int[] { }, 9);
            Assert.AreEqual(-1, result);

            result = Q3FindFirstLargerThan.FirstLargerThan(new int[] { 10 }, 9);
            Assert.AreEqual(0, result);

            result = Q3FindFirstLargerThan.FirstLargerThan(new int[] { 9, 10 }, 9);
            Assert.AreEqual(1, result);

            result = Q3FindFirstLargerThan.FirstLargerThan(new int[] { 9, 9, 10 }, 9);
            Assert.AreEqual(2, result);

            result = Q3FindFirstLargerThan.FirstLargerThan(new int[] { 9, 9, 9, 9 }, 9);
            Assert.AreEqual(-1, result);

            result = Q3FindFirstLargerThan.FirstLargerThan(new int[] { 10, 11, 12, 13, 14 }, 9);
            Assert.AreEqual(0, result);

            result = Q3FindFirstLargerThan.FirstLargerThan(new int[] { 7, 8, 9, 9, 19 }, 8);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestQ4FindValueEqualsToIndex()
        {
            int result = Q4FindValueEqualsToIndex.ValueEqualsToIndex(new int[] { });
            Assert.AreEqual(-1, result);

            result = Q4FindValueEqualsToIndex.ValueEqualsToIndex(new int[] { 9 });
            Assert.AreEqual(-1, result);

            result = Q4FindValueEqualsToIndex.ValueEqualsToIndex(new int[] { -100, 1000, 2000 });
            Assert.AreEqual(-1, result);

            result = Q4FindValueEqualsToIndex.ValueEqualsToIndex(new int[] { -100, 0, 2, 9 });
            Assert.AreEqual(2, result);

            result = Q4FindValueEqualsToIndex.ValueEqualsToIndex(new int[] { -5, 1, 3, 4, 5 });
            Assert.AreEqual(1, result);

            result = Q4FindValueEqualsToIndex.ValueEqualsToIndex(new int[] { -5, 1, 2, 3, 5, 10 });
            Assert.IsTrue((new List<int>() { 1, 2, 3 }).Contains(result));

        }

        [TestMethod]
        public void TestQ5FindIndexLengthUnknown()
        {
            int result = Q5FindIndexLengthUnknown.IndexLengthUnknown(new int[] { }, 9);
            Assert.AreEqual(-1, result);

            result = Q5FindIndexLengthUnknown.IndexLengthUnknown(new int[] { 9 }, 9);
            Assert.AreEqual(0, result);

            result = Q5FindIndexLengthUnknown.IndexLengthUnknown(new int[] { 8, 9, 9 }, 9);
            Assert.AreEqual(1, result);

            result = Q5FindIndexLengthUnknown.IndexLengthUnknown(new int[] { 7, 8, 9, 10 }, 9);
            Assert.AreEqual(2, result);

            result = Q5FindIndexLengthUnknown.IndexLengthUnknown(new int[] { 7, 8, 9, 10 }, 5);
            Assert.AreEqual(-1, result);

            result = Q5FindIndexLengthUnknown.IndexLengthUnknown(new int[] { 7, 8, 9, 10 }, 15);
            Assert.AreEqual(-1, result);

            result = Q5FindIndexLengthUnknown.IndexLengthUnknown(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5);
            Assert.AreEqual(4, result);

            result = Q5FindIndexLengthUnknown.IndexLengthUnknown(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 11);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestQ7IntersectNoDuplicate()
        {
            var tests = new[] { 
                new {L1=new int[]{}, L2=new int[]{}, Result = new int[]{}},
                new {L1=new int[]{1}, L2=new int[]{2}, Result = new int[]{}},
                new {L1=new int[]{1}, L2=new int[]{1}, Result = new int[]{1}},
                new {L1=new int[]{}, L2=new int[]{1,2,3}, Result = new int[]{}},
                new {L1=new int[]{-8,0,1,2,3}, L2=new int[]{-10,-6,1,2,3,10}, Result = new int[]{1,2,3}},
                new {L1=new int[]{-8,0,0,1,2,3,11,11}, L2=new int[]{-10,-6,1,2,2,3,10}, Result = new int[]{1,2,3}}
            };

            foreach (var testCase in tests)
            {
                var result = Q7IntersectNoDuplicate.IntersectBin(testCase.L1, testCase.L2);
                Assert.IsTrue(TestHelper.AreEqual(testCase.Result, result));
            }

            foreach (var testCase in tests)
            {
                var result = Q7IntersectNoDuplicate.IntersectMerge(testCase.L1, testCase.L2);
                Assert.IsTrue(TestHelper.AreEqual(testCase.Result, result));
            }
        }

        [TestMethod]
        public void TestQ8GroupAnagrams()
        {
            var result = Q8GroupAnagrams.GroupAnagrams(new String[] { });
            Assert.AreEqual(0, result.Count);

            result = Q8GroupAnagrams.GroupAnagrams(new String[] { string.Empty });
            Assert.AreEqual(1, result.Count);

            result = Q8GroupAnagrams.GroupAnagrams(new String[] { "abc", "bca", "cba" });
            Assert.AreEqual(1, result.Count);

            result = Q8GroupAnagrams.GroupAnagrams(new String[] { "abc", "bca", "cba", "ae", "ea" });
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result["abc"].Contains("bca"));
            Assert.IsTrue(result["abc"].Contains("abc"));
            Assert.IsTrue(result["abc"].Contains("cba"));

            result = Q8GroupAnagrams.GroupAnagrams(new String[] { "abc", "bca", "cba", "bad", "dba" });
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result["abd"].Contains("dba"));
            Assert.IsTrue(result["abd"].Contains("bad"));
        }

        [TestMethod]
        public void TestQ9FindSumPair()
        {
            KeyValuePair<int, int> notFound = new KeyValuePair<int, int>(-1, -1);
            var result = Q9FindSumPair.SumPair(new int[] { }, 10);
            Assert.AreEqual(notFound, result);

            result = Q9FindSumPair.SumPair(new int[] { 2, 3, 6 }, 10);
            Assert.AreEqual(notFound, result);

            result = Q9FindSumPair.SumPair(new int[] { 5 }, 10);
            Assert.AreEqual(new KeyValuePair<int, int>(0, 0), result);

            result = Q9FindSumPair.SumPair(new int[] { 5, 8, 9, 17 }, 14);
            Assert.AreEqual(new KeyValuePair<int, int>(0, 2), result);

            result = Q9FindSumPair.SumPair(new int[] { 5, 8, 9, 17, 2, -8 }, -3);
            Assert.AreEqual(new KeyValuePair<int, int>(0, 5), result);

            result = Q9FindSumPair.SumPair(new int[] { 5, 8, -9, -2, 17, 2, 10, -11 }, -11);
            Assert.AreEqual(new KeyValuePair<int, int>(2, 3), result);
        }

        [TestMethod]
        public void TestQ10AnonymousLetterWritting()
        {
            var result = Q10AnonymousLetterWritting.CanWriteLfromM("", "");
            Assert.IsTrue(result);

            result = Q10AnonymousLetterWritting.CanWriteLfromM("", "abc");
            Assert.IsTrue(result);

            result = Q10AnonymousLetterWritting.CanWriteLfromM("aac", "badacba");
            Assert.IsTrue(result);

            result = Q10AnonymousLetterWritting.CanWriteLfromM("aace", "badacba");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestQ11PairingUsers()
        {
            List<Q11PairingUsers.User> users = new List<Q11PairingUsers.User>();
            users.Add(Q11PairingUsers.User.Create(new String[] { }));
            users.Add(Q11PairingUsers.User.Create(new String[] { }));
            var result = Q11PairingUsers.PairUsersExact(users);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(Object.ReferenceEquals(users[0], result[0].User1));
            Assert.IsTrue(Object.ReferenceEquals(users[1], result[0].User2));

            users.Clear();
            users.Add(Q11PairingUsers.User.Create(new String[] { "abc", "def", "xyz" }));
            users.Add(Q11PairingUsers.User.Create(new String[] { "xyz", "abc", "def" }));
            users.Add(Q11PairingUsers.User.Create(new String[] { "aab", "d" }));
            users.Add(Q11PairingUsers.User.Create(new String[] { "zzz", "x" }));
            result = Q11PairingUsers.PairUsersExact(users);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(Object.ReferenceEquals(users[0], result[0].User1));
            Assert.IsTrue(Object.ReferenceEquals(users[1], result[0].User2));


            users.Add(Q11PairingUsers.User.Create(new String[] { "x", "zzz" }));
            result = Q11PairingUsers.PairUsersExact(users);
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(Object.ReferenceEquals(users[3], result[1].User1));
            Assert.IsTrue(Object.ReferenceEquals(users[4], result[1].User2));

        }

        [TestMethod]
        public void TestQ12FindAMissingInteger()
        {
            List<int> integers = new List<int>();
            var result = Q12FindAMissingInteger.MissingInteger(integers);
            Assert.IsFalse(integers.Contains(result));

            integers = new List<int>() { 9, 17, 100 };
            result = Q12FindAMissingInteger.MissingInteger(integers);
            Assert.IsFalse(integers.Contains(result));

            integers = new List<int>() { 9, 17, 9 };
            result = Q12FindAMissingInteger.MissingInteger(integers);
            Assert.IsFalse(integers.Contains(result));

            integers = new List<int>() { 6, 5, 0, 12, 7, 108 };
            result = Q12FindAMissingInteger.MissingInteger(integers);
            Assert.IsFalse(integers.Contains(result));
        }

        [TestMethod]
        public void TestQ13RobotBattery()
        {
            var result = Q13RobotBattery.CalculateCapacity(new int[] { 1 });
            Assert.AreEqual(0, result);

            result = Q13RobotBattery.CalculateCapacity(new int[] { 1, 5, 10 });
            Assert.AreEqual(9, result);

            result = Q13RobotBattery.CalculateCapacity(new int[] { 10, 5, 1 });
            Assert.AreEqual(0, result);

            result = Q13RobotBattery.CalculateCapacity(new int[] { 1, 5, -10, 8, -2, 9, 3 });
            Assert.AreEqual(19, result);
        }

        [TestMethod]
        public void TestQ14FindMajorityItem()
        {
            var result = Q14FindMajorityItem.MajorityItem(new int[] { 1 });
            Assert.AreEqual(1, result);

            result = Q14FindMajorityItem.MajorityItem(new int[] { 1, 1 });
            Assert.AreEqual(1, result);

            result = Q14FindMajorityItem.MajorityItem(new int[] { 1, 3, 1 });
            Assert.AreEqual(1, result);

            result = Q14FindMajorityItem.MajorityItem(new int[] { 1, 3, 3, 1, 3 });
            Assert.AreEqual(3, result);

            result = Q14FindMajorityItem.MajorityItem(new int[] { 1, 3, 1, 3, 3, 3, 1 });
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void TestQ15FindFrequentItems()
        {
            var result = Q15FindFrequentItems.FrequentItems(new int[] { 1, 3, 1, 3, 3, 3, 1 }, 2);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(3));

            result = Q15FindFrequentItems.FrequentItems(new int[] { 1, 2, 1 }, 2);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(1));

            result = Q15FindFrequentItems.FrequentItems(new int[] { 1, 2, 1, 2, 3 }, 3);
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(1));
            Assert.IsTrue(result.Contains(2));

            result = Q15FindFrequentItems.FrequentItems(new int[] { 1, 2, 3, 1, 2, 2, 3, 1 }, 3);
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(1));
            Assert.IsTrue(result.Contains(2));

            result = Q15FindFrequentItems.FrequentItems(new int[] { 9, 8, 7, 6, 5, 1, 1, 2, 1, 1, 2 }, 4);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(1));
        }

        [TestMethod]
        public void TestQ16SearchBST()
        {
            var tree = new Q16SearchBST.BSTNode(0);
            var result = Q16SearchBST.SearchIterative(tree, 0);
            Assert.AreEqual(0, result.Value);

            result = Q16SearchBST.SearchRecursive(tree, 0);
            Assert.AreEqual(0, result.Value);

            result = Q16SearchBST.SearchIterative(tree, -1);
            Assert.AreEqual(null, result);

            result = Q16SearchBST.SearchRecursive(tree, -1);
            Assert.AreEqual(null, result);

            result = Q16SearchBST.SearchIterative(tree, 1);
            Assert.AreEqual(null, result);

            result = Q16SearchBST.SearchRecursive(tree, 1);
            Assert.AreEqual(null, result);

            tree.Left = new Q16SearchBST.BSTNode(-10);
            tree.Right = new Q16SearchBST.BSTNode(10);
            tree.Left.Right = new Q16SearchBST.BSTNode(-5);

            result = Q16SearchBST.SearchIterative(tree, -5);
            Assert.AreEqual(-5, result.Value);

            result = Q16SearchBST.SearchRecursive(tree, -5);
            Assert.AreEqual(-5, result.Value);

            result = Q16SearchBST.SearchIterative(tree, -4);
            Assert.AreEqual(null, result);

            result = Q16SearchBST.SearchRecursive(tree, -4);
            Assert.AreEqual(null, result);

            tree.Left.Right.Left = new Q16SearchBST.BSTNode(-7);
            result = Q16SearchBST.SearchIterative(tree, -7);
            Assert.AreEqual(-7, result.Value);

            result = Q16SearchBST.SearchRecursive(tree, -7);
            Assert.AreEqual(-7, result.Value);

            result = Q16SearchBST.SearchIterative(tree, 10);
            Assert.AreEqual(10, result.Value);

            result = Q16SearchBST.SearchRecursive(tree, 10);
            Assert.AreEqual(10, result.Value);

            result = Q16SearchBST.SearchIterative(tree, 9);
            Assert.AreEqual(null, result);

            result = Q16SearchBST.SearchRecursive(tree, 9);
            Assert.AreEqual(null, result);

        }

        [TestMethod]
        public void TestQ17SearchBSTFirstLargeThan()
        {
            var tree = new Q16SearchBST.BSTNode(0);
            tree.Left = new Q16SearchBST.BSTNode(-10);
            tree.Right = new Q16SearchBST.BSTNode(10);
            tree.Left.Left = new Q16SearchBST.BSTNode(-15);
            tree.Left.Right = new Q16SearchBST.BSTNode(-5);
            tree.Left.Right.Left = new Q16SearchBST.BSTNode(-7);
            tree.Right.Right = new Q16SearchBST.BSTNode(15);
            tree.Right.Right.Left = new Q16SearchBST.BSTNode(12);

            var result = Q17SearchBSTFirstLargeThan.FirstLargeThan(tree, -100);
            Assert.AreEqual(-15, result.Value);

            result = Q17SearchBSTFirstLargeThan.FirstLargeThan(tree, -15);
            Assert.AreEqual(-10, result.Value);

            result = Q17SearchBSTFirstLargeThan.FirstLargeThan(tree, -9);
            Assert.AreEqual(-7, result.Value);

            result = Q17SearchBSTFirstLargeThan.FirstLargeThan(tree, -7);
            Assert.AreEqual(-5, result.Value);

            result = Q17SearchBSTFirstLargeThan.FirstLargeThan(tree, -4);
            Assert.AreEqual(0, result.Value);

            result = Q17SearchBSTFirstLargeThan.FirstLargeThan(tree, 2);
            Assert.AreEqual(10, result.Value);

            result = Q17SearchBSTFirstLargeThan.FirstLargeThan(tree, 10);
            Assert.AreEqual(12, result.Value);

            result = Q17SearchBSTFirstLargeThan.FirstLargeThan(tree, 15);
            Assert.AreEqual(null, result);

        }

        [TestMethod]
        public void TestQ18KthStatisticsOf2Arrays()
        {
            var result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { 2 }, new int[] { }, 1);
            Assert.AreEqual(2, result);

            result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { }, new int[] { 3 }, 1);
            Assert.AreEqual(3, result);

            result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { 2, 3, 4 }, new int[] { }, 2);
            Assert.AreEqual(3, result);

            result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { 2, 3, 4 }, new int[] { 2 }, 2);
            Assert.AreEqual(2, result);

            result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { 2, 3, 4 }, new int[] { 2, 6 }, 3);
            Assert.AreEqual(3, result);

            result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { 2, 3, 4 }, new int[] { 5 }, 4);
            Assert.AreEqual(5, result);

            result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { 3 }, new int[] { 5, 6, 7 }, 1);
            Assert.AreEqual(3, result);

            result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { 3 }, new int[] { 5, 6, 7 }, 2);
            Assert.AreEqual(5, result);

            result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4, 5, 6 }, 3);
            Assert.AreEqual(2, result);

            result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4, 5, 6 }, 4);
            Assert.AreEqual(3, result);

            result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4, 5, 6 }, 9);
            Assert.AreEqual(6, result);

            result = Q18KthStatisticsOf2Arrays.KthStatistics(new int[] { 9, 10, 11 }, new int[] { 1, 2, 3 }, 4);
            Assert.AreEqual(9, result);
            //todo more tests
        }

        [TestMethod]
        public void TestQ20ContainedInterval()
        {
            var list = new List<Q20ContainedInterval.Interval>();
            var result = Q20ContainedInterval.FindContainedIntervalPair(list);
            Assert.AreEqual(null, result);

            list.Add(new Q20ContainedInterval.Interval(0, 1));
            result = Q20ContainedInterval.FindContainedIntervalPair(list);
            Assert.AreEqual(null, result);

            list.Add(new Q20ContainedInterval.Interval(10, 11));
            list.Add(new Q20ContainedInterval.Interval(5, 6));
            list.Add(new Q20ContainedInterval.Interval(2,3));
            result = Q20ContainedInterval.FindContainedIntervalPair(list);
            Assert.AreEqual(null, result);

            list.Add(new Q20ContainedInterval.Interval(1.5f, 2.7f));
            result = Q20ContainedInterval.FindContainedIntervalPair( list);
            Assert.AreEqual(null, result);

            list.Add(new Q20ContainedInterval.Interval(10.0f, 11.7f));
            result = Q20ContainedInterval.FindContainedIntervalPair(list);
            Assert.AreEqual(10.0f, result.Interval1.From);

            list.Add(new Q20ContainedInterval.Interval(2.0f, 3.1f));
            result = Q20ContainedInterval.FindContainedIntervalPair(list);
            Assert.AreEqual(2.0f, result.Interval1.From);
        }

        [TestMethod]
        public void TestQ19IntersectBetweenX01()
        {
            var lines = new List<Q19LinesInterctInRectangle.LineF>();
            var result = Q19LinesInterctInRectangle.IntersectBetweenX01(lines);
            Assert.AreEqual(false, result);

            lines.Add(new Q19LinesInterctInRectangle.LineF(new Q19LinesInterctInRectangle.PointF(0,0), new Q19LinesInterctInRectangle.PointF(1,1)));
            lines.Add(new Q19LinesInterctInRectangle.LineF(new Q19LinesInterctInRectangle.PointF(0, -1), new Q19LinesInterctInRectangle.PointF(1, 0.5f)));
            result = Q19LinesInterctInRectangle.IntersectBetweenX01(lines);
            Assert.AreEqual(false, result);

            lines.Add(new Q19LinesInterctInRectangle.LineF(new Q19LinesInterctInRectangle.PointF(0, 1), new Q19LinesInterctInRectangle.PointF(1, 1.2f)));
            result = Q19LinesInterctInRectangle.IntersectBetweenX01(lines);
            Assert.AreEqual(false, result);

            lines.Add(new Q19LinesInterctInRectangle.LineF(new Q19LinesInterctInRectangle.PointF(0, 2), new Q19LinesInterctInRectangle.PointF(1, 2.2f)));
            result = Q19LinesInterctInRectangle.IntersectBetweenX01(lines);
            Assert.AreEqual(false, result);

            lines.Add(new Q19LinesInterctInRectangle.LineF(new Q19LinesInterctInRectangle.PointF(0, 1.2f), new Q19LinesInterctInRectangle.PointF(1, 1.5f)));
            result = Q19LinesInterctInRectangle.IntersectBetweenX01(lines);
            Assert.AreEqual(false, result);

            lines.Add(new Q19LinesInterctInRectangle.LineF(new Q19LinesInterctInRectangle.PointF(0, -1.2f), new Q19LinesInterctInRectangle.PointF(1, 0)));
            result = Q19LinesInterctInRectangle.IntersectBetweenX01(lines);
            Assert.AreEqual(false, result);

            lines.Add(new Q19LinesInterctInRectangle.LineF(new Q19LinesInterctInRectangle.PointF(0, -1.3f), new Q19LinesInterctInRectangle.PointF(1, 0.1f)));
            result = Q19LinesInterctInRectangle.IntersectBetweenX01(lines);
            Assert.AreEqual(true, result);

            lines.RemoveAt(lines.Count - 1);
            lines.Add(new Q19LinesInterctInRectangle.LineF(new Q19LinesInterctInRectangle.PointF(0, 1.3f), new Q19LinesInterctInRectangle.PointF(1, 1.1f)));
            result = Q19LinesInterctInRectangle.IntersectBetweenX01(lines);
            Assert.AreEqual(true, result);

            lines.RemoveAt(lines.Count - 1);
            lines.Add(new Q19LinesInterctInRectangle.LineF(new Q19LinesInterctInRectangle.PointF(0, 4), new Q19LinesInterctInRectangle.PointF(1, -10.1f)));
            result = Q19LinesInterctInRectangle.IntersectBetweenX01(lines);
            Assert.AreEqual(true, result);

            lines.RemoveAt(lines.Count - 1);
            lines.Add(new Q19LinesInterctInRectangle.LineF(new Q19LinesInterctInRectangle.PointF(0, 0.24f), new Q19LinesInterctInRectangle.PointF(1, 0.4f)));
            result = Q19LinesInterctInRectangle.IntersectBetweenX01(lines);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestQ7UnionMergeSorted()
        {
            var result = Q7IntersectNoDuplicate.UnionMerge(new int[] { }, new int[] { });
            Assert.AreEqual(0, result.Count);

            result = Q7IntersectNoDuplicate.UnionMerge(new int[] {1, 3 }, new int[] { 9});
            Assert.AreEqual(3, result.Count);

            result = Q7IntersectNoDuplicate.UnionMerge(new int[] { 1, 3 }, new int[] { 1, 3, 9 });
            Assert.AreEqual(3, result.Count);

            result = Q7IntersectNoDuplicate.UnionMerge(new int[] { 1, 3, 12, 19 }, new int[] {  9, 12, 21 });
            Assert.AreEqual(6, result.Count);

            result = Q7IntersectNoDuplicate.UnionMerge(new int[] { 1, 3, 5, 12, 19 }, new int[] { 5, 9, 12, 21 });
            Assert.AreEqual(7, result.Count);
        
        }
    }
}
