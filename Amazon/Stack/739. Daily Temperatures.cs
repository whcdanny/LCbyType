//Leetcode 739. Daily Temperatures med
//题意：给定一个整数数组 temperatures 表示每天的温度，返回一个数组 answer，
//其中 answer[i] 表示在第 i 天之后需要等待多少天才能遇到比第 i 天温度更高的温度。]
//如果没有未来的日期能够达到这一温度，那么将 answer[i] 设为 0。
//思路：Stack + monotomic stack, stack里存储的是temperatures位置
//从后往前找，比我当前值大的未来的最近的一天，
//如果发现stack空了 说明没有可能变暖，所以0
//如果发现现在天气比stack最上面的气温要高，那么就把stack.pop，
//然后直到比当前天气高的，然后距离是s.Peek() - i       
//时间复杂度：O(n)，其中 n 是数组 temperatures 的长度，因为我们最多遍历数组一次。
//空间复杂度：O(n) 
        public int[] DailyTemperatures(int[] temperatures)
        {
            int n = temperatures.Length;
            int[] res = new int[n];
            // 这里放元素索引，而不是元素
            Stack<int> s = new Stack<int>();
            /* 单调栈模板 */
            for (int i = n - 1; i >= 0; i--)
            {
                while (s.Count != 0 && temperatures[s.Peek()] <= temperatures[i])
                {
                    s.Pop();
                }
                // 得到索引间距
                res[i] = s.Count == 0 ? 0 : (s.Peek() - i);
                // 将索引入栈，而不是元素
                s.Push(i);
            }
            return res;
        }