//Leetcode 1372. Longest ZigZag Path in a Binary Tree med
//题意：给定的二叉树中找到最长的 ZigZag 路径，ZigZag 路径的定义如下：
//选择二叉树中的任意节点和一个方向（右或左）。
//如果当前方向是右，则移动到当前节点的右子节点；否则，移动到左子节点。
//改变方向，从右到左或从左到右。
//重复第二和第三步，直到在树中无法移动。
//ZigZag 长度定义为访问的节点数减1（单个节点的长度为0）。
//思路：深度优先搜索（DFS）LongestZigZag 函数是主函数，它调用两次 Dfs 函数，分别表示从根节点开始的 ZigZag 路径，一次是从右开始，一次是从左开始。Dfs 函数进行深度优先搜索，同时记录当前的路径长度，并更新最长的 ZigZag 路径。在 Dfs 函数中，根据当前方向（isRight），选择递归调用左子节点或右子节点，并更新路径长度。同时，交换方向并递归调用另一个子节点。
//注：当换行时，注意两种情况 可以换向，那么length+1；也可以不换向，重置length；
//时间复杂度: O(N)，其中 N 是二叉树的节点数
//空间复杂度：O(H)，其中 H 是二叉树的高度
        public int LongestZigZag(TreeNode root)
        {
            int maxZigZag = 0;
            DFS_LongestZigZag(root, true, 0, ref maxZigZag); // true表示当前方向是右
            DFS_LongestZigZag(root, false, 0, ref maxZigZag); // false表示当前方向是左
            return maxZigZag;
        }

        private void DFS_LongestZigZag(TreeNode node, bool isRight, int currentLength, ref int maxZigZag)
        {
            if (node == null)
            {
                return;
            }

            maxZigZag = Math.Max(maxZigZag, currentLength);

            if (isRight)
            {
                DFS_LongestZigZag(node.right, false, currentLength + 1, ref maxZigZag);
                DFS_LongestZigZag(node.left, true, 1, ref maxZigZag);
            }
            else
            {
                DFS_LongestZigZag(node.left, true, currentLength + 1, ref maxZigZag);
                DFS_LongestZigZag(node.right, false, 1, ref maxZigZag);
            }
        }