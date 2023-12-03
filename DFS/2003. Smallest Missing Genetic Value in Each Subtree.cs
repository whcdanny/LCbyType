//Leetcode 2003. Smallest Missing Genetic Value in Each Subtree hard
//题意：给定一个家族树，树的根节点为 0，包含 n 个节点，编号为 0 到 n - 1。给定一个数组 parents，其中 parents[i] 表示节点 i 的父节点。由于节点 0 是根节点，所以 parents[0] == -1。
//有 10^5 个基因值，每个基因值由一个整数表示，范围在[1, 10 ^ 5] 之间。给定一个数组 nums，其中 nums[i] 表示节点 i 的基因值。    
//要求返回一个长度为 n 的数组 ans，其中 ans[i] 表示以节点 i 为根的子树中缺失的最小基因值。
//思路：DFS, 先建立子-父图，然后找到最小值为1的那个节点，如果没有，那么所有的最小都是1， 从最小值为1的那个node开始查找，这样缺少的最小值就是从1开始查找；
//注：看code注释；
//注：这里重点是构图
//时间复杂度:  构建图的时间复杂度：O(N)，其中 N 是节点的数量。DFS 的时间复杂度：O(N)，因为我们对每个节点最多访问一次。O(N)
//空间复杂度： 图的存储空间：O(N)，用于存储图的邻接表。 DFS 的递归调用栈：O(H)，其中 H 是树的高度。在最坏的情况下，二叉树可能是一条链，树的高度为 N，所以空间复杂度为 O(N)。总体空间复杂度为 O(N)。
        public int[] SmallestMissingValueSubtree(int[] parents, int[] nums)
        {
            Dictionary<int, List<int>> grapth = new Dictionary<int, List<int>>();
            int n = nums.Length;
            int[] ans = new int[n];

            //因为最小值是1，先都给上，以防nums最小值不是1的话；
            Array.Fill(ans, 1);

            //找到1的node作为起始查找点；
            int startNode = -1;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 1)
                {
                    startNode = i;
                    break;
                }
            }

            //如果没有起始点值为1的话，所有的点最小都是1；
            if (startNode == -1)
                return ans;

            //建立子-父数
            for (int i = -1; i < n; i++)
            {
                grapth[i] = new List<int>();
            }            
            for (int i = 0; i < n; i++)
            {
                grapth[parents[i]].Add(i);                
            }

            //这里n+2是因为有可能最小值多一个，最大值多一个 所以n+2；
            HashSet<int> visited = new HashSet<int>(n+2);                                                   

            int curMin = 1;
            while (startNode != -1)
            {
                DFS_SmallestMissingValueSubtree(grapth, startNode, visited, nums);
                
                //每个子树都要找最小的没有的val；
                while (visited.Contains(curMin))
                {
                    curMin++;
                }

                ans[startNode] = curMin;
                startNode = parents[startNode];//找到下一个起始点，也就是当前点的父亲；
            }
            return ans;
        }


        private void DFS_SmallestMissingValueSubtree(Dictionary<int, List<int>> grapth, int node, HashSet<int> visited, int[] val)
        {            
            if (visited.Contains(val[node]))
                return;

            visited.Add(val[node]);
            foreach (var neg in grapth[node])
            {
                DFS_SmallestMissingValueSubtree(grapth, neg, visited, val);
            }
        }
