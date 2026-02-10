//Leetcode 739. Daily Temperatures med
//题意：给一个int[]的天气，找出当天需要等多少天气温会变高，
//思路：单调栈（Monotonic Stack），这里存入递减的气温天数，
//当curTemp大于stack最上面这个天数气温，就可以找出i-stack.Pop()的天之后气温升高
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int[] DailyTemperatures(int[] temperatures)
        {
            int n = temperatures.Length;
            int[] res = new int[n];
            Stack<int> stack = new Stack<int>();
            for(int i = 0; i < n; i++)
            {                
                while(stack.Count>0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    int day = stack.Pop();
                    res[day] = i - day;
                }
                stack.Push(i);
            }            
            return res;
        }