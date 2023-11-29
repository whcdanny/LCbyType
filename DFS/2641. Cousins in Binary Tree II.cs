//Leetcode 2641. Cousins in Binary Tree II  mid
//题意：给定一个二叉树的根节点 root，将树中每个节点的值替换为其所有堂兄弟节点值的和。在二叉树中，如果两个节点在相同的深度上但有不同的父节点，那么它们被称为堂兄弟节点。要求返回修改后的树的根节点。注意，一个节点的深度是指从根节点到该节点的路径中的边的数量。
//思路：DFS 遍历二叉树, 算出每一层的总和，然后用将当前的子集之和算出，然后用层总和减去当前子集之和，并将这个值更新在当前子集的值，
//注：这题是反转cusions，而是在cousins的层面上，用cousin层总和-当前所在的值之和，也就是减去当前父母所有孩子的之和，并将val替换而已
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(w)，其中 w 是树的宽度
        public TreeNode ReplaceValueInTree(TreeNode root)
        {
            Dictionary<int, int> depth = new Dictionary<int, int>();
            Dictionary<int, TreeNode> parent = new Dictionary<int, TreeNode>();
            List<int> levelSum = new List<int>();
            DFS_SumValueInTree(root, 0, levelSum);
            DFS_ReplaceValueInTree(root, 0, levelSum);
            root.val = 0;
            return root;
        }

        private void DFS_ReplaceValueInTree(TreeNode node, int depth, List<int> levelSum)
        {
            if (node == null)
                return;
            int childSum = 0;
            if (node.left != null)
                childSum += node.left.val;
            if (node.right != null)
                childSum += node.right.val;

            if (node.left != null)
                node.left.val = levelSum[depth + 1] - childSum;
            if (node.right != null)
                node.right.val = levelSum[depth + 1] - childSum;

            DFS_ReplaceValueInTree(node.left, depth + 1, levelSum);
            DFS_ReplaceValueInTree(node.right, depth + 1, levelSum);

        }

        private void DFS_SumValueInTree(TreeNode node, int depth, List<int> levelSum)
        {
            if (node == null)
                return;
            if(levelSum.Count<= depth)
            {
                levelSum.Add(node.val);
            }
            else
            {
                levelSum[depth] += node.val;
            }
            DFS_SumValueInTree(node.left, depth + 1, levelSum);
            DFS_SumValueInTree(node.right, depth + 1, levelSum);
        }