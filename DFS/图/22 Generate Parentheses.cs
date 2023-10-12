//Leetcode 22 Generate Parentheses med
//题意：给定一个整数 n，生成包含 n 对括号的所有可能的合法括号组合
//思路：深度优先搜索（DFS）: 如果左括号的数量小于 n，我们可以添加一个左括号。如果右括号的数量小于左括号的数量，我们可以添加一个右括号
//时间复杂度:  O(2^(2n)/sqrt(n))
//空间复杂度： O(n)
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> res = new List<string>();
            Generate(n, n, "", res);
            return res;
        }
        private void Generate(int left, int right, string current, List<string> result)
        {
            if (left == 0 && right == 0)
            {
                result.Add(current);
                return;
            }

            if (left > 0)
            {
                Generate(left - 1, right, current + "(", result);
            }
            if (right > left)
            {
                Generate(left, right - 1, current + ")", result);
            }
        }
