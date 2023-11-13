//Leetcode 1625. Lexicographically Smallest String After Applying Operations  med
//题意：给定一个字符串 s 和两个整数 a 和 b，初始时，你可以对 s 执行以下操作之一：将字符串 s 中的每个字符都替换成 a 个位置之后的字符。将字符串 s 向右旋转 b 位。请你返回执行操作之后的最小字典序的字符串。
//思路：BFS（宽度优先搜索）来遍历所有可能的状态，即字符串的旋转和替换的组合。在每一步中，记录当前字符串，然后分别进行旋转和替换操作，并将结果加入队列中，直到找到最小字典序的字符串。使用集合 visited 来存储已经访问过的状态，避免陷入无限循环。
//时间复杂度: O(2^n)，其中 n 是字符串的长度。
//空间复杂度： O(1)。
        public string FindLexSmallestString(string s, int a, int b)
        {
            HashSet<string> visited = new HashSet<string>();
            Queue<string> queue = new Queue<string>();
            string result = s;

            queue.Enqueue(s);
            visited.Add(s);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                result = MinLexString(result, current);

                string rotated = Rotate(current, b);
                string replaced = Replace(current, a);

                if (!visited.Contains(rotated))
                {
                    visited.Add(rotated);
                    queue.Enqueue(rotated);
                }

                if (!visited.Contains(replaced))
                {
                    visited.Add(replaced);
                    queue.Enqueue(replaced);
                }
            }

            return result;
        }
        private string MinLexString(string s1, string s2)
        {
            BigInteger num1 = BigInteger.Parse(s1);
            BigInteger num2 = BigInteger.Parse(s2);

            if (num1 < num2)
            {
                return s1;
            }
            else
            {
                return s2;
            }
        }

        private string Rotate(string s, int b)
        {            
            return s.Substring(s.Length - b) + s.Substring(0, s.Length - b);
        }

        private string Replace(string s, int a)
        {
            char[] chars = s.ToCharArray();
            for (int i = 1; i < s.Length; i += 2)
            {
                chars[i] = (char)('0' + (chars[i] - '0' + a) % 10);
            }
            return new string(chars);
        }