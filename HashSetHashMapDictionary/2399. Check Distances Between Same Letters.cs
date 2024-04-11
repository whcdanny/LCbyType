//Leetcode 2399. Check Distances Between Same Letters ez
//题意：给定一个字符串 s，其中只包含小写英文字母，且每个字母都出现了两次。同时给定一个长度为 26 的整数数组 distance。
//对于字母表中的每个字母，其编号从 0 到 25（即 'a' -> 0, 'b' -> 1, 'c' -> 2, ... , 'z' -> 25）。
//在一个“间距均匀”的字符串中，第 i 个字母两次出现的位置之间的字母数应该为 distance[i]。
//如果第 i 个字母在字符串 s 中没有出现，则可以忽略 distance[i]。
//如果 s 是一个“间距均匀”的字符串，则返回 true，否则返回 false。
//思路：hashtable 找的s中的每个相同char的距离，然后根据distance是否一致        
//时间复杂度：O(n)
//空间复杂度：O(n)
        public bool CheckDistances(string s, int[] distance)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                    map.Add(s[i], i);
                else
                    map[s[i]] = i - map[s[i]] - 1;
            }

            for (int i = 0; i < 26; i++)
            {
                if (s.Contains((char)(i + 'a')))
                {
                    if (map[(char)(i + 'a')] != distance[i])
                        return false;
                }
            }
            return true;
        }