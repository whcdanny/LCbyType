//Leetcode 2265. Count Nodes Equal to Average of Subtree med
//题意：给定二叉树的根节点 root，返回节点值等于其子树中节点值平均值的节点数量。
//注意：n 个元素的平均值是这 n 个元素的和除以 n，然后向下取整到最接近的整数。root 的子树是由 root 和其所有后代组成的树。        
//思路：深度优先搜索 (DFS),FS）遍历二叉树，同时计算每个节点子树的值的总和 sum 和节点数 numNodes。对于每个节点，计算其子树的平均值 avg，如果节点的值等于 avg，则将计数器递增。返回最终计数器的值。       
//时间复杂度: O(N)，其中 N 是二叉树中的节点数量。我们需要遍历每个节点一次
//空间复杂度：O(H)，其中 H 是二叉树的高度。递归调用的最大深度等于树的高度
        private int DFS_CountPairs(int node, Dictionary<int, List<int>> adjacencyList, HashSet<int> visited, int n)
        {
            int res = 0;
            visited.Add(node);
            res++;
            foreach(var adj in adjacencyList[node])
            {
                if (adj == node || visited.Contains(adj)) continue;
                res+=DFS_CountPairs(adj, adjacencyList, visited, n);
            }
            return res;
        }


        public int AverageOfSubtree(TreeNode root)
        {
            int[] count = new int[1];
            DFS_AverageOfSubtree(root, count);
            return count[0];
        }

        private Tuple<int, int> DFS_AverageOfSubtree(TreeNode node, int[] count)
        {
            if (node == null)
            {
                return new Tuple<int, int>(0, 0);
            }

            Tuple<int, int> left = DFS_AverageOfSubtree(node.left, count);
            Tuple<int, int> right = DFS_AverageOfSubtree(node.right, count);

            int sum = left.Item1 + right.Item1 + node.val;
            int numNodes = left.Item2 + right.Item2 + 1;

            int avg = sum / numNodes;

            if (node.val == avg)
            {
                count[0]++;
            }

            return new Tuple<int, int>(sum, numNodes);
        }
