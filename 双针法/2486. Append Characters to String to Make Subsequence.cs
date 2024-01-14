//Leetcode 2486. Append Characters to String to Make Subsequence med
//题意：给定两个字符串 s 和 t，都只包含小写英文字母。要求返回将字符附加到字符串 s 末尾的最小字符数，使得 t 成为 s 的子序列。
//子序列是通过从另一个字符串删除一些或不删除字符而派生的字符串，而不改变其余字符的顺序。
//思路：左右针，两个指针 i 和 j 分别指向字符串 t 和 s 的开头。如果当前相同，那么i++和j++；如果不相同j++；最后找到相同元素是i个元素在s里，这样剩下的t.Length - i就是放在s末尾的个数；
//时间复杂度: O(n)
//空间复杂度：O(1)
        public int AppendCharacters(string s, string t)
        {

            int i = 0, j = 0;
            while (i < t.Length && j < s.Length)
            {
                if (s[j] == t[i])
                {
                    i++;
                }
                j++;
            }
            return t.Length - i;
        }
