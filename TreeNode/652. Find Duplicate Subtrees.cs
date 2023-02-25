//652. Find Duplicate Subtrees med
//给一个二叉树，然会所有重复的子树；such as Input: root = [1,2,3,4,null,2,4,null,null,4] Output: [[2,4],[4]]
//思路：利用后序想法，从最底层开始，所以可以将二叉树每一层级转换成string，然后用“，”隔开数字，用“#”来表示没有子集，将得到的subTree存入一个dictionary里并存入重复此时，如果==2，就说明重复了，然后存入当前root，
		Dictionary<string, int> map = new Dictionary<string, int>();
        List<TreeNode> resFindDuplicateSubtrees = new List<TreeNode>();
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            traverseFindDuplicateSubtrees(root);
            return resFindDuplicateSubtrees;
        }

        private string traverseFindDuplicateSubtrees(TreeNode root)
        {
            if (root == null)
                return "#";
            string left = traverseFindDuplicateSubtrees(root.left);
            string right = traverseFindDuplicateSubtrees(root.right);
            string subTree = left + "," + right + "," + root.val;
            if (map.ContainsKey(subTree))
            {
                map[subTree]++;
            }
            else
                map.Add(subTree, 1);
            if (map[subTree] == 2)
            {
                if (!resFindDuplicateSubtrees.Contains(root))
                    resFindDuplicateSubtrees.Add(root);
            }
            return subTree;
        }        
