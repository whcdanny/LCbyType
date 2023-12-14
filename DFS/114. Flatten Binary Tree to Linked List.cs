//Leetcode 114. Flatten Binary Tree to Linked List med
//题意：给定一个二叉树，原地将其展开为一个单链表。展开后的单链表应该按照先序遍历的顺序，从树的根开始。
//思路：深度优先搜索（DFS）从根节点开始进行深度优先搜索，将每个节点的左子树置为空，右子树设置为先序遍历的下一个节点。在递归过程中，先递归右子树，再递归左子树。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)。
        public void Flatten(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            FlattenDFS(root);
        }

        private TreeNode FlattenDFS(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            TreeNode leftLast = FlattenDFS(node.left);
            TreeNode rightLast = FlattenDFS(node.right);

            if (node.left != null)
            {
                // 将左子树置为空，右子树设置为先序遍历的下一个节点
                TreeNode temp = node.right;
                node.right = node.left;
                node.left = null;

                // 找到左子树的最后一个节点
                if (leftLast != null)
                {
                    leftLast.right = temp;
                }
            }

            return rightLast != null ? rightLast : (leftLast != null ? leftLast : node);
        }