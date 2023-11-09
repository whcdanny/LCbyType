//Leetcode 2415. Reverse Odd Levels of Binary Tree med
//题意：给定一个二叉树，你需要反转所有奇数层的节点。
//思路：我们可以使用BFS（广度优先搜索）,来遍历树的所有节点，同时在遍历的过程中记录每个节点所在的层级。对于奇数层的节点，先把所有奇数层里的treenode存在list里 然后只改变val就可以了 用左右针。
//时间复杂度: O(n)，其中n是树中的节点数
//空间复杂度：O(n)
        public TreeNode ReverseOddLevels(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int level = 1;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                List<TreeNode> oddList = new List<TreeNode>();
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    oddList.Add(node);
                    
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                if (level % 2 == 1)
                {
                    int left = 0;
                    int right = oddList.Count - 1;
                    while (left < right)
                    {
                        int temp = oddList[left].val;
                        oddList[left].val = oddList[right].val;
                        oddList[right].val = temp;
                        left++;
                        right--;
                    }
                }

                level++;
            }

            return root;
        }