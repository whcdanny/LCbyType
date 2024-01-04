//Leetcode 1870. Minimum Speed to Arrive on Time med
//题意：题目描述了一位上班族要在规定的时间内通过 n 趟火车路程到达办公室。每趟火车都有对应的行驶距离，表示为一个浮点数。由于每趟火车只能在整点发车，可能需要在两趟火车之间等待。
//给定一个浮点数 hour，表示到达办公室的剩余时间。还给定一个整数数组 dist，表示每趟火车的行驶距离。问题要求返回一个最小的正整数速度，使得在这个速度下，通过所有火车路程能够在规定时间内到达办公室。如果无法在规定时间内到达，则返回
//思路：用二分法定义一个二分搜索的左边界 left 和右边界 right。left 的初始值为 1，right 的初始值为 10^7，因为题目明确给定了速度不会超过 10^7。
//在二分搜索的每一步，计算中间速度 mid，然后判断以该速度是否能够在规定时间内到达办公室。
//如果可以到达，将右边界 right 缩小到 mid；否则，将左边界 left 扩大到 mid + 1。
//重复上述步骤，直到左边界 left 大于等于右边界 right。
//时间复杂度: 计算的时间复杂度为 O(n)，其中 n 是火车的数量。因此，总体时间复杂度为 O(n log 10^7)，其中 n 是火车的数量。
//空间复杂度：O(1)
        public int MinSpeedOnTime(int[] dist, double hour)
        {
            int left = 1;
            int right = (int)1e7;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (CanReachOffice(dist, hour, mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return CanReachOffice(dist, hour, left) ? left : -1;
        }
        private bool CanReachOffice(int[] dist, double hour, int speed)
        {
            double totalTime = 0;

            for (int i = 0; i < dist.Length - 1; i++)
            {
                totalTime += Math.Ceiling((double)dist[i] / speed);
            }

            totalTime += (double)dist[dist.Length - 1] / speed;

            return totalTime <= hour;
        }