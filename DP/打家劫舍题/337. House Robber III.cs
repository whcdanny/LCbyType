//337. House Robber III med
//给一二叉树，每个树分支表示每个房子里有多少钱，要求抢最多的钱，要求不能邻近两个都抢；
//思路：动态规划，要不就是当前root+root.left.left+root.left.right+root.right.left+root.right.right
//要不就是当前root的root.left+root.right；
		public int Rob3(TreeNode root)
        {            
            if (root == null) return 0;
            // 利用备忘录消除重叠子问题
            if (memo.ContainsKey(root))
                return memo[root];
            // 抢，然后去下下家
            int do_it = root.val
                + (root.left == null ? 0 : Rob3(root.left.left) + Rob3(root.left.right))
                + (root.right == null ? 0 : Rob3(root.right.left) + Rob3(root.right.right));
            // 不抢，然后去下家
            int not_do = Rob3(root.left) + Rob3(root.right);

            int res = Math.Max(do_it, not_do);
            memo.Add(root, res);
            return res;
        }        
//优化算法：从最底层往上算；        
		public int Rob3(TreeNode root)
        {
            int[] ret = robSub(root);
            return Math.Max(ret[0], ret[1]);            
        }        
        private int[] robSub(TreeNode root)
        {
            if (root == null) return new int[2];

            int[] left = robSub(root.left);
            int[] right = robSub(root.right);

            int[] ret = new int[2];
            ret[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
            ret[1] = root.val + left[0] + right[0];

            return ret;
        }