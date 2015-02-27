using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch2
{
    /// <summary>
    /// Merge n sorted lists into 1.
    /// </summary>
    public static class Q10MultiwayMerge
    {
        public static IEnumerable<int> Merge(IList<IList<int>> sortedLists)
        {
            int[] indices = new int[sortedLists.Count]; //index of next item in list
            var items = new List<KeyIndexPair>();

            for (int i = 0; i < sortedLists.Count; i++)
            {
                if (indices[i] < sortedLists[i].Count)
                {
                    AddKey(items, new KeyIndexPair(sortedLists[i][indices[i]++], i));
                }
            }

            while (items.Count > 0)
            {
                var min = Extract(items);
                yield return min.Key;
                int i = min.Index;
                if (indices[i] < sortedLists[i].Count)
                {
                    AddKey(items, new KeyIndexPair(sortedLists[i][indices[i]++], i));
                }
            }
        }

        private static KeyIndexPair Extract(IList<KeyIndexPair> items)
        {
            var min = items[0];
            items[0] = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return min;
        }

        private static void BuildHeap(IList<KeyIndexPair> items)
        {
            int lastBranchIndex = items.Count / 2 - 1;
            for (int i = lastBranchIndex; i >= 0; i--)
                Heapify(items, i);
        }

        private static void Heapify(IList<KeyIndexPair> items, int i)
        {
            int left = 2 * i + 1;
            if (left >= items.Count)
                return;

            int right = left + 1;

            int minIndex = left;
            if (right < items.Count && items[right].Key < items[left].Key)
                minIndex = right;

            if (items[i].Key > items[minIndex].Key)
            {
                var temp = items[i];
                items[i] = items[minIndex];
                items[minIndex] = temp;

                Heapify(items, minIndex);
            }
        }

        private static void DecreaseKey(IList<KeyIndexPair> items, int i, int newKey)
        {
            if (newKey > items[i].Key)
                throw new ArgumentOutOfRangeException();

            items[i] = new KeyIndexPair(newKey, items[i].Index);

            while (i != 0)
            {
                int parent = (i - 1) / 2;//this does not work when i == 0; //(i + 1) / 2 - 1;
                if (items[parent].Key <= items[i].Key)
                    break;

                var temp = items[parent];
                items[parent] = items[i];
                items[i] = temp;
                i = parent;
            }

        }

        private static void AddKey(IList<KeyIndexPair> items, KeyIndexPair pair)
        {
            items.Add(new KeyIndexPair(int.MaxValue, pair.Index));
            DecreaseKey(items, items.Count - 1, pair.Key);
        }

        private struct KeyIndexPair
        {
            private int key;
            private int index;//source list lindex

            public KeyIndexPair(int key, int index)
            {
                this.key = key;
                this.index = index;
            }

            public int Key
            {
                get
                {
                    return key;
                }
            }

            public int Index
            {
                get
                {
                    return index;
                }
            }
        }
    }
}
