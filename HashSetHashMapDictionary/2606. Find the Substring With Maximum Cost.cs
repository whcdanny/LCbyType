//Leetcode 2606. Find the Substring With Maximum Cost med
//题意：给定一个字符串 s，一个由不同字符组成的字符串 chars 和一个与 chars 长度相同的整数数组 vals。
//子串的成本是子串中每个字符的值之和。空字符串的成本被视为 0。
//字符的值定义如下：
//如果字符不在字符串 chars 中，则其值为字母表中对应位置的数字（从 1 开始计数）。
//否则，假设字符出现在字符串 chars 中的索引为 i，则其值为 vals[i]。
//例如，'a' 的值为 1，'b' 的值为 2，'z' 的值为 26。
//返回字符串 s 的所有子串中的最大成本。
//思路：hashtable, 先用map将标准的1-26个字母的初始值给上，
//然后根据chars和相对于的vals更新这个map
//最后历遍s，找出当前的值，然后跟最大值比较，如果小于0，更新成0；     
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MaximumCostSubstring(string s, string chars, int[] vals)
        {
            var map = new int[26];
            int local_max = 0, global_max = 0;

            for (int i = 1; i <= 26; i++)
                map[i - 1] = i;

            for (int i = 0; i < chars.Length; i++)
                map[chars[i] - 'a'] = vals[i];

            for (int i = 0; i < s.Length; i++)
            {
                local_max += map[s[i] - 'a'];
                global_max = Math.Max(global_max, local_max);
                if (local_max < 0)
                    local_max = 0;
            }

            return global_max;
        }