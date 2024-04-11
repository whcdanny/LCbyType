//Leetcode 2374. Node With Highest Edge Score med
//题意：给定一个有向图，有 n 个节点，标记为 0 到 n - 1，每个节点恰好有一条出边。
//图由给定的长度为 n 的整数数组 edges 表示，其中 edges[i] 表示从节点 i 指向节点 edges[i] 的有向边。
//节点 i 的边分数定义为所有指向节点 i 的节点标签的总和。
//返回边分数最高的节点。如果有多个节点具有相同的边分数，则返回索引最小的节点。
//思路：hashtable 用long[]存买个节点有多少指向的并算出总和；
//找出最大；       
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int EdgeScore(int[] edges)
        {
            int n = edges.Length;
            long[] scores = new long[n];
           
            for (int i = 0; i < n; i++)
            {
                scores[edges[i]] += i;
            }
           
            long maxScore = long.MinValue;
            int maxNode = -1;
            for (int i = 0; i < n; i++)
            {
                if (scores[i] > maxScore)
                {
                    maxScore = scores[i];
                    maxNode = i;
                }
            }

            return maxNode;
        }