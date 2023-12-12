//Leetcode 606. Construct String from Binary Tree ez
//题意：给定一个二叉树，构建一个表示其前序遍历的字符串。构建的字符串应该遵循以下规则：
//如果左子树和右子树都为空，则省略它们。如果只有右子树为空，则省略右子树。如果只有左子树为空，则不能省略左子树。
//思路：DFS）进行前序遍历，递归构建字符串 
//时间复杂度: O(n)，其中 n 为节点总数
//空间复杂度：O(h)，其中 h 为二叉树的高度。
        public string Tree2str(TreeNode t)
        {
            if (t == null)
            {
                return "";
            }

            string result = t.val.ToString();

            if (t.left != null || t.right != null)
            {
                result += "(" + Tree2str(t.left) + ")";
            }

            if (t.right != null)
            {
                result += "(" + Tree2str(t.right) + ")";
            }

            return result;
        }