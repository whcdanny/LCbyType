//Leetcode 971. Flip Binary Tree To Match Preorder Traversal med
//题意：给定一个二叉树和一个先序遍历的数组 voyage，如果可以通过翻转某些节点的左右子树，使得二叉树的先序遍历与 voyage 相匹配，则返回翻转的节点值的列表；否则返回列表 [-1]。       
//思路：DFS（深度优先搜索）遍历二叉树。在遍历的过程中，比较当前节点的值与 voyage 数组中对应位置的值是否相同。如果相同，则继续递归遍历左右子树.如果不同，需要翻转当前节点的左右子树，然后继续递归遍历左右子树。如果无法满足题意，返回[-1]。
//注：当没有找到对应的val，要反转并记下当前val；
//时间复杂度: O(N)，其中N是二叉树中的节点数
//空间复杂度：O(H)，其中H是树的高度。     
        private List<int> flips_FlipMatchVoyage;
        private int index_FlipMatchVoyage;
        public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
        {
            flips_FlipMatchVoyage = new List<int>();
            index_FlipMatchVoyage = 0;

            if (DFS_FlipMatchVoyage(root, voyage))
                return flips_FlipMatchVoyage;

            return new List<int> { -1 };
        }

        private bool DFS_FlipMatchVoyage(TreeNode node, int[] voyage)
        {
            if (node == null)
                return true;

            if (node.val != voyage[index_FlipMatchVoyage++])
                return false;

            if (node.left != null && node.left.val != voyage[index_FlipMatchVoyage])
            {
                flips_FlipMatchVoyage.Add(node.val);
                return DFS_FlipMatchVoyage(node.right, voyage) && DFS_FlipMatchVoyage(node.left, voyage);
            }

            return DFS_FlipMatchVoyage(node.left, voyage) && DFS_FlipMatchVoyage(node.right, voyage);
        }
