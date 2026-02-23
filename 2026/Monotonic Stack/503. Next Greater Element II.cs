//Leetcode 503. Next Greater Element II med
//题意：给一个数组，找出每个位置，下一个大的数是多少，如果没有就是-1；
//注意这是个环形，也就是说最后一个数，可能下一个最大数是第一个；
//思路：单调栈（Monotonic Stack），
//第一遍历遍，stack存入数的位置，
//如果下一个比当前stack位置数大，那么stack当前位置的的下一个大的数就是当前数；
//如果没有，那么就存入位置
//第二遍历遍，因为是环形所以还要再找数组末尾那些，是否有数组前面的数满足条件
//这里不再存入stack，而是找当前i的位置小于stack当前位置的并且数大于的
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int[] NextGreaterElements(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            Stack<int> stack = new Stack<int>();
            for(int i = 0; i < n; i++)
            {
                while(stack.Count>0 && nums[i] > nums[stack.Peek()])
                {
                    res[stack.Pop()] = nums[i];
                }
                stack.Push(i);
            }
            for(int i = 0; i < n; i++)
            {
                while(stack.Count>0 && i < stack.Peek() && nums[i] > nums[stack.Peek()])
                {
                    res[stack.Pop()] = nums[i];
                }
            }
            while (stack.Count > 0)
            {
                res[stack.Pop()] = -1;
            }
            return res;
        }