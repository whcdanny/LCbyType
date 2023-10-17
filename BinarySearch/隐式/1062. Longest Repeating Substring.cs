//Leetcode 1062. Longest Repeating Substring med
//题意：在一个升序排列的整数数组中找到缺失的元素
//思路：二分法: 先确定最长重复子串的长度的上限，然后使用滑动窗口和哈希表来进行检查. 二分法滑动窗口和哈希表，初始化窗口的大小 len 为字符串长度的一半，从 len 逐渐减小到 1。对于每个 len，遍历字符串，以当前位置 i 作为窗口的起点。截取长度为 len 的子串 substring。检查剩余部分的字符串中是否包含 substring，如果包含，则返回 len。如果在整个字符串中找不到长度为 len 的重复子串，则减小 len 继续下一轮循环 
//时间复杂度: 二分查找的时间复杂度是 O(logn)，在每一次迭代中，滑动窗口的时间复杂度是 O(n)
//空间复杂度： O(n)    
        public int LongestRepeatingSubstring(string s)
        {
            int left = 1;
            int right = s.Length;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (isDuplicateSubstringExists(s, mid))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return right;
        }

        private bool isDuplicateSubstringExists(string s, int len)
        {
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i <= s.Length - len; i++)
            {
                string substring = s.Substring(i, len);
                if (set.Contains(substring))
                {
                    return true;
                }
                set.Add(substring);
            }

            return false;
        }