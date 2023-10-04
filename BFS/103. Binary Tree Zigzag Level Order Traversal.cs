//Leetcode 103. Binary Tree Zigzag Level Order Traversal med
//题意：给定一个二叉树，返回其节点值的“之”字形层序遍历，即先从左往右，再从右往左，以此类推，交替进行。
//思路：广度优先搜索（BFS）使用一个队列来进行层次遍历，只是在遍历的时候需要根据层的奇偶性来决定节点值的插入顺序
//时间复杂度: O(n)，其中 n 是二叉树的节点数。
//空间复杂度：取决于队列的大小，最坏情况下是 O(n)，因为队列可能包含所有节点。
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null) return res;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            bool leftToRight = true;

            while (queue.Count > 0)
            {
                int count = queue.Count;
                List<int> curRes = new List<int>();

                for(int i = 0; i < count; i++)
                {
                    TreeNode cur = queue.Dequeue();
                    if (leftToRight)
                    {
                        curRes.Add(cur.val);
                    }
                    else
                    {
                        curRes.Insert(0, cur.val);
                    }
                    if (cur.left != null)
                        queue.Enqueue(cur.left);
                    if (cur.right != null)
                        queue.Enqueue(cur.right);
                }

                res.Add(curRes);
                leftToRight = !leftToRight;
            }

            return res;
        }