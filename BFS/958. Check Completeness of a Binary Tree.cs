//Leetcode 958. Check Completeness of a Binary Tree med
//题意：查二叉树是否为完全二叉树的问题
//思路：BFS 遍历二叉树的每一层，如果在遍历到达最后一层后，再出现非空节点，说明不是完全二叉树。如果在达到最后一层之前就出现了空节点，也说明不是完全二叉树
//时间复杂度: O(N)，其中 N 是二叉树中的节点数。在最坏情况下，我们可能需要遍历所有节点。
//空间复杂度：O(W)，其中 W 是二叉树中最宽的层的宽度。在最坏情况下，队列中可能包含每一层的所有节点。
        public bool IsCompleteTree(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool reachedEnd = false;

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();

                if (current == null)
                {
                    reachedEnd = true;
                }
                else
                {
                    if (reachedEnd)
                    {
                        return false;
                    }

                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }

            return true;
        }