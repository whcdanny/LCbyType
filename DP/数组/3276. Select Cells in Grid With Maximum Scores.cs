//Leetcode 3276. Select Cells in Grid With Maximum Scores hard
//题目：给定一个二维矩阵 grid，矩阵中的每个元素都是正整数。
//要求从矩阵中选择一个或多个单元格，使得满足以下条件：
//选中的单元格不能在同一行。
//所选单元格中的值必须是唯一的。
//目标是使得选中的单元格值之和（得分）最大化。
//返回可以获得的最大得分。
//思路: dfs+bitmask：
//看code
//时间复杂度：O(n^2)
//空间复杂度：O(n^2)
        public int MaxScore(IList<IList<int>> grid)
        {
            var hashValSet = new HashSet<int>();
            //map：用于缓存 (index, rows) 对应的计算结果，避免重复计算。
            var map = new Dictionary<(int, int), int>();

            //想把每一行的数字放入，然后排序；
            var list = new List<(int row, int val)>();
            for (var row = 0; row < grid.Count; row++)
            {
                foreach (var one in grid[row])
                {
                    list.Add((row, one));
                }
            }
            list.Sort((a, b) => b.val - a.val);

            // 调用DFS函数，从索引0和初始行状态0开始
            return DFS_MaxScore(0, 0, list, map, hashValSet);
        }

        // DFS函数实现深度优先搜索
        private int DFS_MaxScore(int index, int rows, List<(int row, int val)> list, Dictionary<(int, int), int> map, HashSet<int> hashValSet)
        {
            var key = (index, rows);
            if (index >= list.Count)
            {
                return 0;
            }

            if (map.ContainsKey(key))
            {
                return map[key];
            }

            var pair = list[index];//(row, val)
            var row = pair.row;
            //验证是否访问
            //Bitmask
            //这行代码的作用是计算 1 左移 row 位的结果。换句话说，它会生成一个整数，其中第 row 位为 1，其余位为 0。例如，如果 row = 2，则 shiftrow 的值为 4，因为二进制表示为 100。
            //我们可以用一个 bool[] selectedRows 数组表示行的选择状态，其中 selectedRows[i] 为 true 表示第 i 行已经被选择。但会超时
            var shiftrow = 1 << row;
            var result = 0;

            // 判断是否可以选择当前的单元格
            if ((rows & shiftrow) != shiftrow && !hashValSet.Contains(pair.val))
            {
                var prerows = rows;
                //这行代码的作用是将 rows 的第 row 位设置为 1。它使用位或运算（|）来合并 shiftrow 和 rows。这样可以在 rows 中记录已经选择过的行。
                rows |= shiftrow;
                hashValSet.Add(pair.val);

                var nextIndex = GetInsertIndex(list, pair.val - 1);
                result = Math.Max(result, DFS_MaxScore(nextIndex, rows, list, map, hashValSet) + pair.val);

                rows = prerows;
                hashValSet.Remove(pair.val);
            }

            // 选择不选当前单元格
            result = Math.Max(result, DFS_MaxScore(index + 1, rows, list, map, hashValSet));
            map[key] = result;
            return result;
        }

        // GetInsertIndex函数用于在列表中找到满足条件的下一个索引
        private int GetInsertIndex(List<(int row, int val)> list, int target)
        {
            int left = 0;
            int right = list.Count;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                var pair = list[mid];
                if (pair.val <= target)
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