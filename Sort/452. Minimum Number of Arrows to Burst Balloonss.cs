//452. Minimum Number of Arrows to Burst Balloonss med
//题目：在一个平面墙上贴着一些球形气球，这些气球可以看作是 XY 平面上的一些区间。
//每个气球由二维数组 points 表示，其中 points[i] = [xstart, xend] 表示一个气球在  
//x-轴上的直径范围是[xstart, xend]。可以从x-轴上的任意点垂直向上射箭：
//如果一个箭的射击位置x 满足xstart≤x≤xend，则该箭会刺破这个气球。
//一个箭可以刺破路径上的所有气球。
//目标：计算刺破所有气球所需的最小箭数。
//思路：排序 逻辑就是选最小数的点，包含所有的区间
//先根据point[i][0]从小到大排序
//逻辑就是[left   right]区间
//如果下一个[i     j] 情况就是可以选[i,j]直接你能覆盖着两个区域
//如果下一个[i           j] 情况就是可以选[i,right]直接你能覆盖着两个区域
//所以先判断当前插入的points[i][0]>=left && points[i][0] <= right
//如果是那就left = points[i][0];
//有边界看是否在上一个里面还是外面right = points[i][1] > right ? right : points[i][1];
//如果不是那么更新left和right
//时间复杂度:  O(nlogn)
//空间复杂度： O(n)
        public int FindMinArrowShots(int[][] points)
        {
            Array.Sort(points, (a, b) => a[0] - b[0]);
            int left = int.MinValue;
            int right = int.MaxValue;
            int n = points.Length;
            int count = 0;
            for(int i = 0; i < n; i++)
            {
                if(points[i][0]>=left && points[i][0] <= right)
                {
                    left = points[i][0];
                    right = points[i][1] > right ? right : points[i][1];
                }
                else
                {
                    left = points[i][0];
                    right = points[i][1];
                    count++;
                }
            }
            return count;
        }