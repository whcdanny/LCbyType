//Leetcode 3143. Maximum Points Inside the Square med
//题目：给定一个二维数组 points 和一个字符串 s，其中 points[i] 表示第 i 个点的坐标，s[i] 表示第 i 个点的标签。
//有效的正方形需满足以下条件：
//正方形以原点(0, 0) 为中心。
//正方形的边平行于坐标轴。
//正方形内不包含标签相同的两个点。
//返回有效正方形内包含的最多点数。
//注意：
//如果一个点位于正方形的边界上，依然视为在正方形内。
//正方形的边长可以为 0。
//思路: 二分法确定正方形的边长：
//可以使用二分法尝试不同的正方形边长。初始的搜索范围为[0, maxDistance]，其中 maxDistance 是从(0,0) 到最远点的最大距离，以确保所有点都在搜索范围内。
//边长检验：给定正方形的边长 side，确定(0,0) 为中心的正方形的边界为[(-side / 2), (side / 2)]。然后，逐个检查 points 中的点是否位于该范围内。
//标签唯一性判断：对于每个在正方形内的点，检查它的标签，确保没有重复标签。如果有标签冲突则该边长无效，否则更新最大点数。
//时间复杂度：O(n log(maxDistance))
//空间复杂度：O(n)
        public int MaxPointsInsideSquare(int[][] points, string s)
        {            
            int left = 0, right = 1000000000 * 2;  // 假设最大边长足够大
            int maxPoints = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (IsValidSquare(points, s, mid))
                {
                    maxPoints = Math.Max(maxPoints, CountPointsInSquare(points, s, mid));
                    left = mid + 1;  // 尝试更大边长
                }
                else
                {
                    right = mid - 1;  // 尝试更小边长
                }
            }

            return maxPoints;
        }
        private bool IsValidSquare(int[][] points, string s, int side)
        {
            HashSet<char> uniqueTags = new HashSet<char>();
            int halfSide = side / 2;
            // points 和 s 中的元素进行配对。points 是一个包含坐标的数组，而 s 是包含标签的字符串。
            //Zip 方法会将这两个集合中的对应元素合并在一起，并应用一个 lambda 表达式 (point, tag) => (point, tag)
            foreach (var (point, tag) in points.Zip(s, (point, tag) => (point, tag)))
            {
                int x = point[0], y = point[1];
                if (Math.Abs(x) <= halfSide && Math.Abs(y) <= halfSide)
                {
                    if (uniqueTags.Contains(tag)) 
                        return false;  // 标签重复
                    uniqueTags.Add(tag);
                }
            }

            return true;
        }

        private int CountPointsInSquare(int[][] points, string s, int side)
        {
            HashSet<char> uniqueTags = new HashSet<char>();
            int halfSide = side / 2;
            int count = 0;

            foreach (var (point, tag) in points.Zip(s, (point, tag) => (point, tag)))
            {
                int x = point[0], y = point[1];
                if (Math.Abs(x) <= halfSide && Math.Abs(y) <= halfSide)
                {
                    if (!uniqueTags.Contains(tag))
                    {
                        uniqueTags.Add(tag);
                        count++;
                    }
                }
            }

            return count;
        }