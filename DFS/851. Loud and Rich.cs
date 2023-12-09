//Leetcode 851. Loud and Rich med
//题意：有一群n人被标记为从0到n - 1，每个人都有不同数量的金钱和不同的安静程度。
//给你一个数组richer，其中表示比这个人有更多的钱，还有一个整数数组，其中表示该人的安静程度。richer 中的所有给定数据在逻辑上都是正确的（即，数据不会导致您出现比同时更丰富和比更丰富的情况）。richer[i] = [ai, bi]
//aibiquietquiet[i] ithxyyx返回一个整数数组answer，其中answer[x] = yif是所有钱肯定等于或更多的人中y最不安静的人（即y值最小的人） 。quiet[y] x
//说白了：给一个richer表示richer[i] = [ai, bi] bi比ai有钱，然后找出每个位置比这位置有钱的人，如果有多个有钱人，根据这quiet，找这个值最小的那个人；
//思路：DFS 构建一个图，表示每个人比谁安静。对于每个人，递归地找出比他富裕且更安静的人。为了避免重复计算，使用 memoization 存储每个人的答案。
//时间复杂度: O(N + E) 的时间，其中 N 为节点数，E 为边数
//空间复杂度：O(N + E)
        private int[] result_LoudAndRich;
        public int[] LoudAndRich(int[][] richer, int[] quiet)
        {
            int n = quiet.Length;            
            List<int>[] graph = new List<int>[n];
            result_LoudAndRich = new int[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var pair in richer)
            {
                graph[pair[1]].Add(pair[0]);
            }

            Array.Fill(result_LoudAndRich, -1);

            for (int i = 0; i < n; i++)
            {
                DFS_LoudAndRich(i, graph, quiet);
            }

            return result_LoudAndRich;
        }

        private int DFS_LoudAndRich(int node, List<int>[] graph, int[] quiet)
        {
            if (result_LoudAndRich[node] != -1)
            {
                return result_LoudAndRich[node];
            }

            result_LoudAndRich[node] = node; // 初始化为自己

            foreach (var neighbor in graph[node])
            {
                int candidate = DFS_LoudAndRich(neighbor, graph, quiet);
                if (quiet[candidate] < quiet[result_LoudAndRich[node]])
                {
                    result_LoudAndRich[node] = candidate;
                }
            }

            return result_LoudAndRich[node];
        }