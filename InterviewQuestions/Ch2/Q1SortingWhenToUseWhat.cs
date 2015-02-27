using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch2
{
    /// <summary>
    /// When to use what:
    /// - small array of integers: insertion sort.
    /// - a large array whose entries are random numbers:insertion sort or heap sort.
    /// - a large collection of integers that are drawn from a very small range: counting sort.
    /// - a large collection of numbers most of which are duplicates: quick sort no, use bst to insert all items, keep linked list at node.
    /// - stable sort: insertion sort, merge sort, counting sort.
    /// </summary>
    public static class Q1SortingWhenToUseWhat
    {
    }
}
