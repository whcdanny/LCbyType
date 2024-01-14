//Leetcode2565. Subsequence With the Minimum Score hard
//题意：给定两个字符串 s 和 t。
//允许从字符串 t 中删除任意数量的字符。
//字符串的得分为 0，如果不从字符串 t 中删除任何字符，否则：
//令 left 为所有删除字符中的最小索引。
//令 right 为所有删除字符中的最大索引。
//字符串的得分为 right - left + 1。
//要求返回将 t 变成 s 的子序列所需的最小得分。
//子序列是通过删除一些（可以是零个）字符而形成的原始字符串的新字符串，而不会破坏其余字符的相对位置（例如，"ace" 是 "abcde" 的子序列，而 "aec" 不是）。
//思路：二分搜索法: 相当于t中找满足s的Subsequence，这样在t中分成两部分，我们不知道存不存在s的字母，那么分为left，right分别表示t从left的[0,i]是s的Subsequen，right的[j, n-1]是s的Subsequen
//当你算出left和right然后用二分法来猜满足的Subsequence的长度，这样只要在left和right里找；
//时间复杂度：O(nlogn) - 二分搜索的时间复杂度。
//空间复杂度：O(m+n)
        public int MinimumScore(string s, string t)
        {
            int m = s.Length;
            int n = t.Length;

            int[] left = new int[n];
            Array.Fill(left, m);
            int j = 0;

            for (int i = 0; i < n; i++)
            {
                while (j < m && s[j] != t[i])
                {
                    j++;
                }
                if (j < m)
                {
                    left[i] = j;
                    j++;
                }
            }

            int[] right = new int[n];
            Array.Fill(right, -1);
            j = m - 1;

            for (int i = n - 1; i >= 0; i--)
            {
                while (j >= 0 && s[j] != t[i])
                {
                    j--;
                }
                if (j >= 0)
                {
                    right[i] = j;
                    j--;
                }
            }

            int low = 0, high = n;

            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (isOK_MinimumScore(mid, s, t, left, right))
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }
        private bool isOK_MinimumScore(int len, string s, string t, int[] left, int[] right)
        {
            int m = s.Length;
            int n = t.Length;

            if (right[len] >= 0) return true;
            if (left[n - len - 1] < m) return true;

            for (int i = 1; i + len < n; i++)
            {
                if (left[i - 1] < right[i + len])
                {
                    return true;
                }
            }

            return false;
        }