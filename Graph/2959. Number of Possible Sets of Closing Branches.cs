//Leetcode 2959. Number of Possible Sets of Closing Branches hard
//题意：有一个公司在全国有 n 个分支机构，其中一些通过道路连接。
//最初，所有分支机构都可以通过旅行一些道路相互到达。
//公司意识到，他们在分支机构之间的旅行花费了大量时间。
//因此，他们决定关闭其中一些分支机构（可能没有关闭）。
//然而，他们希望确保剩下的分支机构之间的距离至多为 maxDistance。
//两个分支机构之间的距离是从一个分支机构到达另一个分支机构所需的最小总旅行长度。
//给你整数 n，maxDistance，以及一个 0 索引的二维数组 roads，其中 roads[i] = [ui, vi, wi] 表示分支机构 ui 和 vi 之间的无向道路，长度为 wi。
//返回可能关闭的分支机构的集合数量，使得任何分支机构之间的距离至多为 maxDistance。
//注意，关闭分支机构后，公司将不再访问连接到该分支机构的任何道路。
//思路：Floy算法: 
//因为节点数目n只有10，所以我们可以暴力枚举所有的closure方案，只需要2^n不超过1024种。
//相当于每个node有两种可能关闭或者不关闭
//对于每种closure的方案，我们可以用类似Floy算法的n^3的时间度算出任意两点间的最短距离（排除掉closed point），
//然后只需要检查是否都小于targetDistance即可。
//时间复杂度：O(2^n * n^3) 遍历所有可能的子集需要 O(2^n)， 每个子集，计算所有节点之间的最短路径需要 O(n^3)
//空间复杂度：O(n^2 + 2^n) 矩阵 d 需要 O(n^2) 的空间， 状态空间需要 O(2^n)
        public int NumberOfSets(int n, int maxDistance, List<List<int>> roads)
        {
            int ret = 0;

            // 遍历所有可能的子集
            //state < (1 << n) 这个表达式用于遍历所有可能的子集。
            //它的意思是，对于一个长度为 n 的集合，存在 2^n 个可能的子集，每个子集对应一个二进制数，从 0 到 2^n - 1。
            //1 << n 表示将数字 1 左移 n 位，这相当于 2^n。
            //选择节点
            for (int state = 0; state < (1 << n); state++)
            {
                //二位网络；
                int[,] d = new int[n, n];

                // 初始化距离矩阵
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        d[i, j] = int.MaxValue / 3;
                    }
                    //(state >> i) & 1 这个表达式的意思是检查 state 的第 i 位是否为 1。在二进制表示法中，每一位表示集合中的一个元素是否存在于子集中。
                    if (((state >> i) & 1) == 0) continue;
                    d[i, i] = 0;
                }

                // 更新距离矩阵
                //任意两点直接距离最小之和；
                foreach (var road in roads)
                {
                    int a = road[0], b = road[1], w = road[2];
                    //a或者b是关闭的；
                    if (((state >> a) & 1) == 0) continue;
                    if (((state >> b) & 1) == 0) continue;

                    for (int i = 0; i < n; i++)
                    {
                        if (((state >> i) & 1) == 0) continue;
                        for (int j = 0; j < n; j++)
                        {
                            if (((state >> j) & 1) == 0) continue;
                            d[i, j] = Math.Min(d[i, j], d[i, a] + w + d[b, j]);
                            d[i, j] = Math.Min(d[i, j], d[i, b] + w + d[a, j]);
                        }
                    }
                }

                // 检查所有剩余的分支是否小于maxDistance
                bool flag = true;
                for (int i = 0; i < n; i++)
                {
                    if (((state >> i) & 1) == 0) continue;
                    for (int j = 0; j < n; j++)
                    {
                        if (((state >> j) & 1) == 0) continue;
                        if (d[i, j] > maxDistance)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag) break;
                }

                if (flag) ret++;
            }

            return ret;
        }