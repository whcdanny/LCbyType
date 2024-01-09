//Leetcode 1170. Compare Strings by Frequency of the Smallest Character med
//题意：给定一个字符串数组 queries 和一个字符串数组 words，对于每个查询字符串，求出其最小字母频次，并计算有多少个单词的最小字母频次大于查询字符串的最小字母频次。
//字母频次是指字符串中出现最小字母的次数
//思路：使用二分搜索, 先根据words，找出每个word的最小字母频次，然后存入list然后排序；
//二分用queries每一个也查找错每个query的最小字母频次，然后找到在第一个小于等于query的位置，然后list-这个位置就是剩下都大于的数量，然后叠加；
//时间复杂度: O((W + Q) * log W)，其中 W 是单词数量，Q 是查询字符串数量
//空间复杂度：O(W)W 是单词数量
        public int[] NumSmallerByFrequency(string[] queries, string[] words)
        {
            var fwords = new int[words.Length];
            for (int i = 0; i < words.Length; i++)
                fwords[i] = f(words[i]);

            Array.Sort(fwords);

            var ret = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                ret[i] = BinarySearch_NumSmallerByFrequency(fwords, f(queries[i]));

            return ret;
        }

        public int f(string s)
        {
            var fq = new int[26];
            foreach (char c in s)
                fq[c - 'a']++;
            for (int i = 0; i < 26; i++)
                if (fq[i] > 0)
                    return fq[i];
            return 0;
        }

        public int BinarySearch_NumSmallerByFrequency(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (arr[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return arr.Length - left;
        }