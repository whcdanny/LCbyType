//Leetcode 1315. Sum of Nodes with Even-Valued Grandparent med
//题意：这是一道关于二叉树的问题。题目要求计算具有偶数值祖父节点的节点值之和。
//思路：BFS 进行层次遍历。对于每个节点，检查其值是否为偶数，如果是，则累加其左右子节点的值到总和 sum 中。最终得到的 sum 就是所有具有偶数值祖父节点的节点值之和。
//时间复杂度: BFS 遍历所有节点，时间复杂度为 O(N)。
//空间复杂度：O(sqrt(N))，其中 sqrt(N) 为树的宽度
        public int SumEvenGrandparent(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int sum = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();

                if (current.left != null)
                {
                    queue.Enqueue(current.left);

                    if (current.val % 2 == 0)
                    {
                        if (current.left.left != null)
                        {
                            sum += current.left.left.val;
                        }
                        if (current.left.right != null)
                        {
                            sum += current.left.right.val;
                        }
                    }
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);

                    if (current.val % 2 == 0)
                    {
                        if (current.right.left != null)
                        {
                            sum += current.right.left.val;
                        }
                        if (current.right.right != null)
                        {
                            sum += current.right.right.val;
                        }
                    }
                }
            }

            return sum;
        }
