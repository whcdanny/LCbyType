//Leetcode 2467. Most Profitable Path in a Tree med
//题意：给定一个具有n个节点的二叉树的根节点。每个节点从1到n都被分配了一个唯一的值。还给定一个大小为m的数组queries。对树执行m个独立的查询，其中在第i个查询中，执行以下操作：
//从以值queries[i] 为根的子树中删除节点。保证queries[i] 不等于根的值。返回一个大小为m的数组answer，其中answer[i] 是执行第i个查询后树的高度。
//注：查询是独立的，因此每个查询后树都恢复到初始状态。树的高度是从根到树中某个节点的最长简单路径中的边数。
//思路：（DFS）进行遍历，先用DFS算出每个node对应的从下往上的高度，然后再用DFS算除去每个node所剩的最大高度，然后根据queries来得出答案；
//注： 删除左树，就要看现在右子树的高度+ 1；删除右树，就要看现在左子树的高度 + 1       
//时间复杂度: O(N)
//空间复杂度：O(N)
        public int[] TreeQueries(TreeNode root, int[] queries)
        {

            Dictionary<int, int> heightsRooted = new Dictionary<int, int>();
            GetHeightRootedAt(root, heightsRooted);

            int[] heightsWithout = new int[heightsRooted.Count + 1];
            GetHeightsWithoutNode(root, 0, 0, heightsWithout, heightsRooted);

            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = heightsWithout[queries[i]];
            }

            return result;
        }

        private void GetHeightsWithoutNode(TreeNode node, int height, int possibleMaxHeight, int[] heightsWithout, Dictionary<int, int> heightsRooted)
        {
            if (node == null)
            {
                return;
            }

            int leftHeight = node.left == null ? -1 : heightsRooted[node.left.val];
            int rightHeight = node.right == null ? -1 : heightsRooted[node.right.val];

            //删除左树，就要看现在右子树的高度+ 1
            GetHeightsWithoutNode(node.left, height + 1,Math.Max(possibleMaxHeight, rightHeight + height + 1), heightsWithout, heightsRooted);
            //删除右树，就要看现在左子树的高度 + 1
            GetHeightsWithoutNode(node.right, height + 1, Math.Max(possibleMaxHeight, leftHeight + height + 1), heightsWithout, heightsRooted);

            heightsWithout[node.val] = Math.Max(height - 1, possibleMaxHeight);
        }

        private int GetHeightRootedAt(TreeNode node, Dictionary<int, int> heightsRooted)
        {
            if (node == null)
            {
                return -1;
            }
            int maxHeight = 1 + Math.Max(GetHeightRootedAt(node.left, heightsRooted),GetHeightRootedAt(node.right, heightsRooted));
            heightsRooted.Add(node.val, maxHeight);
            return maxHeight;
        }