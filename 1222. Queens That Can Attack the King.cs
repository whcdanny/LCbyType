1222. Queens That Can Attack the King
//C#
public IList<IList<int>> queensAttacktheKing(int[][] queens, int[] king)
        {
            var res = new List<IList<int>>();
            bool[,] q = new bool[8,8];
            foreach (int[] u in queens)
            {
                q[u[0],u[1]] = true;
            }
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    for (int r = king[0] + i, c = king[1] + j; r >= 0 && r < 8 && c >= 0 && c < 8; r += i, c += j)
                    {
                        if (q[r,c])
                        {
                            List<int> re = new List<int>();
                            re.Add(r);
                            re.Add(c);
                            res.Add(re);
                            break;
                        }
                    }
                }
            }
            return res;
        }