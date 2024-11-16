//Leetcode 373. Find K Pairs with Smallest Sums med
//题意：给定两个非递减排序的整数数组 nums1 和 nums2，以及一个整数 k。
//定义一个由一个来自第一个数组和一个来自第二个数组组成的对(u, v)。
//返回前 k 对(u1, v1), (u2, v2), ..., (uk, vk) 中具有最小和的对。
//思路：PriorityQueue, 
//检查当前对的总和是否大于队列中的 maxValue，在这种情况下，中断内部循环，之后的所有对都具有更大的总和。
//插入队列, 检查队列大小是否大于 k，在这种情况下，将总和最大的项出队，并更新 maxValue
//时间复杂度: n^2*log(k)
//空间复杂度：O(k)   
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var pq = new PriorityQueue<List<int>, int>(Comparer<int>.Create((x, y) => y - x));
            int maxValue = int.MaxValue;
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    //得pq已经有k个，找出pq中的最大值，这样如果加入的和比这个大，就不用添加，优化；
                    if (nums1[i] + nums2[j] >= maxValue && pq.Count == k)
                    {
                        break;
                    }
                    pq.Enqueue(new List<int> { nums1[i], nums2[j] }, nums1[i] + nums2[j]);

                    if (pq.Count > k)
                    {
                        pq.Dequeue();
                        int curSum;
                        pq.TryPeek(out _, out curSum);
                        maxValue = curSum;
                    }
                }
            }
            List<IList<int>> result = new List<IList<int>>();
            while (pq.Count > 0)
            {
                result.Add(pq.Dequeue());
            }
            return result;
        }