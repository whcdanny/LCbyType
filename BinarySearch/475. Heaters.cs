//Leetcode 475. Heaters med
//题意：给定一组房屋的坐标和一组加热器的坐标，每个加热器的半径是相同的。求使每个房屋都能被加热到的最小加热半径。
//思路：二分搜索对于每个房屋，我们都找到离它最近的加热器，然后计算距离。我们的目标是最小化这些距离中的最大值。
//时间复杂度: O(N log N)，其中 N 是加热器的数量或房屋的数量，取决于两者中较大的一个。
//空间复杂度：O(1)
        public int FindRadius(int[] houses, int[] heaters)
        {
            Array.Sort(heaters);
            int radius = 0;

            foreach (var house in houses)
            {
                int index = Array.BinarySearch(heaters, house);
                if (index < 0)
                {
                    // 如果房屋位置不在加热器位置上，二分查找会返回负数
                    //Array.BinarySearch 函数如果找到了匹配的元素，会返回该元素的索引。如果未找到匹配元素，则返回一个负数，表示应该插入元素的位置。为了处理这种情况，我们使用了按位取反运算 ~ 来获取插入位置。
                    index = ~index;

                    // 计算距离
                    int leftDistance = (index > 0) ? house - heaters[index - 1] : int.MaxValue;
                    int rightDistance = (index < heaters.Length) ? heaters[index] - house : int.MaxValue;

                    // 取较小的距离作为当前房屋的最小加热半径
                    int minDistance = Math.Min(leftDistance, rightDistance);

                    // 更新全局最小加热半径
                    radius = Math.Max(radius, minDistance);
                }
                // 如果房屋位置在加热器位置上，则距离为0
            }

            return radius;
        }