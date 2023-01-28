//51 hard
//给一个nxn棋盘，放入最多的Queens并且他们不能互相攻击
//Queens的攻击是同一行，同一列，左上左下右上右下四个方向的任意单位；
//'.' 表示空，'Q' 表示皇后，初始化空棋盘
//思路：回溯算法 暴力算法 从[0,0]假设可以放Queen，然后如果根据Queen的位置条件都满足，那么就存下来，不满足就返回上一行；
//验证当前位置是否有用：检查列是否有皇后互相冲突；y=x 或者 y=-x 来表示检查右上左上是否有皇后互相冲突
		public IList<IList<string>> SolveNQueens(int n)
        {
            var result = new List<IList<string>>();
            SolveNQueens(n, new List<string>(), result);

            return result;
        }
		// 路径：board 中小于 row 的那些行都已经成功放置了皇后
		// 选择列表：第 row 行的所有列都是放置皇后的选择
		// 结束条件：row 超过 board 的最后一行
        private void SolveNQueens(int n, IList<string> rows, IList<IList<string>> result)
        {
			// 触发结束条件:row 超过 board 的最后一行
            if (rows.Count == n)
            {
                result.Add(new List<string>(rows));
                return;
            }

            for (var i = 0; i < n; i++)
            {
				// 排除不合法选择
                if (!IsValid(i, rows))
                {
                    continue;
                }
				//初始化空棋盘全部'.'
                var c = Enumerable.Repeat('.', n).ToArray();
				//添加Queen
                c[i] = 'Q';
                rows.Add(new string(c));
				//进入下一行决策
                SolveNQueens(n, rows, result);
                rows.RemoveAt(rows.Count - 1);
            }
        }

        private bool IsValid(int col, IList<string> rows)
        {
            var n = rows.Count;
            for (var i = 0; i < n; i++)
            {
				//检查列是否有皇后互相冲突
                var j = rows[i].IndexOf('Q');
                if (j == col)
                {
                    return false;
                }				
				//y=x 或者 y=-x 来表示检查右上左上是否有皇后互相冲突
                if (Math.Abs(col - j) == Math.Abs(n - i))
                {
                    return false;
                }
            }

            return true;
        }