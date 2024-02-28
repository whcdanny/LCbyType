//Leetcode 912. Sort an Array med
//题意：给定一个整数数组 nums，将数组按升序排序并返回。
//要求在 O(nlog(n)) 的时间复杂度内解决问题，并且尽可能地减小空间复杂度。
//思路：PriorityQueue, 自动存入从小到大，然后再存入nums中
//时间复杂度: O(nlogn)
//空间复杂度：O(n)
        public int[] SortArray(int[] nums)
        {
            var pq = new PriorityQueue<int, int>();
            foreach (var num in nums)
                pq.Enqueue(num, num);

            for (var i = 0; i < nums.Length; i++)
            {
                nums[i] = pq.Dequeue();
            }
            return nums;
        }