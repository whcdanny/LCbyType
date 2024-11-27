//Leetcode 150. Evaluate Reverse Polish Notation med
//题目：给一个stringlist，然后根据给的数字和'+', '-', '*', and '/' 来得到最后的答案；
//思路：用stack来存数，然后每一次出现运算符的时候，从stack最上面两个的数来做算法；
//时间复杂度：n 是表达式的长度，O(n)。
//空间复杂度：n 是表达式的长度，O(n)
        public int EvalRPN(string[] tokens)
        {
            if (tokens == null)
                return 0;
            Stack<int> nums = new Stack<int>();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "+" || tokens[i] == "-" ||
                    tokens[i] == "*" || tokens[i] == "/")
                {
                    int num2 = nums.Pop();
                    int num1 = nums.Pop();
                    nums.Push(op(num1, num2, tokens[i]));
                }
                else
                    nums.Push(Int32.Parse(tokens[i]));
            }
            return nums.Peek();
        }
        private int op(int num1, int num2, string optor)
        {
            if (optor == "+") return num1 + num2;
            else if (optor == "-") return num1 - num2;
            else if (optor == "*") return num1 * num2;
            else return num1 / num2;
        }