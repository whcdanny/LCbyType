//Leetcode 199. Binary Tree Right Side View med
//题意：给定一个二叉树，想象自己站在树的右侧，返回从顶部到底部可看到的节点值。
//思路：（BFS）的思路，逐层遍历二叉树，将每层最右边的节点的值加入结果列表。通过队列实现层次遍历，每次将一层的节点放入队列，并在处理当前层时将最右边的节点值记录下来。
//时间复杂度: 遍历整个二叉树，总时间复杂度为 O(n)，其中 n 为二叉树中的节点数量。
//空间复杂度：使用了队列的空间，最坏情况下可能是 O(n/2)，即二叉树的最后一层的节点数量)。
        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> result = new List<int>();

            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (i == levelSize - 1)
                    {
                        // The last node in the current level
                        result.Add(node.val);
                    }

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }

            return result;
        }