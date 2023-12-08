//Leetcode 979. Distribute Coins in Binary Tree med
//题意：给定一个二叉树，其中每个节点都包含一个整数，表示该节点上的硬币数。现在要通过以下操作，使得每个节点上的硬币数都等于1：
//如果一个节点有多于一个的硬币，它会向其父节点传递一个硬币。
//如果一个节点没有硬币，它会从其父节点接收一个硬币。
//计算完成操作的最小移动次数。
//思路：DFS（深度优先搜索）遍历二叉树。对于每个节点，计算其多余的硬币数（节点值 - 1）。将多余的硬币数累加到移动次数中，表示将多余的硬币移动到其它节点。返回总的移动次数。
//注：这里有一个思路：无论当前节点是否有val都要-1，多余的硬币数移动到当前节点。总的移动次数即为左右子树的多余硬币数的绝对值之和，表示将左右子树多余的硬币数移动到当前节点所需的次数。
//时间复杂度: O(N)，其中N是二叉树中的节点数
//空间复杂度：O(H)，其中H是树的高度。     
        private int moves_DistributeCoins;
        public int DistributeCoins(TreeNode root)
        {
            moves_DistributeCoins = 0;
            DFS_DistributeCoins(root);
            return moves_DistributeCoins;
        }

        private int DFS_DistributeCoins(TreeNode node)
        {
            if (node == null)
                return 0;

            int leftExcess = DFS_DistributeCoins(node.left);
            int rightExcess = DFS_DistributeCoins(node.right);

            moves_DistributeCoins += Math.Abs(leftExcess) + Math.Abs(rightExcess);

            // Calculate excess coins at the current node
            return node.val + leftExcess + rightExcess - 1;
        }
