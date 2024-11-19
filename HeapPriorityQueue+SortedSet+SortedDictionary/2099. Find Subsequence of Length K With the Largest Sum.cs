//Leetcode 2099. Find Subsequence of Length K With the Largest Sum ez
//题意：要找到整数数组 nums 中长度为 k 的子序列，使得其和最大
//思路：PriorityQueue 存入最大k个值，然后在用PriorityQueue排序根据index，然后根据index输出ans
//时间复杂度: O(n)
//空间复杂度：O(k)
        public int[] MaxSubsequence(int[] nums, int k)
        {
            int[] ans = new int[k];

            var priorityQueue = new PriorityQueue<(int, int), int>();

            for (int i = 0; i < nums.Length; i++)
            {
                priorityQueue.Enqueue((nums[i], i), nums[i]);
                if (priorityQueue.Count > k)
                {
                    priorityQueue.Dequeue();
                }
            }
            var queue = new PriorityQueue<int, int>();
            // Another min heap for sorting based on index value.
            for (int i = 0; i < k; i++)
            {
                (int numvalue, int index) = priorityQueue.Dequeue();
                queue.Enqueue(numvalue, index);
                
            }
            for (int i = 0; i < k; i++)
            {
                ans[i] = queue.Peek();
                queue.Dequeue();
            }
            return ans;
        }