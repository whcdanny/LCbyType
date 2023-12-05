//Leetcode 1367. Linked List in Binary Tree med
//题意：给定一个二叉树root和一个链表，其中 head 第一个节点为。 如果从 开始的链表中的所有元素都head对应于二叉树中连接的某个向下路径，则返回 True，否则返回 False。在这种情况下，向下路径意味着从某个节点开始并向下的路径。
//思路：DFS,IsSubPath 函数是主函数，它调用 Dfs 函数进行深度优先搜索。Dfs 函数用于检查链表是否是从当前二叉树节点开始的下行路径。在 Dfs 函数中，首先判断链表是否为空，如果为空说明已经成功匹配完整个链表。然后，判断当前二叉树节点是否为空，如果为空说明无法匹配链表。最后，判断链表当前节点的值是否与二叉树节点的值相匹配，如果匹配，则继续递归匹配下一个节点。
//注： 如果链表为空，说明已经成功匹配完整个链表，true
//时间复杂度: O(N * M)，其中 N 是二叉树的节点数，M 是链表的长度
//空间复杂度：O(H)，其中 H 是二叉树的高度
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            if (head == null)
            {
                return true; // 空链表是任何二叉树的下行路径
            }

            if (root == null)
            {
                return false; // 二叉树为空，无法匹配链表
            }

            // 开始从根节点进行深度优先搜索
            return DFS_IsSubPath(head, root) || IsSubPath(head, root.left) || IsSubPath(head, root.right);
        }

        private bool DFS_IsSubPath(ListNode listNode, TreeNode treeNode)
        {
            // 如果链表为空，说明已经成功匹配完整个链表
            if (listNode == null)
            {
                return true;
            }

            // 如果二叉树节点为空，无法匹配链表
            if (treeNode == null)
            {
                return false;
            }

            // 如果链表当前节点的值与二叉树节点的值相匹配，继续递归匹配下一个节点
            if (listNode.val == treeNode.val)
            {
                return DFS_IsSubPath(listNode.next, treeNode.left) || DFS_IsSubPath(listNode.next, treeNode.right);
            }
            else
            {
                return false; // 不匹配，直接返回false
            }
        }