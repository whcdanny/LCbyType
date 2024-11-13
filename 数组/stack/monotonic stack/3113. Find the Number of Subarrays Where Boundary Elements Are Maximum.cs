//Leetcode 3113. Find the Number of Subarrays Where Boundary Elements Are Maximum hard
//题目：给定一个正整数数组 nums，我们需要返回其中满足以下条件的子数组的数量：
//子数组的首尾元素等于该子数组的最大元素。
//思路: 单调栈（monotonic stack）
//用stack来存当前num和对应个数
//然后如果添加的数大于当前stack的，说明当前stack的元素小，弹出，因为较小元素不会影响当前子数组
//然后就看添加的数是否等于当前stack的数，如果就count++；如果没有就填入新的的
//然后count+当前peek.count
//时间复杂度：O(n)
//空间复杂度：O(n)
        public long NumberOfSubarrays1(int[] nums)
        {
            var stack = new Stack<(int num, int count)>();
            var counter = 0L;

            foreach (var num in nums)
            {
                //如果栈顶元素比当前元素小，表示当前元素是一个更大的数，我们弹出栈顶元素。
                //此时，栈顶的较小元素不会影响当前的子数组构造。
                while (stack.Count > 0 && stack.Peek().num < num)
                    stack.Pop();

                if (stack.TryPeek(out var peek) && peek.num == num)
                {
                    stack.Pop();
                    //当前元素和之前的相同元素构成了更多的子数组
                    ++peek.count;
                }
                else
                    //当前元素单独作为一个新的子数组起点
                    peek = (num, 1);

                //当前元素为结尾的子数组数量
                stack.Push(peek);
                counter += peek.count;
            }

            return counter;
        }