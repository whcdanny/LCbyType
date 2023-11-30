//Leetcode 2476. Closest Nodes Queries in a Binary Search Tree med
//题意：给定一棵二叉搜索树（BST）和一个包含正整数的数组 queries，对于每个查询，要找到满足以下条件的最小和最大值：
//mini 是二叉搜索树中小于或等于 queries[i] 的最大值。如果不存在这样的值，则将 -1 添加到答案数组。
//maxi 是二叉搜索树中大于或等于 queries[i] 的最小值。如果不存在这样的值，则将 -1 添加到答案数组。
//最终返回一个二维数组 answer，其中 answer[i] = [mini, maxi]
//思路：（DFS）进行遍历，并在遍历的过程中找到符合条件的 mini 和 maxi。
//时间复杂度: O(n)N 是树中的节点数。
//空间复杂度：O(n)
        public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries)//用memory还是超时
        {
            List<int[]> answer = new List<int[]>();
            Dictionary<int, (int, int)> memo = new Dictionary<int, (int, int)>();
            foreach (int query in queries)
            {
                int mini = -1, maxi = -1;
                DFS_ClosestNodes(root, query, memo, ref mini, ref maxi);
                answer.Add(new int[] { mini, maxi });
            }

            return answer.ToArray();
        }

        private void DFS_ClosestNodes(TreeNode node, int query, Dictionary<int, (int, int)> memo, ref int mini, ref int maxi)
        {
            if (node == null)
                return;
            if (memo.ContainsKey(query))
            {
                mini = memo[query].Item1;
                maxi = memo[query].Item2;
            }
            else
            {
                if (node.val < query)
                {
                    mini = Math.Max(mini, node.val);
                    DFS_ClosestNodes(node.right, query, memo, ref mini, ref maxi);
                }
                else if (node.val > query)
                {
                    maxi = maxi == -1 ? node.val : Math.Min(maxi, node.val);
                    DFS_ClosestNodes(node.left, query, memo, ref mini, ref maxi);
                }
                else
                {
                    mini = Math.Max(mini, node.val);
                    maxi = maxi == -1 ? node.val : Math.Min(maxi, node.val);
                }
                memo[query] = ((mini, maxi));
            }
        }