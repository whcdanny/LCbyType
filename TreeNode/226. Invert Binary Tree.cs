//226. Invert Binary Tree ez
//输入一个二叉树根节点 root，让你把整棵树镜像翻转
//思路：利用函数定义，先翻转左右子树；然后交换左右子节点
		public TreeNode InvertTree(TreeNode root)
        {            
            if (root == null)
            {
                return null;
            }
            // 利用函数定义，先翻转左右子树
            TreeNode left = InvertTree(root.left);
            TreeNode right = InvertTree(root.right);

            // 然后交换左右子节点
            root.left = right;
            root.right = left;

            // 和定义逻辑自恰：以 root 为根的这棵二叉树已经被翻转，返回 root
            return root;
        }        
//思路：从头开始就把每个节点的左右翻转
		public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;
            InvertTree(root.left);
            InvertTree(root.right);

            return root;            
        }        
		
	/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */