//Leetcode 1367. Linked List in Binary Tree med
//题意：给定一个二叉树root和一个链表，其中 head 第一个节点为。 如果从 开始的链表中的所有元素都head对应于二叉树中连接的某个向下路径，则返回 True，否则返回 False。在这种情况下，向下路径意味着从某个节点开始并向下的路径。
//思路：BFS（广度优先搜索）对于每个遍历到的节点，调用 IsSubPathFrom 函数判断以当前节点为起点是否能够匹配链表路径。如果匹配成功，则返回 true。最终，如果遍历完整棵二叉树都没有找到匹配的路径，则返回 false。
//时间复杂度: O(m * n)
//空间复杂度：O(n)
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            if (head == null) return true;
            if (root == null) return false;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (IsSubPathFrom(node, head)) return true;

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            return false;
        }
        private bool IsSubPathFrom(TreeNode node, ListNode head)
        {
            if (head == null) return true;
            if (node == null) return false;

            if (node.val != head.val) return false;

            return IsSubPathFrom(node.left, head.next) || IsSubPathFrom(node.right, head.next);
        }