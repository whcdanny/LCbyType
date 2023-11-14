//Leetcode 1448. Count Good Nodes in Binary Tree med
//题意：给定一棵二叉树root，如果从根到X的路径中不存在值大于X的节点，则树中的节点X被命名为 良好。返回二叉树中好节点的数量。
//思路： BFS 遍历二叉树，维护一个 maxSoFar 变量，表示当前路径上的最大值。每次遍历到一个节点时，比较该节点的值和 maxSoFar，如果大于或等于，则将 count 值加 1，同时更新 maxSoFar 为该节点的值。然后将左右子节点加入队列。
//时间复杂度: O(N)，其中 N 是树中节点的数量。
//空间复杂度：队列中最多同时存储一层的节点，因此空间复杂度为 O(W)，其中 W 为树的最大宽度。在最坏情况下，W 可能达到 O(N)，即树为满二叉树，此时空间复杂度为 O(N)。
        public int GoodNodes(TreeNode root)
        {
            if (root == null) return 0;

            int count = 0;
            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root, int.MinValue));

            while (queue.Count > 0)
            {
                (TreeNode node, int maxSoFar) = queue.Dequeue();

                if (node.val >= maxSoFar)
                {
                    count++;
                    maxSoFar = node.val;
                }

                if (node.left != null)
                {
                    queue.Enqueue((node.left, maxSoFar));
                }

                if (node.right != null)
                {
                    queue.Enqueue((node.right, maxSoFar));
                }
            }

            return count;
        }