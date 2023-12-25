//Leetcode 2234. Maximum Total Beauty of the Gardens hard
//题意：Alice是n个花园的园丁，她想要种植花朵以最大化所有花园的总美观度。
//给定一个大小为n的整数数组flowers，其中flowers[i] 表示第i个花园中已经种植的花朵数量。已经种植的花朵不能被移除。然后给出另一个整数newFlowers，表示Alice最多可以额外种植的花朵数量。还给出整数target、full和partial。
//一个花园被认为是完整的，如果它至少有target朵花。然后花园的总美观度由以下几部分组成：
//完整花园的数量乘以full。
//任何不完整花园中的最小花朵数量乘以partial。如果没有不完整的花园，则此值为0。
//返回Alice在最多种植newFlowers朵花后可以获得的最大总美观度。
//思路：二分搜索，
//先看现有的flowers是否有满足的；我们只需要flowers里不满足的里面用二分法；
//现在都是不满足的：
//找到一个p位置，是将低于target的花园 满足当前到p的总和+新花大于当前p的总和* p+1，这个p就是设置的最小数量如果不满足target；
//preSum[p]+newFlower>=nums[p]*(p+1) =》 nums[p]*(p+1) - preSum[p]<= newFlower 这就是二分搜索的判定点；
//换句话说，如果我找到p这个位置当前nums[p]小于target 我只有让p到0这些花园的数量跟p一样，然后我看看我需要插入多少花，如果在newflowers范围里，那么这就是极限p；       
//注：算的时候要每次跟res进行Math.Max比较，因为full有可能很小，partial可能很大；并且最后结果要+之前已经满足的target数量*full；
//时间复杂度: O(n log n)，其中 n 是花园的数量
//空间复杂度：O(n)            
        public long MaximumBeauty(int[] flowers, long newFlowers, int target, int full, int partial)
        {
            int length = flowers.Count();
            Array.Sort(flowers);
            long res = 0;
            long res0 = 0;
            long countComplete = 0;
            int n;
            for (n=length-1; n >= 0; n--)
            {
                if (flowers[n] < target)
                    break;
                countComplete++;
            }
            if (countComplete == length)
                return ((countComplete * (long)full));
            res0 = countComplete * (long)full;
            //找到一个p位置，是将低于target的花园 满足当前到p的总和+新花大于当前p的总和*p+1，这个p就是设置的最下数量如果不满足target；
            //preSum[p]+newFlower>=nums[p]*(p+1)
            n += 1;
            long[] preSum = new long[n];
            for(int i = 0; i < n; i++)
            {
                preSum[i] = (i == 0 ? 0 : preSum[i - 1]) + flowers[i];
            }
            long[] diff = new long[n+1];
            for (int i = 0; i < n; i++)
            {
                diff[i] = (long)flowers[i] * (i + 1) - preSum[i];
            }
            
            for(int i = n-1 ; i >= 0; i--)
            {
                if (newFlowers < 0)
                    break;
                if(preSum[i] + newFlowers >= (long)(i + 1) * (target - 1))
                {
                    res = Math.Max(res, (long)(target - 1) * partial + (long)(n - 1- i) * full);
                }
                else
                {
                    int p = binarySearch_MaximumBeauty(diff, newFlowers, 0, i);
                    //int p = preSum[index] - diff[0];
                    long total = preSum[p] + newFlowers;
                    long each = total / (p + 1);
                    res = Math.Max(res, each * partial + (long)(n - 1 - i) * full);
                }
                newFlowers -= (target - flowers[i]);
            }
            if (newFlowers >= 0)
            {
                res = Math.Max(res, n * full);
            }
            return res + res0;
        }

        public int binarySearch_MaximumBeauty(long[] diff, long newFlowers, int start, int end)
        {            
            while (start < end)
            {
                int mid = (start + end) / 2;
                if (diff[mid] <= newFlowers)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }
            return diff[start] <= newFlowers ? start : (start - 1);
        }
		
		
		
		public long MaximumBeauty1(int[] flowers, long newFlowers, int target, int full, int partial)
        {
            int len = flowers.Length;
            long[] cumulativeCostArray = new long[len];
            Array.Sort(flowers);
            long[] preSum = new long[len];

            for (int k = 1; k < len; k++)
            {
                cumulativeCostArray[k] = cumulativeCostArray[k - 1] + (long)k * (flowers[k] - flowers[k - 1]);
            }

            long max = 0;
            int i;
            int countComplete = 0;
            for (i = len - 1; i >= 0; i--)
            {
                if (flowers[i] < target)
                    break;
                countComplete++;
            }

            if (countComplete == len)
                return ((countComplete * (long)full));

            int id = binarySearchCumulativeCost1(cumulativeCostArray, newFlowers, 0, i);
            max = currentPartitionCost(flowers, newFlowers, target, full, partial, cumulativeCostArray, max, countComplete, id);

            for (int j = i; j >= 0; j--)
            {
                newFlowers = newFlowers - (target - flowers[j]);
                if (newFlowers < 0)
                    break;
                countComplete++;
                if (j == 0)
                {
                    max = Math.Max(max, countComplete * (long)full);
                    break;
                }
                id = binarySearchCumulativeCost1(cumulativeCostArray, newFlowers, 0, j - 1);
                max = Math.Max(max, currentPartitionCost(flowers, newFlowers, target, full, partial, cumulativeCostArray, max,
                        countComplete, id));
            }

            return max;
        }

        private long currentPartitionCost(int[] flowers, long newFlowers, int target, int full, int partial,
                long[] costArray, long max, int countComplete, int id)
        {
            if (id >= 0)
            {
                long rem = (newFlowers - costArray[id]);
                long minToAddFromRem = rem / (id + 1);
                max = ((countComplete * (long)full) + ((Math.Min(target - 1, minToAddFromRem + flowers[id])) * (long)partial));
            }
            return max;
        }
        public int binarySearchCumulativeCost1(long[] cost, long num, int s, int e)
        {
            int i = s, j = e;
            while (i < j)
            {
                int mid = (i + j) / 2;
                if (cost[mid] <= num)
                {
                    i = mid + 1;
                }
                else
                {
                    j = mid;
                }
            }
            return cost[i] <= num ? i : (i - 1);
        }