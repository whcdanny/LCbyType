//Leetcode 682. Baseball Game ez
//题意：你正在记录一个有着奇怪规则的棒球比赛的得分。比赛开始时，你的记录为空。
//给定一个字符串数组 operations，其中 operations[i] 是第 i 个操作，操作类型有以下几种：
//一个整数 x：记录新的得分 x。
//'+'：记录一个新的得分，该得分是前两个得分的和。
//'D'：记录一个新的得分，该得分是前一个得分的两倍。
//'C'：使前一个得分无效，从记录中移除它。
//返回在应用所有操作后记录上的所有得分的总和。
//思路：Stack 栈来模拟记录的过程，遍历操作数组。
//对于每个操作，根据其类型执行相应的操作。
//使用栈来存储记录的得分，每次执行操作后更新栈中的得分。
//最后返回栈中所有得分的总和。
//时间复杂度：O(n)，n 为化学式的长度
//空间复杂度：O(n) 
        public int CalPoints(string[] operations)
        {
            Stack<int> stack = new Stack<int>();

            foreach (string op in operations)
            {
                if (op == "+")
                {
                    int top = stack.Pop();
                    int newTop = top + stack.Peek();
                    stack.Push(top);
                    stack.Push(newTop);
                }
                else if (op == "D")
                {
                    stack.Push(2 * stack.Peek());
                }
                else if (op == "C")
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(int.Parse(op));
                }
            }

            int sum = 0;
            foreach (int score in stack)
            {
                sum += score;
            }

            return sum;
        }