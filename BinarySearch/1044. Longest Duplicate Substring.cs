//Leetcode 1044. Longest Duplicate Substring hard
//题意：给定一个字符串 S，找到其最长的重复子串。如果不存在重复子串，则返回空字符串。
//思路：二分搜索+sliding window，二分查找确定重复子串的长度。left 和 right 分别表示当前搜索范围的左右边界 
//通过哈希值和滑动窗口的思想，计算子串的哈希值，然后在哈希集合中查找是否已经存在相同的哈希值。
//如果存在相同的哈希值，说明存在相同的子串，记录起始索引并返回 true。
//如果不存在相同的哈希值，将当前哈希值加入集合。
//时间复杂度:二分查找时间复杂度为 O(logN)。在每次查找中，found_LongestDupSubstring 方法的哈希计算和集合操作都是 O(N) 的，其中 N 是字符串长度。因此，总体时间复杂度为 O(N* logN)。
//空间复杂度：HashSet 存储哈希值，空间复杂度为 O(N)
        private Dictionary<int, int> len2start = new Dictionary<int, int>();

        public string LongestDupSubstring(string S)
        {
            int left = 1, right = S.Length - 1;
            while (left < right)
            {
                int mid = right - (right - left) / 2;
                if (found_LongestDupSubstring(S, mid))
                    left = mid;
                else
                    right = mid - 1;
            }

            if (found_LongestDupSubstring(S, left))
                return S.Substring(len2start[left], left);
            else
                return "";
        }

        private bool found_LongestDupSubstring(string S, int len)
        {
            HashSet<long> set = new HashSet<long>();
            long base_num = 31;
            long hash = 0;
            //表示基数的 len 次方，用于快速计算滑动窗口的影响。
            long powBaseLen = 1;
            for (int i = 0; i < len; i++)
                powBaseLen = powBaseLen * base_num;

            for (int i = 0; i < S.Length; i++)
            {
                hash = hash * base_num + (long)(S[i] - 'a');

                //如果超过len的要减去i-len的；
                if (i >= len)
                    hash = (hash - powBaseLen * (long)(S[i - len] - 'a'));

                if (i >= len - 1)
                {
                    //如果有说明是Duplicate
                    if (set.Contains(hash))
                    {
                        len2start[len] = i - len + 1;
                        return true;
                    }
                    set.Add(hash);
                }
            }
            return false;
        }
