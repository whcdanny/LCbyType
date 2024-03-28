//Leetcode 3039. Apply Operations to Make String Empty med
//题意：给定一个字符串s。
//考虑执行以下操作，直到s变为空字符串为止：
//对于从'a'到'z'的每个字母字符，在s中移除第一次出现的该字符（如果存在）。
//例如，初始时s = "aabcbbca"。我们进行以下操作：
//移除下划线标记的字符后，s = "aabcbbca"。结果字符串是s = "abbca"。
//再次移除下划线标记的字符后，s = "abbca"。结果字符串是s = "ba"。
//最后移除下划线标记的字符后，s = "ba"。结果字符串是s = ""。
//要求返回在进行最后一次操作之前的字符串s的值。
//思路：hashtable, Dictionary存储每个char出现的个数，并找出最多的出现个数；
//这样可以确定最后一次操作之前的字符串s的值        
//时间复杂度：O(n)
//空间复杂度：O(n)
        public string LastNonEmptyString(string s)
        {
            var map = new Dictionary<char, int>();
            var highest = 0;

            for (var i = s.Length - 1; i >= 0; i--)
            {

                if (!map.ContainsKey(s[i])) 
                    map.Add(s[i], 0);
                map[s[i]]++;

                highest = Math.Max(highest, map[s[i]]);
            }

            string res = "";
            for (var i = map.Keys.Count - 1; i >= 0; i--)
                if (map[map.Keys.ElementAt(i)] == highest)
                    res += map.Keys.ElementAt(i);

            return res;
        }
