//Leetcode 1609. Even Odd Tree med
//题意：如果一棵二叉树满足以下条件，则称为奇偶二叉树：二叉树的根位于索引级0，其子级位于索引级1，它们的子级位于索引级2，依此类推。对于每个偶数索引级别，该级别的所有节点都具有严格递增顺序（从左到右）的奇整数值。对于每个奇数索引级别，该级别的所有节点都具有严格降序（从左到右）的偶数整数值。
//思路：BFS（宽度优先搜索）来遍历所有, 如果当前层是奇数层，检查节点值是否是递减的偶数。如果当前层是偶数层，检查节点值是否是递增的奇数。
//时间复杂度: O(N)，其中 N 是树中的节点数。
//空间复杂度：O(W)，其中 W 是树的宽度
        public bool IsEvenOddTree(TreeNode root)
        {
            if (root == null) return true;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level = 0;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                int[] values = new int[size];

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    values[i] = node.val;

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                if (!IsValidLevel(values, level)) return false;
                level++;
            }

            return true;
        }

        private bool IsValidLevel(int[] values, int level)
        {
            if (level == 0)
            {
                if (values[0] % 2 == 1)
                    return true;
                else
                    return false;
            }
            else
            {
                
                for (int i = 0; i < values.Length; i++)
                {
                    if (i == 0)
                    {
                        if (level % 2 == 0)
                        {
                            if (values[i] % 2 == 0)
                                return false;
                        }
                        else
                        {
                            if (values[i] % 2 == 1)
                                return false;

                        }
                    }
                    else
                    {
                        if (level % 2 == 0)
                        {
                            if (values[i] % 2 == 0 || values[i] <= values[i - 1])
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (values[i] % 2 == 1 || values[i] >= values[i - 1])
                            {
                                return false;
                            }
                        }
                    }                    
                }
            }
            
            return true;
        }