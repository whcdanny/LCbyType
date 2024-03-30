//Leetcode 2848. Points That Intersect With Cars ez
//题意：给定一个表示汽车停放在数轴上的坐标的二维整数数组 nums。
//对于任何索引 i，nums[i] = [starti, endi]，其中 starti 是第 i 辆车的起点，endi 是第 i 辆车的终点。
//返回被任何一辆汽车的任何部分覆盖的数轴上的整数点的数量。
//思路：hashtable，先找到最小开始和最大结束对于所有的车
//然后在让每一辆车都去在这个范围的每一个点去找，如果有一辆车在这个点上，那么就可以了 就不用算其他车；       
//时间复杂度：O(n)
//空间复杂度：O(n)

        public int NumberOfPoints(IList<IList<int>> nums)
        {
            int minStart = int.MaxValue;
            int maxEnd = int.MinValue;

            // 找到所有车辆覆盖的最小起点和最大终点
            foreach (var car in nums)
            {
                minStart = Math.Min(minStart, car[0]);
                maxEnd = Math.Max(maxEnd, car[1]);
            }

            int count = 0;

            // 统计数轴上被覆盖的整数点的数量
            for (int i = minStart; i <= maxEnd; i++)
            {
                foreach (var car in nums)
                {
                    if (i >= car[0] && i <= car[1])
                    {
                        count++;
                        break; // 如果一个点被覆盖了，就不用继续检查其他车辆了
                    }
                }
            }

            return count;
        }