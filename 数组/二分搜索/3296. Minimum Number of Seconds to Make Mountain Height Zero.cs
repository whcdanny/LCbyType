//Leetcode 3296. Minimum Number of Seconds to Make Mountain Height Zero med
//题目：给定一个整数 mountainHeight，表示一座山的高度。同时给定一个整数数组 workerTimes，表示每个工人的工作时间（以秒为单位）。
//工人可以同时工作来降低山的高度。对于第 i 个工人：
//如果要将山的高度减少 x，所需的总时间为 workerTimes[i] + workerTimes[i] * 2 + ... + workerTimes[i] * x 秒。例如：
//要降低高度 1，需要 workerTimes[i] 秒。
//要降低高度 2，需要 workerTimes[i] + workerTimes[i] * 2 秒，以此类推。
//返回所有工人将山的高度降低到 0 所需的最小秒数。
//思路：二分查找：我们使用二分查找来寻找最少的秒数 T，使得工人们可以在时间 T 内将山的高度降低到 0。
//验证函数：在二分查找的过程中，我们需要验证当前时间 T 是否足够。具体而言，我们计算在时间 T 内，所有工人能够减少的总高度。如果总高度大于或等于 mountainHeight，则表示可以完成。
//计算公式：在给定时间 T 内，某个工人可以降低的最大高度 x 满足 workerTimes[i] + workerTimes[i] * 2 + ... + workerTimes[i] * x <= T。
//这等价于求解公式 x * (x + 1) / 2 * workerTimes[i] <= T。
//x^2 + x = 2T/workerTimes[i];
//x^2 + x = C (C=2T/workerTimes[i] )
//x^2 + x - C = 0;
//𝑥=(−𝑏±sqrt(𝑏^2−4𝑎𝑐)/2𝑎)
//把C带入就得到x；
//通过二分搜索，然后可以找到最小的时间把山降低；
//时间复杂度：二分查找的时间复杂度为 O(log(maxTime))。每次验证的时间复杂度为 O(n)，其中 n 为工人的数量。总时间复杂度为 O(n* log(maxTime))。
//空间复杂度：O(1) 
        public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
        {
            long minTime = 0;
            long maxTime = long.MaxValue;

            while (minTime < maxTime)
            {
                long averageTime = (minTime + maxTime) / 2;

                if (CanReduceHeightInTime(averageTime, mountainHeight, workerTimes))
                {
                    maxTime = averageTime;
                }
                else
                {
                    minTime = averageTime + 1;
                }
            }

            return minTime;
        }

        private bool CanReduceHeightInTime(long time, int mountainHeight, int[] workerTimes)
        {
            long totalReduceHeight = 0;

            foreach (var workerTime in workerTimes)
            {
                totalReduceHeight += (-1 + (long)(Math.Sqrt(1 + 4 * 2 * time / workerTime))) / 2;

                if (totalReduceHeight >= mountainHeight)
                    return true;
            }

            return totalReduceHeight >= mountainHeight;
        }