//Leetcode 2250. Count Number of Rectangles Containing Each Point med
//题意：给定一个二维整数数组 rectangles 表示矩形的长度和高度，以及一个二维整数数组 points 表示点的坐标。每个矩形的左下角在坐标 (0, 0)，右上角在坐标 (li, hi)。
//要求返回一个整数数组 count，其中 count[j] 表示包含第 j 个点的矩形的数量。
//思路：二分搜索，我们可以根据高度对矩形进行分组，并根据长度对每个组进行排序。每个点，我们在所有具有 的组上对 x 坐标进行二分搜索
//注：二分搜索将查找第一个可能包含该点的 x 坐标的矩形长度，并且列表中它之后的所有长度都绝对可
//时间复杂度: O(m log m + n log n)，其中 m 是矩形数组的长度，n 是点数组的长度
//空间复杂度：O(1)
        public int[] CountRectangles(int[][] rectangles, int[][] points)
        {
            int[] res = new int[points.Length];
            List<List<int>> group = new List<List<int>>();
            for (int i = 0; i < 101; i++)
            {
                group.Add(new List<int>());
            }

            foreach (int[] rec in rectangles)
            {
                int length = rec[0];
                int hight = rec[1];
                group[hight].Add(length);
            }

            for (int i = 0; i < group.Count; i++)
            {
                group[i].Sort();
            }

            for (int i = 0; i < points.Length; i++)
            {
                int count = 0;
                int x = points[i][0];
                int y = points[i][1];
                for (int j = y; j < group.Count; j++)
                {
                    List<int> cur = group[j];
                    int index = binarySearch_countRectangles(cur, x);
                    count += cur.Count - index;
                }
                res[i] = count;
            }

            return res;
        }

        private int binarySearch_countRectangles(List<int> list, int x)
        {
            int left = 0;
            int right = list.Count;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (list[mid] >= x)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }