//111. Minimum Depth of Binary Tree med
//二叉树的最小深度
//思路：BFS 将当前队列中的所有节点向四周扩散, 判断是否到达终点, 将 cur 的相邻节点加入队列, 都走完增加步数；
		public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            // root 本身就是一层，depth 初始化为 1
            int depth = 1;

            while (q.Count!=0)
            {
                int sz = q.Count;
                /* 将当前队列中的所有节点向四周扩散 */
                for (int i = 0; i < sz; i++)
                {
                    TreeNode cur = q.Dequeue();
                    /* 判断是否到达终点 */
                    if (cur.left == null && cur.right == null)
                        return depth;
                    /* 将 cur 的相邻节点加入队列 */
                    if (cur.left != null)
                        q.Enqueue(cur.left);
                    if (cur.right != null)
                        q.Enqueue(cur.right);
                }
                /* 这里增加步数 */
                depth++;
            }
            return depth;
        }
//思路：递归
		public int MinDepth(TreeNode root) {
        if (root == null)
            return 0;
        if (root.left == null)
            return MinDepth(root.right) + 1;
        if (root.right == null)
            return MinDepth(root.left) + 1;
        return Math.Min(MinDepth(root.left), MinDepth(root.right))+1;
    }