//Leetcode 2104. Sum of Subarray Ranges med
//题意：要求计算给定整数数组nums的所有子数组范围的和。子数组的范围定义为子数组中最大元素和最小元素的差。
//思路：Stack, Monotonic Stack,找出prevSmaller，nextSmaller， prevGreater， nextGreater
//prevSamller 严格小于的，nextSmaller 是小或等于；prevGreater， nextGreater 同样道理；
//i相当于以i为最大或最小点，找出区间范围[l,i,r]
//因为res相当于每个区间的max-min，所以先算以i为最大的有多少种，result += (long)nums[i] * (i - l) * (r - i);
//同理以i为最小的有多少种result-=(long)nums[i] * (i - l) * (r - i);
//时间复杂度：O(n)
//空间复杂度：O(n)
		public long SubArrayRanges1(int[] nums)
        {            
            Stack<int> stack = new Stack<int>();
            long result = 0;
            int[] prevSmaller = new int[nums.Length];
            int[] nextSmaller = new int[nums.Length];
            Array.Fill(nextSmaller, nums.Length);
            Array.Fill(prevSmaller, -1);
            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] > nums[i])
                {
                    nextSmaller[stack.Peek()] = i;
                    stack.Pop();
                }                
                stack.Push(i);
            }

            stack.Clear();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] >= nums[i])
                {
                    prevSmaller[stack.Peek()] = i;
                    stack.Pop();
                }                
                stack.Push(i);
            }
            int[] prevGreater = new int[nums.Length];
            int[] nextGreater = new int[nums.Length];
            Array.Fill(nextGreater, nums.Length);
            Array.Fill(prevGreater, -1);
            stack.Clear();
            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] < nums[i])
                {
                    nextGreater[stack.Peek()] = i;
                    stack.Pop();
                }                
                stack.Push(i);
            }
            stack.Clear();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] <= nums[i])
                {
                    prevGreater[stack.Peek()] = i;
                    stack.Pop();
                }                
                stack.Push(i);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int l = prevGreater[i];
                int r = nextGreater[i];
                result += (long)nums[i] * (i - l) * (r - i);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int l = prevSmaller[i];
                int r = nextSmaller[i];
                result -= (long)nums[i] * (i - l) * (r - i);
            }

            return result;
        }
        public long SubArrayRanges(int[] nums)
        {
            int MOD = (int)1e9 + 7;
            Stack<int> stack = new Stack<int>();
            long result = 0;
            int[] prevSmaller = new int[nums.Length];
            int[] nextSmaller = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] > nums[i])
                {
                    stack.Pop();
                }
                prevSmaller[i] = stack.Count > 0 ? stack.Peek() : -1;
                stack.Push(i);
            }

            stack.Clear();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] >= nums[i])
                {
                    stack.Pop();
                }
                nextSmaller[i] = stack.Count > 0 ? stack.Peek() : nums.Length;
                stack.Push(i);
            }
            int[] prevGreater = new int[nums.Length];
            int[] nextGreater = new int[nums.Length];

            stack.Clear();
            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] < nums[i])
                {
                    stack.Pop();
                }
                prevGreater[i] = stack.Count > 0 ? stack.Peek() : -1;
                stack.Push(i);
            }
            stack.Clear();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] <= nums[i])
                {
                    stack.Pop();
                }
                nextGreater[i] = stack.Count > 0 ? stack.Peek() : nums.Length;
                stack.Push(i);
            }
            for(int i = 0; i < nums.Length; i++)
            {
                int l = prevGreater[i];
                int r = nextGreater[i];
                result += (long)nums[i] * (i - l) * (r - i);
            }
            for(int i = 0; i < nums.Length; i++)
            {
                int l = prevSmaller[i];
                int r = nextSmaller[i];
                result-=(long)nums[i] * (i - l) * (r - i);
            }        
          
            return result;
        }