//Leetcode 623. Add One Row to Tree med
//题意：给定一个二叉树，以及一个值 v 和深度 d，向二叉树中第 d 层的所有节点添加一行，新行的值都为 v。添加行的位置是从左到右。
//思路：BFS（广度优先搜索）遍历二叉树，到达指定深度 d 时，在该层的节点前后插入新节点即可。需要注意的是，如果当前深度 d 为 1，即在根节点之前插入新节点，需要特殊处理。       
//时间复杂度: O(n)，其中 n 是二叉树的节点数
//空间复杂度：O(m)，其中 m 是树中某一层的最大节点数
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
            {
                TreeNode newRoot = new TreeNode(val);
                newRoot.left = root;
                return newRoot;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            for (int de = 1; de < depth - 1; de++)
            {
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode current = queue.Dequeue();

                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }
            }

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();

                TreeNode left = new TreeNode(val);
                left.left = current.left;
                current.left = left;

                TreeNode right = new TreeNode(val);
                right.right = current.right;
                current.right = right;
            }

            return root;
        }