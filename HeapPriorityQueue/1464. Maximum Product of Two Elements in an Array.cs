//Leetcode 1464. Maximum Product of Two Elements in an Array ez
//题意： 给定一个整数数组 nums，你需要选择数组中的两个不同索引 i 和 j，返回表达式 (nums[i]-1)*(nums[j]-1) 的最大值。
//思路：PriorityQueue 用pq存从大到小，然后找出第一个第二个        
//时间复杂度: O(n)
 //空间复杂度：O(1)
        public int MaxProduct(int[] nums)
        {
            var queue = new PriorityQueue<int, int>();
            foreach (var num in nums)
            {
                queue.Enqueue(num, -num);
            }

            if (queue.Count < 2)
            {
                throw new ArgumentException();
            }
            var first = queue.Dequeue();
            var second = queue.Dequeue();

            return (first - 1) * (second - 1);
        }
        public int MaxProduct1(int[] nums)
        {
            int max = int.MinValue;
            int secondMax = int.MinValue;

            foreach (int num in nums)
            {
                if (num > max)
                {
                    secondMax = max;
                    max = num;
                }
                else if (num > secondMax) secondMax = num;
            }
            return (max - 1) * (secondMax - 1);
        }