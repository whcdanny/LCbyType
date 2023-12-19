//Leetcode 2594. Minimum Time to Repair Cars  med
//题意：您将获得一个整数数组ranks，代表某些机制的等级。 rank 是 i机械师。等级为r的机械师可以修理 n cars in r * n2 minutes.您还会获得一个整数cars，表示车库中等待维修的汽车总数。
//返回修理所有汽车所需的最短时间。
//思路：二分搜索, 先将ranks排序，由于时间是线性增加的，所以我们可以使用二分查找, 该函数用于检查给定时间是否足够修理所有汽车。
//注：第 i 个机械师在x分钟内修理的汽车数量
//时间复杂度:  O(log(M * N))，其中 M 是排名数组的最大长度，N 是 cars 的数量
//空间复杂度： O(1)
        public long RepairCars(int[] ranks, int cars)
        {
            Array.Sort(ranks);
            long left = 0;
            long right = ((long)ranks[0]) * cars * cars;

            while (left < right)
            {
                long mid = left + (right - left) / 2;

                if (CanRepairAllCars(ranks, cars, mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }
        private bool CanRepairAllCars(int[] ranks, int cars, long time)
        {
            long totalCarsRepaired = 0;

            foreach (int rank in ranks)
            {
                totalCarsRepaired += (int)Math.Sqrt(1.0d * time / rank);
            }
            // Check if the total cars repaired by all mechanics is enough
            if (totalCarsRepaired >= cars)
                return true;

            return false;
        }