//Leetcode 3380. Maximum Area Rectangle With Point Constraints I med
//题意：你需要在无限的平面上找到一个矩形，该矩形满足以下条件：
//矩形的四个角点必须是给定点数组中的点。
//矩形的边必须平行于坐标轴。
//矩形的内部以及边界上不能包含任何其他点（除了角点）。
//返回此矩形的最大面积。如果无法形成符合条件的矩形，则返回 -1。
//输入：points：一个二维数组，其中 points[i] = [xi, yi] 表示第 
//i 个点的坐标。
//输出：矩形的最大面积，或者如果无法形成矩形，则返回 -1。
//思路：构图以点的坐标为键，点的索引为值。
//枚举所有可能的点对 (i,j)，这些点对构成矩形的对角线的两个端点
//计算矩形的另两个顶点 temp1 和 temp2 的坐标
//遍历所有点，检查是否存在某个点 k 落在矩形的边界上或内部
//a方+b方=c方找出长宽，然后算出哦面积；
//时间复杂度: 构建图：O(E)，E是边的数量。贝尔曼-福特算法：O(V×E)，V是节点数量。总时间复杂度：O(V×E) （对两天分别运行一次贝尔曼-福特）。
//空间复杂度：图的存储需要 O(E)。动态规划数组需要 O(V)。总空间复杂度为 O(V+E)。
        public int MaxRectangleArea(int[][] points)
        {
            int rs = -1;
            var dict = new Dictionary<(int, int), int>();
            //以点的坐标为键，点的索引为值。
            for (int i = 0; i < points.Length; i++)
                dict.Add((points[i][0], points[i][1]), i);
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    //枚举所有可能的点对 (i,j)，这些点对构成矩形的对角线的两个端点
                    if (points[i][0] != points[j][0] && points[i][1] != points[j][1])
                    {
                        //计算矩形的另两个顶点 temp1 和 temp2 的坐标
                        var temp1 = (points[i][0], points[j][1]);
                        var temp2 = (points[j][0], points[i][1]);
                        if (dict.ContainsKey(temp1) && dict.ContainsKey(temp2))
                        {
                            var idx1 = dict[temp1]; var idx2 = dict[temp2];
                            int k = 0;
                            for (k = 0; k < points.Length; k++)
                            {
                                if (k != i && k != j && k != idx1 && k != idx2)
                                {
                                    //遍历所有点，检查是否存在某个点 k 落在矩形的边界上或内部
                                    if (points[k][0] >= Math.Min(points[i][0], points[j][0])
                                        && points[k][0] <= Math.Max(points[i][0], points[j][0])
                                        && points[k][1] >= Math.Min(points[i][1], points[j][1])
                                        && points[k][1] <= Math.Max(points[i][1], points[j][1]))
                                        break;
                                }
                            }
                            if (k == points.Length)
                            {
                                var lenth = Math.Pow(points[i][0] - temp1.Item1, 2) + Math.Pow(points[i][1] - temp1.Item2, 2);
                                var high = Math.Pow(points[i][0] - temp2.Item1, 2) + Math.Pow(points[i][1] - temp2.Item2, 2);
                                rs = Math.Max(rs, (int)(Math.Sqrt(lenth) * Math.Sqrt(high)));
                            }
                        }
                    }
                }
            }
            return rs;
        }