//Leetcode 1006. Clumsy Factorial med
//题意：给定一个正整数 n，计算其“笨阶乘”（clumsy factorial）。笨阶乘的计算规则如下：
//使用一组四个运算符*、/、+、-，按照顺序循环使用，依次计算。
//按照正常的运算优先级进行计算，即先乘除后加减。
//使用地板除法进行除法运算。
//例如，clumsy(10) 的计算过程如下：10 * 9 / 8 + 7 - 6 * 5 / 4 + 3 - 2 * 1
//思路：stack, 栈来模拟计算过程，将数字依次入栈。
//使用一个指针指示当前运算符的位置，初始时指向第一个运算符*。
//遍历运算符，依次执行对应的运算：
//如果运算符为*，则将栈顶两个数字相乘后入栈。
//如果运算符为 /，则将栈顶两个数字相除后取整入栈。
//如果运算符为 +，则将下一个数字入栈。
//如果运算符为 -，则将下一个数字取相反数入栈。
//最后将栈中所有数字相加，得到最终结果。
//时间复杂度: O(n) 的时间，其中 n 是给定的正整数 n
//空间复杂度：O(n)使用了一个栈来模拟计算过程，栈的大小最多为 n，
        public int Clumsy(int n)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(n);
            int opIndex = 0;
            for (int i = n - 1; i > 0; i--)
            {
                if (opIndex % 4 == 0)
                {
                    stack.Push(stack.Pop() * i);
                }
                else if (opIndex % 4 == 1)
                {
                    stack.Push(stack.Pop() / i);
                }
                else if (opIndex % 4 == 2)
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Push(-i);
                }
                opIndex++;
            }

            int result = 0;
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }
            return result;
        }