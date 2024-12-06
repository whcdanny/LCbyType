//Leetcode 1008. Construct Binary Search Tree from Preorder Traversal med
//题意：给定一个整数数组 preorder，表示BST（即二叉搜索树）的前序遍历，构造该树并返回其根。
//保证对于给定的测试用例总能找到满足给定要求的二叉搜索树。
//二叉搜索树是一种二叉树，其中对于每个节点， 的任何后代都具有严格小于 的Node.left值，
//并且 的任何后代都具有严格大于 的值。 Node.valNode.right Node.val
//二叉树的前序遍历首先显示节点的值，然后遍历，然后Node.left遍历Node.right。
//思路：Pre-order traversal - Root -> Left -> Right
//找出比第一个val是root头，然后左边都是小于这个数，右边都是大于
//找出大与start位置，这样root.left = build_BstFromPreorder(preorder, start + 1, index-1);
//root.right = build_BstFromPreorder(preorder, index, end);
//注：if (start > end || end > preorder.Length -1)
//时间复杂度：O(n)
//空间复杂度：O(n)
        public TreeNode BstFromPreorder(int[] preorder)
        {            
            return build_BstFromPreorder(preorder, 0, preorder.Length - 1);
        }

        private TreeNode build_BstFromPreorder(int[] preorder, int start, int end)
        {
            if (start > end || end > preorder.Length -1)
                return null;

            int index = start+1;
            int value = preorder[start];

            while (index <= end && preorder[index] < value)
                index++;

            TreeNode root = new TreeNode(value);
            root.left = build_BstFromPreorder(preorder, start + 1, index - 1);
            root.right = build_BstFromPreorder(preorder, index, end);
            return root;
        }