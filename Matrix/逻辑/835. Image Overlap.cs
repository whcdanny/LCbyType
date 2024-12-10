//Leetcode 835. Image Overlap med
//题意：给定两个图片 img1 和 img2，它们是二进制的方阵，大小为 n×n。二进制矩阵中只有 0 和 1。
//我们可以通过平移任意方向（上下左右）来移动 img1。
//将 img1 放在 img2 上方，计算它们的重叠面积，即在相同位置都为 1 的单元格数量。
//注意：平移只能移动，不包含旋转操作。如果 1 被平移到了矩阵边界之外，就会被擦除。
//要求返回最大可能的重叠面积。
//思路：找到 img1 和 img2 中所有值为 1 的坐标点。
//计算每对点之间的偏移量，并统计每种偏移量对应的重叠次数。
//返回重叠次数的最大值。
//时间复杂度:  O(k^2)设矩阵大小为 n×n，1 的个数为 k
//空间复杂度： O(k^2)
        public int LargestOverlap(int[][] img1, int[][] img2)
        {
            List<(int x, int y)> points1 = getOnes(img1);
            List<(int x, int y)> points2 = getOnes(img2);

            Dictionary<(int dx, int dy), int> offsetCount = new Dictionary<(int dx, int dy), int>();
            int res = 0;
            foreach(var p1 in points1)
            {
                foreach(var p2 in points2)
                {
                    (int dx, int dy) = (p2.x - p1.x, p2.y - p1.y);
                    if(!offsetCount.ContainsKey((dx, dy))){
                        offsetCount[(dx, dy)] = 0;
                    }
                    offsetCount[(dx, dy)]++;
                    res = Math.Max(res, offsetCount[(dx, dy)]);
                }
            }
            return res;
        }

        private List<(int x, int y)> getOnes(int[][] img)
        {
            List<(int x, int y)> res = new List<(int x, int y)>();
            int n = img.Length;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (img[i][j] == 1)
                        res.Add((i, j));
                }
            }
            return res;
        }