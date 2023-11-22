//Leetcode 653. Two Sum IV - Input is a BST ez
//题意：给定一个二叉搜索树（BST），以及一个整数 k，判断是否存在两个节点的值之和等于 k。
//思路：使用 BFS（广度优先搜索）遍历二叉搜索树，同时使用一个哈希表（HashSet）记录已经访问过的节点值。对于当前节点，判断 k 减去当前节点值是否在哈希表中，如果存在，则找到两个节点的值之和等于 k，返回 true。如果不存在，将当前节点值加入哈希表，并将左右子节点加入队列继续遍历。如果最终没有找到满足条件的节点对，返回 false。       
//时间复杂度: O(n)，其中 n 是二叉搜索树的节点数。在最坏情况下，需要遍历所有节点。
//空间复杂度：O(n)
        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null) return false;

            HashSet<int> visited = new HashSet<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();
                int complement = k - current.val;

                if (visited.Contains(complement))
                {
                    return true;
                }

                visited.Add(current.val);

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }

            return false;
        }