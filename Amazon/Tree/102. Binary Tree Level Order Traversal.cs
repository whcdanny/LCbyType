//Leetcode 102. Binary Tree Level Order Traversal med
//题意：给定一个二叉树，返回其节点值的层序遍历。也就是按照从上到下，从左到右的顺序逐层遍历节点。
//思路：广度优先搜索（BFS）使用一个队列来进行层次遍历，首先将根节点入队，
//然后依次将当前层的节点出队，并将它们的子节点入队，直到队列为空。
//时间复杂度: O(n)，其中 n 是二叉树的节点数。
//空间复杂度：取决于队列的大小，最坏情况下是 O(n)，因为队列可能包含所有节点。
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null) return res;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                List<int> currentValues = new List<int>();
                for (int i = 0; i < count; i++)
                {
                    TreeNode cur = queue.Dequeue();
                    currentValues.Add(cur.val);
                    if (cur.left != null)
                        queue.Enqueue(cur.left);
                    if (cur.right != null)
                        queue.Enqueue(cur.right);
                }

                res.Add(currentValues);
            }
            return res;
        }