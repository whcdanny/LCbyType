//Leetcode 105 Construct Binary Tree from Preorder and Inorder Traversal med 
//题意：给定一个二叉树的前序遍历和中序遍历结果，要求构建出原始的二叉树
//思路：DFS，前序遍历的第一个节点是根节点，通过这个节点在中序遍历中找到根节点的位置。
//在中序遍历中，根节点左侧的节点构成了左子树的中序遍历结果，右侧的节点构成了右子树的中序遍历结果。
//在前序遍历中，根节点之后的节点分为两部分，前一部分与左子树的中序遍历结果对应，后一部分与右子树的中序遍历结果对应。
//通过predorder先确定root的val，然后根据inorderMap，找出所在index，然后划分出左右两个区间，然后递归
//In-order traversal - Left -> Root -> Right
//Pre-order traversal - Root -> Left -> Right
//Post-order traversal - Left -> Right -> Root
//时间复杂度:  n 是二叉树的节点个数, O(n)
//空间复杂度： h 是树的高度, O(h);
        private int preIndex = 0;
        private Dictionary<int, int> inorderMap = new Dictionary<int, int>();
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            for (int i = 0; i < inorder.Length; i++)
            {
                inorderMap[inorder[i]] = i;
            }

            return BuildTree(preorder, 0, inorder.Length - 1);
        }
        private TreeNode BuildTree(int[] preorder, int inLeft, int inRight)
        {
            if (inLeft > inRight)
                return null;
            int curVal = preorder[preIndex];
            preIndex++;
            TreeNode root = new TreeNode(curVal);
            int index = inorderMap[curVal];

            root.left = BuildTree(preorder, inLeft, index - 1);
            root.right = BuildTree(preorder, index + 1, inRight);

            return root;
        }