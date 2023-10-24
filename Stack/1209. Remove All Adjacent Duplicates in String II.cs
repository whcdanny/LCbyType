//Leetcode 1209. Remove All Adjacent Duplicates in String II mid
//题意：给定一个字符串 s 和一个整数 k，从字符串中删除所有相邻的重复项，重复项的长度为 k。        
//思路：可以使用栈来解决这个问题。遍历字符串，对于每一个字符，将其与栈顶元素比较，如果相同且累积到了 k 个，就将栈顶元素出栈，否则就将该字符入栈。
//时间复杂度：O(n)
//空间复杂度：O(n) 
        public string RemoveDuplicates(string s, int k)
        {
            Stack<Pair> stack = new Stack<Pair>();

            foreach (char c in s)
            {
                if (stack.Count > 0 && stack.Peek().Character == c)
                {
                    stack.Peek().Count++;
                    if (stack.Peek().Count == k)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(new Pair(c, 1));
                }
            }

            StringBuilder result = new StringBuilder();
            while (stack.Count > 0)
            {
                Pair pair = stack.Pop();
                for (int i = 0; i < pair.Count; i++)
                {
                    result.Insert(0, pair.Character);
                }
            }

            return result.ToString();
        }

        private class Pair
        {
            public char Character { get; }
            public int Count { get; set; }

            public Pair(char character, int count)
            {
                Character = character;
                Count = count;
            }
        }
        public string RemoveDuplicates_1(string s, int k)
        {
            Stack<(char, int)> stack = new Stack<(char, int)>();

            foreach (char c in s)
            {
                if (stack.Count > 0 && stack.Peek().Item1 == c)
                {
                    var top = stack.Peek();
                    if (top.Item2 == k - 1)
                    {
                        for (int i = 0; i < k - 1; i++)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        stack.Push((c, top.Item2 + 1));
                    }
                }
                else
                {
                    stack.Push((c, 1));
                }
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                sb.Insert(0, item.Item1);
            }

            return sb.ToString();
        }