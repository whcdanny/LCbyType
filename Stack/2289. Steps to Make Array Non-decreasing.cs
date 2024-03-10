//Leetcode 2289. Steps to Make Array Non-decreasing med
//题意：给定一个整数数组 nums，每一步操作是移除数组中满足 nums[i - 1] > nums[i] 的元素 nums[i]，其中 1 < i < nums.length。
//返回执行操作直到数组 nums 变为非递减数组的步数。
//思路：Stack, 用于存储走过的位置；并且这个位置根据后加入的进行添加或者移除，再用一个array存储每个位置元素被移除在第几次历遍；
//这里思路是stack来存历遍的位置，通过这个array来判断
//如果下个位置小于之前的，那么就是看1+他之前是否还有要被一走的步数，
//如果下一个位置大于之前的，那么先获得前一个位置的array的步数，然后把之前这个位置从stack弹出，然后在继续比较，直到找到，最大的array的步数，
//这里的max_Presteps,表示如果我发现前一个数比我小，但是前一个数也是被移除的，那么两种可能性
//1是如果stack里还有数，那么就这个这里的max_Presteps+1；
//2是如果stack里吗没有了，那么就说明这个新添加的数，当前最大不可能被移除，也就是最后保留的其中一个数；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int TotalSteps(int[] nums)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            int steps = 0;
            int[] step_arr = new int[nums.Length];
            for (int i = 1; i < nums.Length; i++)
            {
                int max_Presteps = 0;
                while (stack.Count!=0 && nums[i] >= nums[(int)stack.Peek()])
                {
                    max_Presteps = Math.Max(max_Presteps, step_arr[(int)stack.Peek()]);
                    stack.Pop();
                }
                if (stack.Count != 0 && nums[i] < nums[(int)stack.Peek()])
                {
                    step_arr[i] = 1 + max_Presteps;
                }
                steps = Math.Max(steps, step_arr[i]);
                stack.Push(i);
            }
            return steps;
        }
