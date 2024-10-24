//Leetcode 3288. Length of the Longest Increasing Path hard
//题目：给定一个二维整数数组 coordinates，其中 coordinates[i] = [xi, yi] 表示二维平面上的点 (xi, yi)，数组长度为 n。同时给定一个整数 k，其中 0 <= k < n。
//定义长度为 m 的递增路径为一个点的序列(x1, y1), (x2, y2), (x3, y3), ..., (xm, ym)，满足以下条件：
//对于所有 1 <= i<m，都有 xi<xi+1 且 yi<yi+1。
//(xi, yi) 是给定的 coordinates 数组中的点。
//要求返回包含点 coordinates[k] 的最长递增路径的长度。
//思路：动态规划+二分法， 看code
//时间复杂度：O(n log n)
//空间复杂度：O(n)
        public int MaxPathLength(int[][] coordinates, int k)
        {
            int[] has = coordinates[k];

            //先转换成list方便排序
            List<int[]> coordsList = new List<int[]>();
            foreach (var coord in coordinates)
            {
                coordsList.Add(coord);
            }
            
            coordsList.Sort((a, b) => {
                if (a[0] != b[0]) return a[0].CompareTo(b[0]);
                return b[1].CompareTo(a[1]);
            });

            //找出对应坐标的位置在排序好的list中
            int current = -1;
            for (int i = 0; i < coordsList.Count; i++)
            {
                if (findPointLocation(coordsList[i], has))
                {
                    current = i;
                    break;
                }
            }
            
            var left = coordsList.GetRange(0, current);
            var right = coordsList.GetRange(current + 1, coordsList.Count - (current + 1));

            int l = findSubset(filterSubset(left, has, true));
            int r = findSubset(filterSubset(right, has, false));
            return l + r + 1;
        }
        
        private int findSubset(List<int[]> nums)
        {
            //用二分法，去找到最合适的值，
            List<int> dp = new List<int>();
            foreach (var p in nums)
            {
                int val = p[1];
                int idx = dp.BinarySearch(val);
                if (idx < 0)
                {
                    idx = ~idx;
                    if (idx == dp.Count)
                    {
                        dp.Add(val);
                    }
                    else
                    {
                        dp[idx] = val;
                    }
                }
            }
            return dp.Count;
        }

        private List<int[]> filterSubset(List<int[]> nums, int[] has, bool isLeft)
        {
            List<int[]> result = new List<int[]>();
            foreach (var coord in nums)
            {
                //左边就x,y都要小于，选中的值
                if (isLeft)
                {
                    if (coord[0] < has[0] && coord[1] < has[1])
                    {
                        result.Add(coord);
                    }
                }
                //右边就x,y都要大于，选中的值
                else
                {
                    if (coord[0] > has[0] && coord[1] > has[1])
                    {
                        result.Add(coord);
                    }
                }
            }
            return result;
        }

        private bool findPointLocation(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }
