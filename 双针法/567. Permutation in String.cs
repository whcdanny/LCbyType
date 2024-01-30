//Leetcode 567. Permutation in String med
//题意：两个字符串 s1 和 s2，判断是否存在 s1 的一个排列是 s2 的子串。
//思路：双指针，s1 中每个字符的出现次数，使用数组 countS1 存储。
//初始化左右指针 left 和 right，以及窗口内字符计数数组 countWindow。
//先将窗口大小调整为 s1 的长度，右移右指针。
//检查当前窗口是否包含 s1 的排列，如果是，则返回 true。
//使用滑动窗口，右移右指针，左移左指针，更新窗口内字符计数数组。
//检查当前窗口是否包含 s1 的排列，如果是，则返回 true。
//时间复杂度：O(n)，其中 n 是数组的长度
//空间复杂度：O(1)
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
            {
                return false;
            }

            // 统计 s1 中每个字符的出现次数
            int[] countS1 = new int[26];
            foreach (char c in s1)
            {
                countS1[c - 'a']++;
            }

            // 初始化左右指针和窗口内字符计数数组
            int left = 0, right = 0;
            int[] countWindow = new int[26];

            // 先将窗口大小调整为 s1 的长度
            while (right < s1.Length)
            {
                countWindow[s2[right] - 'a']++;
                right++;
            }

            // 检查当前窗口是否包含 s1 的排列
            if (CheckPermutation(countS1, countWindow))
            {
                return true;
            }

            // 滑动窗口，右移右指针，左移左指针
            while (right < s2.Length)
            {
                countWindow[s2[right] - 'a']++;
                countWindow[s2[left] - 'a']--;
                right++;
                left++;

                // 检查当前窗口是否包含 s1 的排列
                if (CheckPermutation(countS1, countWindow))
                {
                    return true;
                }
            }

            return false;
        }

        // 检查两个字符计数数组是否相等
        private bool CheckPermutation(int[] countS1, int[] countWindow)
        {
            for (int i = 0; i < 26; i++)
            {
                if (countS1[i] != countWindow[i])
                {
                    return false;
                }
            }
            return true;
        }