//Leetcode 1011. Capacity To Ship Packages Within D Days med
//题意：题目要求在 D 天内将货物运送到目的地，货物按照给定的顺序摆放在一条水平线上。每天，你都可以选择运送一些货物，但运送的货物必须按照给定的顺序，并且每次运送的货物数量不能超过给定的容量。目标是找到最小的容量，使得在 D 天内能够将所有货物运送到目的地。
//思路：二分搜索这个问题可以通过二分查找来解决。对于二分查找，我们可以将搜索的范围设定为 [left, right]，其中 left 表示货物的最大重量，而 right 表示货物的总重量。通过不断调整搜索范围，找到最小的 left，使得在 D 天内能够将所有货物运送到目的地。
//时间复杂度: O(log(N) * N)，其中 N 是货物的总数量
//空间复杂度：O(1)
        public int ShipWithinDays(int[] weights, int D)
        {
            int left = weights.Max();  // 初始搜索范围 [left, right]，left 是货物的最大重量
            int right = weights.Sum();  // right 是货物的总重量

            while (left <= right)
            {
                int mid = left + (right - left) / 2;  // 计算中间值

                // 模拟货物运输过程，计算需要的天数
                int days = 1;
                int currentWeight = 0;

                foreach (var weight in weights)
                {
                    if (currentWeight + weight > mid)
                    {
                        days++;
                        currentWeight = 0;
                    }
                    currentWeight += weight;
                }

                // 根据需要的天数调整搜索范围
                if (days <= D)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }