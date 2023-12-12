//Leetcode 655. Print Binary Tree med
//题意：给定一个二叉树，按照从上到下、从左到右的层序遍历，返回其每个层的节点值。如果某个位置上的节点为 null，则使用字符串 "null" 表示。
//思路：（DFS）来解决这个问题。首先，我们需要找到二叉树的高度，以确定输出数组的行数。然后，我们可以使用 DFS 在每一行上填充节点的值。
//注：满二叉树的节点数int width = (1 << height) - 1, 形成一个二进制数，其最高位为 1，后面跟着 height 个零。创建一个二进制数，其中从最高位到最低位都是 1，总共有 height 个 1。这种方式用来表示二叉树每一层的节点个数。; 并且节点的位置int mid = (left + right) / 2;
//时间复杂度: O(N)，其中 N 是二叉树中的节点数
//空间复杂度：O(H * 2^H)，其中 H 是二叉树的高度。在最坏的情况下，输出数组的大小为 H * 2^H。
        public IList<IList<string>> PrintTree(TreeNode root)
        {
            int height = getHeight(root);
            IList<IList<string>> result = new List<IList<string>>();
            for (int i = 0; i < height; i++)
            {
                result.Add(new List<string>());
                for (int j = 0; j < (1 << height) - 1; j++)
                {
                    result[i].Add("");
                }
            }
            DFS_PrintTree(root, 0, 0, (1 << height) - 1, result);
            return result;
        }

        private int getHeight(TreeNode node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(getHeight(node.left), getHeight(node.right));
        }

        private void DFS_PrintTree(TreeNode node, int depth, int left, int right, IList<IList<string>> result)
        {
            if (node == null) return;
            int mid = (left + right) / 2;
            result[depth][mid] = node.val.ToString();
            DFS_PrintTree(node.left, depth + 1, left, mid - 1, result);
            DFS_PrintTree(node.right, depth + 1, mid + 1, right, result);
        }