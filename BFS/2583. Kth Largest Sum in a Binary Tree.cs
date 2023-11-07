//Leetcode 2583. Kth Largest Sum in a Binary Tree med
//题意：给定一棵二叉树和一个正整数k，树的层次和是指在同一层的节点值之和。要求返回二叉树中第k大的层次和（可能不是唯一的）。如果树中层的数量少于k，返回-1。注意，如果两个节点与根节点的距离相同，则它们在同一层。
//思路：我们可以使用BFS（广度优先搜索）来计算每一层的层次和，并将其存储在一个字典中，然后从字典中找到第k大的层次和。
//时间复杂度: BFS遍历整棵树需要O(n)的时间，其中n是树中节点的数量。计算层次和并存储在字典中需要O(n)的空间。查找第k大的层次和需要O(nlogn)的时间（在字典中找到最大的k个层次和）。
//空间复杂度：O(n)
        public long KthLargestLevelSum(TreeNode root, int k)
        {
            if (root == null) return -1;
            List<long> sums = new List<long>();            
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int level=0;
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                long levelSum = 0;
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    levelSum += node.val;

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                sums.Add(levelSum);
                level++;
            }
            
            sums.Sort();
            //sums.Reverse();
            if (k >= 0 && k <= level)
            {
                return sums[^k];
            }
            else
            {
                return -1;
            }
        }