//Leetcode 139 Word Break II med
//题意：这道题目给出了一个二维数组points，表示二维平面上一些点的坐标，其中points[i] = [xi, yi]。
//定义右方向为正 x 轴（增大的 x 坐标），左方向为负 x 轴（减小的 x 坐标）。同样地，定义上方向为正 y 轴（增大的 y 坐标），下方向为负 y 轴（减小的 y 坐标）。
//你需要在这些点上放置 n 个人，包括 Alice 和 Bob，在放置时确保每个点上只有一个人。Alice 希望与 Bob 独处，
//所以 Alice 将建造一个矩形围栏，以 Alice 的位置作为左上角，以 Bob 的位置作为右下角（注意，围栏可能不包围任何区域，即它可以是一条线）。
//如果除了 Alice 和 Bob 外的任何人在围栏内或在围栏上，Alice 将会感到难过。
//返回可以放置 Alice 和 Bob 的点对数，使得在建造围栏时 Alice 不会感到难过。
//注意，Alice 只能以 Alice 的位置作为左上角，以 Bob 的位置作为右下角建造围栏。
//思路：贪婪算法：此题允许n^2的时间复杂度，可以暴力枚举所有符合条件的{左上角、右下角}配对，判断是否是合法的解。
//对于二维坐标的点，有两个方向上的自由度，同时考虑他们之间的包含关系肯定复杂，我们必然会尝试将他们先按照一个维度排序，比如说x轴。
//对于两个点A和B在x轴上是递增的，他们能够配对成功的条件就是：x轴上A与B之间的点，不能在y轴上也出现在A与B之间。
//换句话说，如果横坐标位于A与B之间的所有点的y坐标上限是P（排除那些高于A的点），那么B能与A配对的条件就是：B的y周坐标必须大于P。
//随着B在x轴上离A越远，那么这个上限值其实是单调递增的。由此从左到右扫一遍所有的点，不断更新上限P，就能判断出每个点是否可以与A配对。
//时间复杂度: 字符串长度为 n，词典中的单词数量为 m，O(2^n * n)
//空间复杂度： 深度可能达到 n, O(n)
        public int NumberOfPairs(int[][] points)
        {
            //横坐标相同，纵坐标谁高谁现在前面
            //横坐标不相同，纵坐标谁越小越先在前面
            Array.Sort(points, (x, y) => {
                if (x[0] != y[0]) return x[0] - y[0];

                return y[1] - x[1];
            });
            int n = points.Length;
            var result = 0;
            for (var i = 0; i < n; i++)
            {
                var low = int.MinValue;
                var upper = points[i][1];
                for (var j = i + 1; j < n; j++)
                {
                    if (upper >= points[j][1] && low < points[j][1])
                    {
                        result += 1;
                        low = points[j][1];
                    }
                }
            }
            return result;
        }