//Leetcode 617. Merge Two Binary Trees ez
//题意：给定两个二叉树，将它们合并成一个新的二叉树。合并规则是，如果两个节点重叠，将它们的值相加；否则，取非空节点的值。
//思路：使用BFS（广度优先搜索）遍历两棵树，将对应位置上的节点合并。队列中存储的是每一层需要合并的节点对。  
//时间复杂度: O(n)，其中 n 为节点总数
//空间复杂度：O(w)，其中 w 为树的最大宽度
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null)
            {
                return root2;
            }

            if (root2 == null)
            {
                return root1;
            }

            Queue<TreeNode[]> queue = new Queue<TreeNode[]>();
            queue.Enqueue(new TreeNode[] { root1, root2 });

            while (queue.Count > 0)
            {
                TreeNode[] nodes = queue.Dequeue();
                TreeNode node1 = nodes[0];
                TreeNode node2 = nodes[1];

                node1.val += node2.val;

                if (node1.left != null && node2.left != null)
                {
                    queue.Enqueue(new TreeNode[] { node1.left, node2.left });
                }
                else if (node1.left == null && node2.left != null)
                {
                    node1.left = new TreeNode(0);
                    queue.Enqueue(new TreeNode[] { node1.left, node2.left });
                }

                if (node1.right != null && node2.right != null)
                {
                    queue.Enqueue(new TreeNode[] { node1.right, node2.right });
                }
                else if (node1.right == null && node2.right != null)
                {
                    node1.right = new TreeNode(0);
                    queue.Enqueue(new TreeNode[] { node1.right, node2.right });
                }
            }

            return root1;
        }
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null)
            {
                return root2;
            }

            if (root2 == null)
            {
                return root1;
            }

            TreeNode merged = new TreeNode(root1.val + root2.val);
            merged.left = MergeTrees(root1.left, root2.left);
            merged.right = MergeTrees(root1.right, root2.right);

            return merged;
        }