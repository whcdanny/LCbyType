//Leetcode 1145. Binary Tree Coloring Game med
//题意：两名玩家在一棵二叉树上进行回合制游戏。给定二叉树的根节点和节点数量 n。其中 n 为奇数，每个节点的值从 1 到 n 不重复。
//游戏开始时，第一名玩家选择一个值 x（1 <= x <= n），第二名玩家选择一个值 y（1 <= y <= n，且y != x）。第一名玩家将值为 x 的节点标记为红色，第二名玩家将值为 y 的节点标记为蓝色。
//接下来，玩家轮流进行，每个玩家在其回合中选择一个自己颜色的节点（红色如果是玩家1，蓝色如果是玩家2），并将该节点的一个未标记的邻居标记为相同的颜色。邻居可以是该节点的左子节点、右子节点或父节点。        
//如果（仅当）玩家在这种方式下无法选择一个节点，他们必须结束回合。如果两名玩家都结束回合，游戏结束，并且获胜的玩家是标记更多节点的玩家。
//作为第二名玩家，如果有可能选择一个 y 以确保你赢得游戏，则返回 true。如果不可能，返回 false。
//注：说白了就是当x选完，第二个人有没有机会赢；
//思路：DFS 遍历二叉树，计算节点数，并检查赢得游戏的条件。主函数初始化必要的变量并返回最终结果。类级别的变量 (win_BtreeGameWinningMove) 的使用有助于在递归调用之间跟踪胜利条件。
//注：胜利条件就是如果第一个玩家选完x没发现上剩余点数，或者，这个X的left总点数，或者X的right总点数，是否会多余n/2，因为两个人轮流选，所以最多能选n/2；如果有多余那么就证明第二个可以赢；
//时间复杂度: O(N)DFS 遍历每个节点一次
//空间复杂度：O(H)二叉树的高度
        private bool win_BtreeGameWinningMove;

        public bool BtreeGameWinningMove(TreeNode root, int n, int x)
        {
            win_BtreeGameWinningMove = false;
            DFS_BtreeGameWinningMove(root, null, n, x);
            return win_BtreeGameWinningMove;
        }
        private int DFS_BtreeGameWinningMove(TreeNode root, TreeNode parent, int n, int x)
        {
            if (root != null && !win_BtreeGameWinningMove)
            {
                int lc = DFS_BtreeGameWinningMove(root.left, root, n, x);
                int rc = DFS_BtreeGameWinningMove(root.right, root, n, x);
                if (root.val == x)
                {
                    //是当前节点的值不等于 x 时，计算父节点子树中节点的数量。即，以当前节点的父节点为根的子树中的节点数量
                    int pc = n - 1 - lc - rc;
                    //如果一名玩家可以选择超过总节点数的一半的节点就赢了；
                    win_BtreeGameWinningMove = Math.Max(pc, Math.Max(lc, rc)) > n / 2;
                }
                else return lc + rc + 1;
            }

            return 0;
        }
        