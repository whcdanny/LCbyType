//Leetcode 1898. Maximum Number of Removable Characters med
//题意：题目给定两个字符串 s 和 p，其中 p 是 s 的一个子序列。还给定一个互不相同的、0索引的整数数组 removable，表示可以从 s 中移除的字符的索引。现在的目标是选择一个整数 k（0 <= k <= removable.length），使得在移除 s 中的前 k 个索引对应的字符后，p 仍然是 s 的子序列。
//更具体地说，我们需要标记 s[removable[i]] 中的字符（其中 0 <= i<k），然后移除所有标记的字符，并检查移除后的 s 是否仍然是 p 的子序列。要求返回最大的 k 值。
//思路：用二分法, 先把removable和它相对于的位置存入，根据removable的数量来算k值，然后在比较的时候，如果当startpoint在s中的值与p不一样，那么动，或者startpoint在removable并且位置位于k之前，我们都要startPoint++;       
//时间复杂度: O(log n)，其中 n 是 removable 数组的长度。在每一次二分搜索中，我们需要调用 Check 函数，其时间复杂度为 O(m)，其中 m 是s字符串的长度。因此，总体时间复杂度为 O(m log n)。
//空间复杂度：O(m)，m 是s字符串的长度
        public int MaximumRemovals(string s, string p, int[] removable)
        {
            if (removable.Length == 0)
            {
                return 0;
            }

            Dictionary<int, int> removableDict = new Dictionary<int, int>();

            for (var i = 0; i < removable.Length; i++)
            {
                removableDict.Add(removable[i], i);
            }

            int left = 0;
            int right = removable.Length - 1;

            var res = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                
                if (checkOk_MaximumRemovals(s, p, removableDict, mid))
                {
                    res = Math.Max(res, mid);
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return res + 1;
        }

        private bool checkOk_MaximumRemovals(string s, string p, Dictionary<int, int> removableDict, int k)
        {
            var startPoint = 0;

            for (var i = 0; i < p.Length; i++)
            {
                while((startPoint < s.Length && s[startPoint] != p[i]) ||  (removableDict.ContainsKey(startPoint) && removableDict[startPoint] <= k))
                    startPoint++;

                if (startPoint == s.Length)
                {
                    return false;
                }

                startPoint++;
            }

            return true;
        }