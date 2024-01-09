//Leetcode 875. Koko Eating Bananas med
//题意：有 N 堆香蕉，每堆香蕉中有一定数量的香蕉。一名工人每小时可以选择一堆香蕉，每小时吃掉其中的某个数量的香蕉，然后将剩余的香蕉移到一边。工人在 H 小时内要吃掉所有的香蕉，找到最小的速度 K（每小时吃掉的香蕉数量），使得工人能够在 H 小时内吃掉所有香蕉。
//思路：二分搜索找确定搜索范围：工人每小时可以吃香蕉的速度范围在[1, max(piles)] 之间，其中 max(piles) 表示香蕉堆中最多的香蕉数量。
//二分搜索：在给定速度范围内进行二分搜索，每次尝试一个中间值作为每小时吃香蕉的速度 K。对于每个速度 K，计算工人在 H 小时内能够吃掉香蕉的总数量。如果总数量小于香蕉的总数量，说明速度太慢，需要在右侧搜索；否则，在左侧搜索。
//计算总数量：对于每个速度 K，计算工人在 H 小时内能够吃掉的香蕉总数量，即遍历香蕉堆，使用上取整运算计算需要的小时数。
//时间复杂度: O(log(max(piles)) * n)，其中 n 为香蕉堆的数量。
//空间复杂度：O(1)。
        public int MinEatingSpeed(int[] piles, int H)
        {
            int left = 1, right = piles.Max();

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int hours = CalculateHours(piles, mid);

                if (hours > H)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        private int CalculateHours(int[] piles, int speed)
        {
            int hours = 0;
            foreach (var pile in piles)
            {
                hours += (int)Math.Ceiling((double)pile / speed);
            }
            return hours;
        }