//739. Daily Temperatures med
//每日温度，给出到第几天比今天暖和，最后输出天数list
//思路：利用stack存入位置，然后根据温度的差值，如果小就算差数天；
		public int[] DailyTemperatures(int[] temperatures)
        {
            int n = temperatures.Length;
            int[] res = new int[n];
            // 这里放元素索引，而不是元素
            Stack<int> s = new Stack<int>();
            /* 单调栈模板 */
            for (int i = n - 1; i >= 0; i--)
            {
                while (s.Count!=0 && temperatures[s.Peek()] <= temperatures[i])
                {
                    s.Pop();
                }
                // 得到索引间距
                res[i] = s.Count==0 ? 0 : (s.Peek() - i);
                // 将索引入栈，而不是元素
                s.Push(i);
            }
            return res;
        }