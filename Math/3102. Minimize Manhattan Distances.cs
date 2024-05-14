//Leetcode 3102. Minimize Manhattan Distances hard
//题意：给定一个数组 points，表示二维平面上一些点的整数坐标，其中 points[i] = [xi, yi]。
//两点之间的距离被定义为它们的曼哈顿距离。
//要求删除恰好一个点，使得任意两点之间的最大距离尽可能小。
//思路：此题的本质就是1131.Maximum-of-Absolute-Value-Expression，求二维点集里的最大曼哈顿距离。
//我们需要维护四个有序容器，分别盛装所有点的(x+y), (x-y), (-x+y), (-x-y)。记每个容器中的最大值减去最小值为t，那么四个t中的最大值就是二维点集里的最大曼哈顿距离。
//根据上述原理，我们遍历所有的点，每次从容器里面将一个点去除，再求此时的最大曼哈顿距离，只需要logN的时间。这样遍历N个点之后，用NlogN的时间就可以求出最优解。
//时间复杂度: logN
//空间复杂度：n;
        public int MinimumDistance_超时(int[][] points)
        {
            List<List<int>> arr = new List<List<int>>();
            for(int i=0;i<4; i++)
            {
                arr.Add(new List<int>());
            }
            int res = int.MaxValue/2;
            foreach(int[] point in points)
            {
                arr[0].Add(point[0] + point[1]);
                arr[1].Add(point[0] - point[1]);
                arr[2].Add(-point[0] + point[1]);
                arr[3].Add(-point[0] - point[1]);
                arr[0].Sort();
                arr[1].Sort();
                arr[2].Sort();
                arr[3].Sort();
            }            
            foreach(int[] point in points)
            {
                int index0 = arr[0].IndexOf(point[0] + point[1]);
                arr[0].RemoveAt(index0);
                int index1 = arr[1].IndexOf(point[0] - point[1]);
                arr[1].RemoveAt(index1);
                int index2 = arr[2].IndexOf(-point[0] + point[1]);
                arr[2].RemoveAt(index2);
                int index3 = arr[3].IndexOf(-point[0] - point[1]);
                arr[3].RemoveAt(index3);

                int ans = 0;
                ans = Math.Max(ans, arr[0].Last() - arr[0].First());
                ans = Math.Max(ans, arr[1].Last() - arr[1].First());
                ans = Math.Max(ans, arr[2].Last() - arr[2].First());
                ans = Math.Max(ans, arr[3].Last() - arr[3].First());

                res = Math.Min(res, ans);

                arr[0].Insert(index0, point[0] + point[1]);
                arr[1].Insert(index1, point[0] - point[1]);
                arr[2].Insert(index2, -point[0] + point[1]);
                arr[3].Insert(index3, -point[0] - point[1]);
            }
            
            return res;
        }