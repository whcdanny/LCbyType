//Leetcode 1261. Find Elements in a Contaminated Binary Tree med
//题意：这是一个关于二叉树的问题，题目描述为：给定一个二叉树，其中节点值为 0 或 1，但是树中的节点已经被修改过。现在，树中所有节点的修改被反映在节点的 val 属性上，而不是 left 或 right 指针。需要实现 FindElements 类：
//FindElements(TreeNode* root)，用无效的 root 节点初始化该类。
//bool Find(int target)，判断值为 target 的节点是否存在于二叉树中。
//这里的二叉树被修改为满足以下条件：root.val == 0;如果 TreeNode.val == x 且 TreeNode.left != null，那么 TreeNode.left.val == 2 * x + 1;如果 TreeNode.val == x 且 TreeNode.right != null，那么 TreeNode.right.val == 2 * x + 2
//思路：在 FindElements 构造函数中，我们使用深度优先搜索（DFS）遍历污染的二叉树，还原二叉树节点的值，并将值存储在 HashSet 中。在 Find 方法中，我们直接检查目标值是否在 HashSet 中，从而判断目标值是否存在于还原后的二叉树中。
//时间复杂度: FindElements: O(n), HashSet: O(1)。
//空间复杂度：FindElements: O(n), HashSet: O(1)。
        public class FindElements
        {
            private HashSet<int> recoveredSet;
            public FindElements(TreeNode root)
            {
                recoveredSet = new HashSet<int>();
                RecoverTree(root, 0);
            }
            private void RecoverTree(TreeNode node, int val)
            {
                if (node == null)
                {
                    return;
                }
                node.val = val;
                recoveredSet.Add(val);

                RecoverTree(node.left, 2 * val + 1);
                RecoverTree(node.right, 2 * val + 2);
            }
            public bool Find(int target)
            {
                return recoveredSet.Contains(target);
            }
        }