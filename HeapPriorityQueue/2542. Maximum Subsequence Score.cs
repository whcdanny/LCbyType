//Leetcode 2542. Maximum Subsequence Score med
//题意：给定两个长度相等的整数数组 nums1 和 nums2，以及一个正整数 k。
//需要从 nums1 中选择一个长度为 k 的子序列，并计算得分。得分的计算方式为选择的元素之和乘以 nums2 中对应位置元素的最小值。求能够达到的最大得分。
//思路：PriorityQueue
//因为要找nums2的最小值和num1的k个元素，那么先把num2从大到小排序，
//然后假设每个num2都是最小的，数找到相对应的k个num1的和，然后找出最大的；
//所以PriorityQueue保留当前k个最大的数，然后sum根据进出进行+-；        
//时间复杂度: O(nlogn)
//空间复杂度：O(k)       
        public long MaxScore(int[] nums1, int[] nums2, int k)
        {
            int n = nums1.Length;
            var arr = new List<(long, long)>();
            for (int i = 0; i < n; i++)
            {
                arr.Add((nums2[i], nums1[i]));
            }

            arr.Sort((a, b) => b.Item1.CompareTo(a.Item1));

            var pq = new PriorityQueue<long, long>();
            long minVal = long.MaxValue;
            long sum = 0;
            long ret = 0;
            for (int i = 0; i < n; i++)
            {
                minVal = arr[i].Item1;
                sum += arr[i].Item2;
                pq.Enqueue(arr[i].Item2, arr[i].Item2);
                if (pq.Count > k)
                {
                    sum -= pq.Dequeue();
                }
                if (pq.Count == k)
                {
                    ret = Math.Max(ret, sum * minVal);
                }
            }
            return ret;
        }