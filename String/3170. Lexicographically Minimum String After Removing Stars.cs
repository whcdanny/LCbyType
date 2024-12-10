//3170. Lexicographically Minimum String After Removing Stars med
//题目：给你一个字符串s。它可能包含任意数量的'*'字符。你的任务是删除所有'*'字符。
//当有 时'*'，执行以下操作：
//删除最左边的'*'和其左边最小的非字符。如果有多个最小字符，可以删除其中任意一个。'*'
//返回字典序最小删除所有字符后得到的字符串'*'。
//思路：Dictionary<char, List<int>>找出从左往右每个字母出现的位置都存入
//HashSet把每个要移除的位置找到，
//当遇到*，就从0-26个字母顺序找出最先出现的最小字母对应的最后一个离*最近的位置
//然后移除
//时间复杂度:  O(n)
//空间复杂度： O(n)
        public string ClearStars(string s)
        {
            HashSet<int> remove = new HashSet<int>();
            Dictionary<char, List<int>> map = new Dictionary<char, List<int>>();
           
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] != '*')
                {                    
                    if (!map.ContainsKey(s[i]))
                    {
                        map[s[i]] = new List<int>();
                    }
                    map[s[i]].Add(i);
                }
                else
                {
                    for(int j = 0; j < 26; j++)
                    {
                        char key = Convert.ToChar(Convert.ToInt32('a')+j);
                        if (map.ContainsKey(key))
                        {
                            var temList = map[key];
                            var index = temList.Last();
                            remove.Add(index);
                            temList.Remove(index);
                            if (temList.Count == 0)
                                map.Remove(key);
                            break;
                        }
                    }                    
                }                
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*' || remove.Contains(i)) continue;
                sb.Append(s[i]);
            }
            return sb.ToString();
        }