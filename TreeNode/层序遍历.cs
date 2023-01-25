//层序遍历
		// 输入一棵二叉树的根节点，层序遍历这棵二叉树
        public void levelTraverse(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            // 从上到下遍历二叉树的每一层
            while (q.Count!=0)
            {
                int sz = q.Count;
                // 从左到右遍历每一层的每个节点
                for (int i = 0; i < sz; i++)
                {
                    TreeNode cur = q.Dequeue();
                    // 将下一层节点放入队列
                    if (cur.left != null)
                    {
                        q.Enqueue(cur.left);
                    }
                    if (cur.right != null)
                    {
                        q.Enqueue(cur.right);
                    }
                }
            }
        }