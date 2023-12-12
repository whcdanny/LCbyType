//Leetcode 501. Find Mode in Binary Search Tree med
//题意：给定一个二叉搜索树（BST），找到 BST 中出现次数最多的节点值。如果有多个节点值出现次数相同，则返回其中的所有值。
//思路：（DFS）进行中序遍历，同时更新当前值的计数，并维护一个全局变量表示出现次数最多的值的计数。在遍历过程中，如果当前值的计数大于最大计数，我们更新最大计数，并清空结果列表。
//如果当前值的计数等于最大计数，我们将当前值加入结果列表。在遍历完成后，结果列表中存储的即为出现次数最多的节点值。
//注：由于给定的二叉树是一个二叉搜索树，中序遍历结果是一个递增的序列。在遍历过程中，我们可以维护当前节点值的计数，并在遍历完成后找到出现次数最多的值。
//时间复杂度: O(n)，其中 n 为二叉树的节点数。
//空间复杂度：最坏情况下为 O(h)，其中 h 为二叉树的高度。哈希表用于存储每个子树和的出现次数，最坏情况下需要 O(n) 的额外空间。
        private int currentVal_FindMode;
        private int currentCount_FindMode;
        private int maxCount_FindMode;
        private List<int> modes_FindMode;

        public int[] FindMode(TreeNode root)
        {
            currentVal_FindMode = int.MinValue;
            currentCount_FindMode = 0;
            maxCount_FindMode = 0;
            modes_FindMode = new List<int>();

            InOrderTraversal_FindMode(root);

            return modes_FindMode.ToArray();
        }

        private void InOrderTraversal_FindMode(TreeNode node)
        {
            if (node == null) return;

            InOrderTraversal_FindMode(node.left);

            if (node.val == currentVal_FindMode)
            {
                currentCount_FindMode++;
            }
            else
            {
                currentVal_FindMode = node.val;
                currentCount_FindMode = 1;
            }

            if (currentCount_FindMode > maxCount_FindMode)
            {
                maxCount_FindMode = currentCount_FindMode;
                modes_FindMode.Clear();
                modes_FindMode.Add(currentVal_FindMode);
            }
            else if (currentCount_FindMode == maxCount_FindMode)
            {
                modes_FindMode.Add(currentVal_FindMode);
            }

            InOrderTraversal(node.right);
        }