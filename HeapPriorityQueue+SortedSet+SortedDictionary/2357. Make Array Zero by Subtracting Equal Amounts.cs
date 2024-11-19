//Leetcode 2357. Make Array Zero by Subtracting Equal Amounts ez
//题意：给定一个非负整数数组 nums。在一次操作中，你必须执行以下操作：
//选择一个正整数 x，使得 x 小于等于 nums 中最小的非零元素。
//从 nums 中的每个正整数中减去 x。
//返回使 nums 中的每个元素都等于 0 的最小操作次数。
//思路：PriorityQueue 
//把所有数放入，然后pq出的是最小的num，然后把所有剩余的pq中的数-num，然后再循环，直到所有都为0；
//时间复杂度: O(n^3)
//空间复杂度：O(1)       
        public int MinimumOperations(int[] nums)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            foreach (var num in nums)
            {
                pq.Enqueue(num, num);
            }

            int res = 0;

            while (pq.Count > 0)
            {
                if (pq.Peek() == 0)
                {
                    pq.Dequeue();
                    continue;
                }

                res++;
                int sub = pq.Dequeue();
                int count = pq.Count;
                IList<int> newNums = new List<int>();

                while (count-- > 0)
                {
                    int num = pq.Dequeue() - sub;
                    newNums.Add(num);
                }

                foreach (var newNum in newNums)
                {
                    pq.Enqueue(newNum, newNum);
                }
            }

            return res;
        }
        //我们首先找到数组中的最小非零元素 minNonZero。
        //然后我们将 minNonZero 减去数组中所有正整数，并统计操作次数。
        //重复以上步骤，直到数组中不再有正整数为止。
        //时间复杂度: O(n^2)
        //空间复杂度：O(1)       
        public int MinimumOperations1(int[] nums)
        {
            int n = nums.Length;
            int operations = 0;

            while (true)
            {
                // Find the smallest non-zero element
                int minNonZero = int.MaxValue;
                foreach (int num in nums)
                {
                    if (num > 0 && num < minNonZero)
                    {
                        minNonZero = num;
                    }
                }

                // If no positive elements found, break
                if (minNonZero == int.MaxValue)
                {
                    break;
                }

                // Subtract minNonZero from all positive elements
                for (int i = 0; i < n; i++)
                {
                    if (nums[i] > 0)
                    {
                        nums[i] -= minNonZero;
                    }
                }

                // Increment operations
                operations++;
            }

            return operations;
        }