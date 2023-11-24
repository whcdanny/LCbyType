//Leetcode 515. Find Largest Value in Each Tree Row med
//题意：给定一个二叉树，返回每一行中最大的值。
//思路：BFS遍历二叉树的每一层，并在每一层找到最大的节点值。
//时间复杂度: O(N)，其中 N 是二叉树的节点数
//空间复杂度：O(M)，其中 M 是每一层的最大节点数
        public IList<int> LargestValues(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                int maxVal = int.MinValue;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode current = queue.Dequeue();
                    maxVal = Math.Max(maxVal, current.val);

                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }

                result.Add(maxVal);
            }

            return result;
        }