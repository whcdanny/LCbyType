//Leetcode 2187. Minimum Time to Complete Trips med
//题意：题目给定一个数组 time，其中 time[i] 表示第 i 辆公交车完成一次行程所需的时间。
//每辆公交车可以连续进行多次行程，即下一次行程可以立即在完成当前行程后开始。此外，每辆公交车的行程是独立的，即一辆公交车的行程不会影响其他公交车的行程。
//同时，给定一个整数 totalTrips，表示所有公交车应该共完成的行程次数。要求返回使所有公交车完成至少 totalTrips 次行程所需的最短时间。
//思路：二分搜索：将时间进行二分，这里left是1，因为时间必须从1开始，那么right是time里最小的*totalTrips，然后进行二分搜索；
//注：这里判定是用猜测值/每一个车的时间，然后相加，如果>=totalTrips，说明left移动，否则right动；        
//时间复杂度: O(n∗log(totalTrips∗min)
//空间复杂度：O(1)
        public long MinimumTime(int[] time, int totalTrips)
        {
            int min = time.Min();
            long left = 1;
            long right = (long)totalTrips * min;
            while (left < right)
            {
                long mid = left + (right - left) / 2;
                if (CalculateTrips(time, mid, totalTrips))
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

        private bool CalculateTrips(int[] time, long current, int totalTrips)
        {
            long total = 0;
            for (int j = 0; j < time.Length; j++)
            {
                total += current / time[j];
                if (total >= totalTrips)
                {
                    return false;
                }
            }
            return true;
        }