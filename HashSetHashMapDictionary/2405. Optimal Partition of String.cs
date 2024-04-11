//Leetcode 2405. Optimal Partition of String med
//题意：给定一个字符串 s，将字符串分割成一个或多个子字符串，使得每个子字符串中的字符都是唯一的，即每个字符在分割后的子字符串中只出现一次。
//返回分割后的最小子字符串数量。
//思路：hashtable 遍历字符串 s，维护一个哈希集合记录当前子字符串中已经出现过的字符。
//当遍历到一个字符时，检查它是否已经在哈希集合中出现过，如果出现过，说明需要在当前位置分割字符串，将当前子字符串加入结果，并将哈希集合清空；如果没有出现过，将该字符加入哈希集合。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int PartitionString(string s)
        {
            if (string.IsNullOrEmpty(s)) 
                return 0;
            int result = 1;

            HashSet<char> chars = new HashSet<char>();

            foreach (char c in s)
            {
                if (chars.Contains(c))
                {
                    result++;
                    chars = new HashSet<char>() { c };

                }
                else
                {
                    chars.Add(c);
                }
            }

            return result;
        }