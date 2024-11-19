//Leetcode 1405. Longest Happy String med
//题意：给定三个整数 a、b 和 c，构造满足特定条件的最长的“幸福字符串”。
//具体来说，一个字符串被称为“幸福的”，需要满足以下条件：
//字符串只包含字母 'a'、'b' 和 'c'。
//字符串中不包含连续三个相同的字符，即不包含子串 "aaa"、"bbb" 或 "ccc"。
//字符串中最多包含 a 个字符 'a'、b 个字符 'b' 和 c 个字符 'c'。
//给定 a、b 和 c，需要返回满足上述条件的最长的“幸福字符串”。如果存在多个满足条件的最长“幸福字符串”，则可以返回其中的任意一个。如果不存在满足条件的字符串，则返回空字符串 ""。
//需要注意的是，题目并没有规定返回的“幸福字符串”必须是唯一的，只要满足条件即可。
//思路：PriorityQueue 存入abc相对应的字母和个数；
//当遇到两个连续相同的时候，就要添加另外一个字母，然后每一次结束添加，检查是否当前字母个数，如果还有就要重新添加到pq中；
//时间复杂度: O(n)，其中 n 为字符串的长度
//空间复杂度：O(1)
        public string LongestDiverseString(int a, int b, int c)
        {
            var map = new Dictionary<char, int>();
            map['a'] = a;
            map['b'] = b;
            map['c'] = c;
            //存入char 和 个数
            var pq = new PriorityQueue<char, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            foreach (var key in map.Keys)
            {
                if (map[key] > 0)
                    pq.Enqueue(key, map[key]);
            }

            StringBuilder sb = new StringBuilder();
            while (pq.Count > 0)
            {
                char CurrentChar = pq.Dequeue();
                //如果已经出现两个相同的了
                if (sb.Length > 1 && sb[sb.Length - 1] == CurrentChar && sb[sb.Length - 2] == CurrentChar)
                {
                    if (pq.Count == 0) break;
                    //找到下一个；
                    var NextChar = pq.Dequeue();
                    sb.Append(NextChar);
                    map[NextChar]--;
                    //如果还有就加会pq
                    if (map[NextChar] > 0) pq.Enqueue(NextChar, map[NextChar]);
                }
                else
                {
                    sb.Append(CurrentChar);
                    map[CurrentChar]--;
                }
                //如果还有就加会pq
                if (map[CurrentChar] > 0) pq.Enqueue(CurrentChar, map[CurrentChar]);
            }
            return sb.ToString();
        }