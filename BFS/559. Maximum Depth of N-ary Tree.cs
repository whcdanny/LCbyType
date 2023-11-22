//Leetcode 559. Maximum Depth of N-ary Tree ez
//题意：给定一个 N 叉树，找到其最大深度。 N 叉树是一棵树，其中每个节点最多有 N 个子节点。
//思路：BFS（广度优先搜索） 进行层序遍历，每一层的节点都在同一层级，所以遍历到的节点的深度就是当前层级的深度。
//时间复杂度: O(n)，其中 n 为节点总数
//空间复杂度：O(w)，其中 w 为树的最大宽度
        public int MaxDepth(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            int depth = 0;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    Node node = queue.Dequeue();

                    foreach (Node child in node.neighbors)
                    {
                        if (child != null)
                        {
                            queue.Enqueue(child);
                        }
                    }
                }

                depth++;
            }

            return depth;
        }        