//Leetcode 1457. Pseudo-Palindromic Paths in a Binary Tree med
//题意：一个二叉树，其中节点的值是从1到9的数字。二叉树中的路径被称为伪回文路径，如果路径上节点值的任意一种排列都是一个回文串。要求返回从根节点到叶子节点的伪回文路径的数量。
//思路：（DFS）遍历二叉树。对于每个节点，使用一个数组 count 记录当前路径上每个数字的出现次数。当到达叶子节点时，检查当前路径上的数字，如果奇数个数字不超过1个，则说明是伪回文路径。
//注：先要是回文，那么奇数只能出现0，或者 1次。
//时间复杂度: O(N)，其中 N 是二叉树的节点数量，每个节点只遍历一次
//空间复杂度： O(H)，其中 H 是二叉树的高度，递归调用栈的最大深度
        public int PseudoPalindromicPaths(TreeNode root)
        {
            return DFS_CountPaths(root, new int[10]);
        }

        private int DFS_CountPaths(TreeNode node, int[] count)
        {
            if (node == null)
            {
                return 0;
            }

            count[node.val]++;
            //走到最头的位置，算之前的历遍的数量，
            if (node.left == null && node.right == null)
            {
                int oddCount = 0;
                //找出所有奇数的个数； 
                for (int i = 1; i <= 9; i++)
                {
                    if (count[i] % 2 == 1)
                    {
                        oddCount++;
                    }
                }

                count[node.val]--; //不算当前，回溯
                return oddCount <= 1 ? 1 : 0; //如果奇数个数字不超过1个，则是伪回文路径
            }

            int leftCount = DFS_CountPaths(node.left, count);
            int rightCount = DFS_CountPaths(node.right, count);

            count[node.val]--; //不算当前，回溯
            return leftCount + rightCount;
        }
