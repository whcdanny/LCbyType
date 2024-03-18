//Leetcode 402. Remove K Digits med
//题意：给定一个表示非负整数的字符串 num，以及一个整数 k，要求从 num 中移除 k 个数字，使得剩下的数字组成的整数最小。
//思路：Stack 栈来模拟移除数字的过程，从左到右遍历 num 中的每个数字，并将其入栈。
//如果当前数字小于栈顶元素，说明当前数字可以移除前面的某些数字，直到栈顶元素大于等于当前数字或者栈为空为止。
//如果当前数字大于等于栈顶元素，直接将当前数字入栈。
//如果遍历完 num 后还没有移除足够的数字（即 k 还大于 0），则从栈顶开始弹出数字，直到 k 为 0 或者栈为空为止。
//构造新的数字时，需要注意移除前导零。
//时间复杂度：O(n)，其中 n 是字符串 num 的长度。
//空间复杂度：O(n)
        public string RemoveKdigits(string num, int k)
        {
            int n = num.Length;
            if (k >= n) return "0"; // 移除全部数字后，剩下的数字是 0

            Stack<char> stack = new Stack<char>();

            // 遍历 num 中的每个数字
            foreach (char digit in num)
            {
                // 如果栈不为空，且当前数字小于栈顶数字，且还可以继续移除数字
                while (stack.Count > 0 && digit < stack.Peek() && k > 0)
                {
                    stack.Pop(); // 移除栈顶数字
                    k--; // 更新还需要移除的数字个数
                }

                stack.Push(digit); // 当前数字入栈
            }

            // 如果 k 还大于 0，则继续从栈顶移除数字
            while (k > 0)
            {
                stack.Pop();
                k--;
            }

            // 构造结果字符串
            StringBuilder result = new StringBuilder();
            while (stack.Count > 0)
            {
                result.Insert(0, stack.Pop()); // 在结果字符串的最前面插入栈中的数字
            }

            // 去除结果字符串前导零
            int index = 0;
            while (index < result.Length && result[index] == '0')
            {
                index++;
            }

            return index == result.Length ? "0" : result.ToString().Substring(index);
        }