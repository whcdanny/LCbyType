//Leetcode 965. Univalued Binary Tree ez
//题意：判断给定二叉树中所有节点的值是否相同
//思路：BFS（广度优先搜索）我们可以逐层遍历二叉树节点。在遍历的过程中，如果发现某个节点的值与目标值不相等，就返回 false，表示该二叉树不是单值二叉树。如果遍历完成，没有发现不相等的值，就返回 true。
//时间复杂度:假设树中有 N 个节点，每个节点都需要访问一次。所以时间复杂度是 O(N)。
//空间复杂度：在最坏情况下，队列中可能包含树中所有的节点。所以空间复杂度是 O(N)。
        public bool IsUnivalTree(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            int targetValue = root.val;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();

                if (current.val != targetValue)
                {
                    return false;
                }

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }

            return true;
        }