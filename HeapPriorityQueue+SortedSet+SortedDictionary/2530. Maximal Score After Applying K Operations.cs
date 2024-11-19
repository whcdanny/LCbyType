//Leetcode 2530. Maximal Score After Applying K Operations med
//题意：给定一个0索引的整数数组nums和一个整数k。你从0分开始。
//每次操作：
//选择一个索引i，使得0 <= i<nums.length，
//将你的分数增加nums[i]，
//将nums[i]替换为ceil(nums[i] / 3)。
//返回在恰好进行k次操作后你能达到的最大分数。
//其中，ceil(val)函数表示大于或等于val的最小整数。
//思路：PriorityQueue
//初始化一个最大堆（优先队列），用于保存每次操作后数组中元素的增加值。
//迭代k次，每次从堆中弹出最大的元素，增加分数，并更新该元素为其被操作后的新值（ceil(nums[i] / 3)）。
//返回最终的分数总和。
//时间复杂度: O(k log n)
//空间复杂度：O(n)       
        public long MaxKelements(int[] nums, int k)
        {
            long scores = 0;
            var pq = new PriorityQueue<int, int>();
            foreach (var num in nums)
                pq.Enqueue(num, -num);

            while (k-- > 0)
            {
                var num = pq.Dequeue();
                scores += num;
                num = (int)Math.Ceiling((double)num / 3);
                pq.Enqueue(num, -num);
            }

            return scores;
        }