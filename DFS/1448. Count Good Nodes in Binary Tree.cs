//Leetcode 1448. Count Good Nodes in Binary Tree med
//题意：给定一棵二叉树root，如果从根到X的路径中不存在值大于X的节点，则树中的节点X被命名为 良好。返回二叉树中好节点的数量。
//思路：（DFS）遍历二叉树。对于每个节点，判断节点值是否大于等于路径上的最大值（maxValue）。如果是，则将该节点计数，并更新 maxValue。递归遍历左右子树，将计数结果累加。
//注：这里一定是从root开始，一开始的maxValue是root.val，但当你历遍的时候，记得更新你的maxValue如果遇到比当前大的，因为你要保整当前的path往下走都要大于maxValue，而不是root.val；
//时间复杂度: O(N)，其中 N 是树中节点的数量。
//空间复杂度：O(H)，其中 H 是二叉树的高度，递归调用栈的最大深度。
        public int GoodNodes(TreeNode root)
        {
            return CountGoodNodes(root, int.MinValue);
        }

        private int CountGoodNodes(TreeNode node, int maxValue)
        {
            if (node == null)
            {
                return 0;
            }
            //判断节点值是否大于等于路径上的最大值（maxValue），如果是那就是一条好的path
            int count = 0;
            if (node.val >= maxValue)
            {
                count++;
                maxValue = node.val;
            }

            count += CountGoodNodes(node.left, maxValue);
            count += CountGoodNodes(node.right, maxValue);

            return count;
        }