//Leetcode 282. Expression Add Operators hard
//题意：给定一个只包含数字的字符串 num 和一个整数 target，
//要求返回所有可能的在 num 的数字之间插入二元运算符（+, -, *）以使结果表达式的值等于目标值 target 的组合。
//注意事项：
//运算符仅限 +, -, 和*。
//表达式中的操作数不能包含前导零（例如，不能用 01 表示 1）。
//思路：回溯法（Backtracking）+ Recursion
//从每个位置尝试不同长度去猜测+,-,*
//循环是从当前位置开始，尝试取不同长度的数字
//然后取出片段num.Substring(index, i - index + 1);转换成long.Parse(currentString)
//注意不是是‘0’
//然后如果是i是起始位置Backtrack(currentString, i + 1, currentNum, currentNum, num, target, result);
//剩下的就猜测+，-，*
//Backtrack_AddOperators(expression + "+" + currentString, i + 1, currentValue + currentNum, currentNum, num, target, result);
//Backtrack_AddOperators(expression + "-" + currentString, i + 1, currentValue - currentNum, -currentNum, num, target, result);
//Backtrack_AddOperators(expression + "*" + currentString, i + 1, currentValue - lastValue + lastValue * currentNum, lastValue * currentNum, num, target, result);
//直到当长度与nums的长度一致并且值与target一样
//时间复杂度：O(4^n)
//空间复杂度：O(n)
        public IList<string> AddOperators(string num, int target)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(num)) return result;          

            // 开始回溯
            Backtrack_AddOperators("", 0, 0, 0, num, target, result);
            return result;
        }
        void Backtrack_AddOperators(string expression, int index, long currentValue, long lastValue, string num, int target, List<string> result)
        {
            // 如果处理到了字符串末尾，并且计算结果等于目标值
            if (index == num.Length)
            {
                if (currentValue == target)
                {
                    result.Add(expression);
                }
                return;
            }

            // 从当前位置开始，尝试取不同长度的数字
            for (int i = index; i < num.Length; i++)
            {
                // 如果存在前导零，直接跳过
                if (i != index && num[index] == '0') break;

                // 取出当前数字片段
                string currentString = num.Substring(index, i - index + 1);
                long currentNum = long.Parse(currentString);

                // 如果是第一个数字，直接加入表达式
                if (index == 0)
                {
                    Backtrack_AddOperators(currentString, i + 1, currentNum, currentNum, num, target, result);
                }
                else
                {
                    // 添加 '+'
                    Backtrack_AddOperators(expression + "+" + currentString, i + 1, currentValue + currentNum, currentNum, num, target, result);

                    // 添加 '-'
                    Backtrack_AddOperators(expression + "-" + currentString, i + 1, currentValue - currentNum, -currentNum, num, target, result);

                    // 添加 '*'
                    Backtrack_AddOperators(expression + "*" + currentString, i + 1, currentValue - lastValue + lastValue * currentNum, lastValue * currentNum, num, target, result);
                }
            }
        }