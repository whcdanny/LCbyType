//Leetcode 993. Cousins in Binary Tree ez
//题意：给定一个二叉树和两个树中的节点 x 和 y，判断它们是否是堂兄弟节点。堂兄弟节点是指深度相同但父节点不同的节点。
//思路：BFS（广度优先搜索）我们需要记录每个节点的深度和父节点。当找到节点 x 和 y 时，我们比较它们的深度和父节点是否相同，从而判断它们是否为堂兄弟节点。
//时间复杂度: 设二叉树的节点数为 n。在最坏情况下，需要遍历整个树，因此时间复杂度为 O(n)。
//空间复杂度：使用队列存储节点、深度和父节点的信息，队列的最大大小不会超过 n/2，因此空间复杂度为 O(n)。
        public bool IsCousins(TreeNode root, int x, int y)
        {
            Queue<(TreeNode, TreeNode, int)> queue = new Queue<(TreeNode, TreeNode, int)>();

            queue.Enqueue((root, null, 0)); // 初始根节点入队，父节点为 null，深度为 0

            TreeNode parentX = null, parentY = null;
            int depthX = -1, depthY = -1;

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    var (node, parent, depth) = queue.Dequeue();

                    if (node.val == x)
                    {
                        (parentX, depthX) = (parent, depth);
                    }
                    if (node.val == y)
                    {
                        (parentY, depthY) = (parent, depth);
                    }

                    if (node.left != null)
                    {
                        queue.Enqueue((node.left, node, depth + 1));
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue((node.right, node, depth + 1));
                    }
                }

                // 如果两个节点的深度不同，或者它们有相同的父节点，则不是堂兄弟节点
                if ((depthX == depthY && parentX != parentY))
                {
                    return true;
                }
            }

            return false;
        }