//Leetcode 3111. Minimum Rectangles to Cover Points med
//题目：给定一个二维整数数组 points，其中 points[i] = [xi, yi]，表示一个点的坐标。还给定一个整数 w，你需要用矩形来覆盖所有给定的点。
//每个矩形的下边缘位于某个点(x1, 0)，上边缘位于(x2, y2)，要求满足 x1 <= x2 且 y2 >= 0，并且矩形的宽度 x2 - x1 必须小于等于 w。
//如果一个点位于矩形的边界内或者矩形内部，则该点被认为是被覆盖的。
//请返回覆盖所有点所需的最小矩形数量。每个点可能被多个矩形覆盖。
//思路: 滑窗，说白了就是看x2 - x1<=w
//所以先把points按照从小到大来排序，
//然后先固定x1然后找到满足条件的x2,如果超过w然后rectangles++;
// 更新 i 为下一个未覆盖点的索引
//时间复杂度：O(n log n)
//空间复杂度：O(n)
        public int MinRectanglesToCoverPoints(int[][] points, int w)
        {
            // 将点按照 x 坐标排序
            var sortedPoints = points.OrderBy(p => p[0]).ToList();
            int n = sortedPoints.Count;
            int rectangles = 0;
            int i = 0;

            // 使用滑动窗口方法来找最少矩形数量
            while (i < n)
            {
                int x1 = sortedPoints[i][0]; // 当前矩形的起始 x 坐标                
                int j = i;

                // 选择一个最大范围的矩形，直到 x2 - x1 超过 w
                while (j < n && sortedPoints[j][0] - x1 <= w)
                {
                    // 更新矩形的最大高度                    
                    j++;
                }

                // 选定一个矩形，可以覆盖从 i 到 j - 1 的点
                rectangles++;
                i = j; // 更新 i 为下一个未覆盖点的索引
            }

            return rectangles;
        }