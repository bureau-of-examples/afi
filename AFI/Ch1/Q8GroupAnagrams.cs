using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Given a list of words, find anagrams.
    /// </summary>
    public static class Q8GroupAnagrams
    {
        public static IDictionary<String, LinkedList<String>> GroupAnagrams(IEnumerable<String> words)
        {
            var result = new Dictionary<String, LinkedList<String>>();
            foreach (String word in words)
            {
                String key = InsertionSort(word);
                if (!result.ContainsKey(key))
                {
                    result[key] = new LinkedList<string>();
                }
                result[key].AddFirst(new LinkedListNode<String>(word));
            }
            return result;
        }

        private static String InsertionSort(String word)
        {
            Char[] chars = word.ToArray();

            for (int i = 1; i < word.Length; i++)
            {
                char temp = chars[i];
                int j = i;
                while (j > 0 && chars[j-1] > temp)
                {
                    chars[j] = chars[j - 1];
                    j--;
                }
                chars[j] = temp;
            }
            return new String(chars);
        }
    }
}
