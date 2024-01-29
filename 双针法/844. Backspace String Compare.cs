//Leetcode 844. Backspace String Compare ez
//题意：给定两个字符串 s 和 t，如果两个字符串在输入到空文本编辑器中时相等，就返回 true。在输入过程中，'#' 表示退格字符。
//注意，在删除空文本后，文本将保持为空。。
//思路：双指针，sPointer 和 tPointer 分别指向字符串的末尾。
//在循环中，处理字符串中的退格，即 '#'。
//统计当前位置及后续的退格数，移动指针。
//比较两个字符串当前位置的字符，如果不相等，返回 false。
//如果一个字符串已经遍历完，而另一个字符串还没有，返回 false。
//最终返回 true，表示两个字符串相等。
//时间复杂度：O(n + m)，其中 n 和 m 分别是字符串 s 和 t 的长度。
//空间复杂度：O(1)
        public bool BackspaceCompare(string s, string t)
        {
            int sPointer = s.Length - 1;
            int tPointer = t.Length - 1;

            while (sPointer >= 0 || tPointer >= 0)
            {
                int sCountBackspace = 0;
                while (sPointer >= 0 && (s[sPointer] == '#' || sCountBackspace > 0))
                {
                    if (s[sPointer] == '#')
                    {
                        sCountBackspace++;
                    }
                    else
                    {
                        sCountBackspace--;
                    }
                    sPointer--;
                }

                int tCountBackspace = 0;
                while (tPointer >= 0 && (t[tPointer] == '#' || tCountBackspace > 0))
                {
                    if (t[tPointer] == '#')
                    {
                        tCountBackspace++;
                    }
                    else
                    {
                        tCountBackspace--;
                    }
                    tPointer--;
                }

                if (sPointer >= 0 && tPointer >= 0)
                {
                    if (s[sPointer] != t[tPointer])
                    {
                        return false;
                    }
                }
                else if (sPointer >= 0 || tPointer >= 0)
                {
                    return false;
                }

                sPointer--;
                tPointer--;
            }

            return true;
        }