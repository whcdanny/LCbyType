//239. Sliding Window Maximum hard
//给你输入一个数组 nums 和一个正整数 k，有一个大小为 k 的窗口在 nums 上从左至右滑动，请你输出每次窗口中 k 个元素的最大值。
//思路：单调队列结构解决滑动窗口问题
		class MonotonicQueue
        {
            LinkedList<int> maxq = new LinkedList<int>();
            public void push(int n)
            {
                // 将小于 n 的元素全部删除
                while (maxq.Count!=0 && maxq.Last() < n)
                {
                    maxq.RemoveLast();
                }
                // 然后将 n 加入尾部
                maxq.AddLast(n);
            }

            public int max()
            {
                return maxq.First();
            }

            public void pop(int n)
            {
                if (n == maxq.First())
                {
                    maxq.RemoveFirst();
                }
            }
        }

        /* 解题函数的实现 */
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            MonotonicQueue window = new MonotonicQueue();
            List<int> res = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i < k - 1)
                {
                    //先填满窗口的前 k - 1
                    window.push(nums[i]);
                }
                else
                {
                    // 窗口向前滑动，加入新数字
                    window.push(nums[i]);
                    // 记录当前窗口的最大值
                    res.Add(window.max());
                    // 移出旧数字
                    window.pop(nums[i - k + 1]);
                }
            }
            // 需要转成 int[] 数组再返回
            int[] arr = new int[res.Count];
            for (int i = 0; i < res.Count; i++)
            {
                arr[i] = res[i];
            }
            return arr;
        }
        public int[] MaxSlidingWindow1(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return new int[0];
            int[] result = new int[nums.Length - k + 1];
            LinkedList<int> deque = new LinkedList<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (deque.Count != 0 && deque.First.Value == i - k)
                    deque.RemoveFirst();
                while (deque.Count != 0 && nums[i] >= nums[deque.Last.Value])
                    deque.RemoveLast();
                deque.AddLast(i);
                if (i >= k - 1)
                    result[i - k + 1] = nums[deque.First.Value];
            }
            return result;
        }