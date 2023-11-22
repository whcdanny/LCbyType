//Leetcode 637. Average of Levels in Binary Tree ez
//题意：给定一个二叉树，计算每一层的节点值的平均值，并返回一个数组。
//思路： BFS（广度优先搜索）遍历二叉树，对于每一层的节点值，计算平均值并存储在结果数组中。在遍历每一层节点时，需要记录该层的节点数和节点值的和。最后，用和除以节点数即可得到平均值。       
//时间复杂度: O(n)，其中 n 是二叉树的节点数
//空间复杂度：O(m)，其中 m 是树中某一层的最大节点数
        public IList<double> AverageOfLevels(TreeNode root)
        {
            List<double> result = new List<double>();

            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                double levelSum = 0;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode current = queue.Dequeue();
                    levelSum += current.val;

                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }

                result.Add(levelSum / levelSize);
            }

            return result;
        }