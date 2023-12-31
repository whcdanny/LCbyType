//Leetcode 2070. Most Beautiful Item for Each Query med
//题意：给定一个二维整数数组 items，其中 items[i] = [pricei, beautyi] 表示一个商品的价格和美丽度。
//同时给定一个从 0 开始的整数数组 queries。对于每个 queries[j]，你希望确定一个价格小于或等于 queries[j] 的商品的最大美丽度。如果不存在这样的商品，则该查询的答案为 0。
//返回一个与 queries 长度相同的数组 answer，其中 answer[j] 是第 j 个查询的答案。
//思路：二分搜索, 先将items根据[0]排序，然后从头开始 找[i][0]和[i-1][0]哪个更大，然后更新；然后每一次queries都要二分法查找最大值；        
//时间复杂度: 对于每个查询，使用二分查找的时间复杂度为 O(log n)。总体时间复杂度为 O(q* log n)，其中 q 是查询的数量，n 是商品的数量。
//空间复杂度：O(1)       
        public int[] MaximumBeauty(int[][] items, int[] queries)
        {
            int n = queries.Length, m = items.Length;
            Array.Sort(items, (a, b) => a[0].CompareTo(b[0]));
            int[] ans = new int[n];

            for (int i = 0; i < m; i++)
                items[i][1] = Math.Max(items[i][1], items[i > 0 ? i - 1 : 0][1]);

            int j = 0;
            foreach (int q in queries)
            {
                int low = -1, high = m - 1; 
                while (low < high)
                {
                    int mid = low + (high - low) / 2 + 1;
                    if (q >= items[mid][0]) 
                        low = mid;
                    else 
                        high = mid - 1;
                }
                ans[j++] = low == -1 ? 0 : items[low][1];
            }

            return ans;
        }