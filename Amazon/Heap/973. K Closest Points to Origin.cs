//Leetcode 973. K Closest Points to Origin med
//题意：给定一个数组，points其中代表XY平面上的一个点和一个整数，返回距离原点最近的k点。points[i] = [xi, yi]kk(0, 0)
//XY平面上两点之间的距离即为欧氏距离（即）。√(x1 - x2)2 + (y1 - y2)2
//您可以按任意顺序返回答案。答案保证是唯一的（除了其顺序）。
//思路：Heap，用sortedList，将以distance为key，然后value是List<int[]>存相同distance的point
//时间复杂度: O(n+k)
//空间复杂度：O(N+K)   
        public int[][] KClosest_1(int[][] points, int K)
        {
            var sortedList = new SortedList<double, List<int[]>>();
            foreach (var point in points)
            {
                var distance = GetEuclideanDistance(point);
                if (sortedList.ContainsKey(distance))
                {
                    sortedList[distance].Add(point);
                }
                else
                {
                    sortedList.Add(distance, new List<int[]> { point });
                }
            }

            var result = new int[K][];
            var sortedValues = sortedList.Values;
            for (int i = 0; i < K; i++)
            {
                if (sortedValues[i].Count == 1)
                {
                    result[i] = sortedValues[i][0];
                }
                else
                {
                    foreach (var p in sortedValues[i])
                    {
                        result[i] = p;
                        i++;
                    }
                }
            }
            return result;
        }

        //calulate distance to origin
        //dist((x, y), (a, b)) = √(x - a)² + (y - b)²
        private double GetEuclideanDistance(int[] a)
        {
            var d = (a[0] * a[0]) + (a[1] * a[1]);
            return Math.Sqrt(d);
        }