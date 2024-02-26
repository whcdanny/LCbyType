//Leetcode 1499. Max Value of Equation hard
//题意： 给定一个按照 x 值排序的二维平面上的点的坐标数组 points，其中 points[i] = [xi, yi]，满足对于所有 1 <= i < j <= points.length，有 xi < xj。同时给定一个整数 k。
//返回满足条件 |xi - xj| <= k 且 1 <= i<j <= points.length 的表达式 yi + yj + |xi - xj| 的最大值。
//思路：PriorityQueue 
//将公式转换一下：yi + yj + |xi - xj|, where |xi - xj| <= k and 1 <= i<j <= points.length.       
//xj >= xi, thus: | xi - xj | = - (xi - xj) = xj - xi, then:
//yi + yj + |xi - xj| = yi - xi + yj + xj
//所以pq存的是(yi - xi, xi),这样再求res的时候pq.Peek().Item1 + point[0] + point[1]这样就解决了
//时间复杂度: O(n)，其中 n 为点的数量
//空间复杂度： O(k)，用于存储单调队列
        public int FindMaxValueOfEquation(int[][] points, int k)
        {
            var pq = new PriorityQueue<(int, int), (int, int)>(Comparer<(int, int)>.Create((a, b) => a.Item1 == b.Item1 ? a.Item2 - b.Item2 : b.Item1 - a.Item1));
            int res = Int32.MinValue;
            foreach (int[] point in points)
            {
                while (pq.Count > 0 && point[0] - pq.Peek().Item2 > k)
                {
                    pq.Dequeue();
                }
                if (pq.Count > 0)
                {
                    res = Math.Max(res, pq.Peek().Item1 + point[0] + point[1]);
                }
                pq.Enqueue((point[1] - point[0], point[0]), (point[1] - point[0], point[0]));
            }
            return res;
        }