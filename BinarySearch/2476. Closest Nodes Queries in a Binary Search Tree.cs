//Leetcode 2476. Closest Nodes Queries in a Binary Search Tree med
//题意：给定一棵二叉搜索树（BST）和一个包含正整数的数组 queries，对于每个查询，要找到满足以下条件的最小和最大值：
//mini 是二叉搜索树中小于或等于 queries[i] 的最大值。如果不存在这样的值，则将 -1 添加到答案数组。
//maxi 是二叉搜索树中大于或等于 queries[i] 的最小值。如果不存在这样的值，则将 -1 添加到答案数组。
//最终返回一个二维数组 answer，其中 answer[i] = [mini, maxi]
//思路：二分搜索，先inodertree，得到从小到大的list，然后用二分法分别算出min和max；
//注：这是因为我们要找的是小于等于查询值的最大值，而不是小于查询值的最大值。
//时间复杂度: O(NlogN)，其中 N 是二叉搜索树中节点的数量
//空间复杂度：O(N)
        public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries)
        {
            List<IList<int>> res = new List<IList<int>>();
            List<int> list = new List<int>();
            inorderTree(root, list);
            foreach (int q in queries)
                res.Add(new List<int>() { findMin(list, q), findMax(list, q) });
            return res;
        }
        private void inorderTree(TreeNode root, List<int> list)
        {
            if (root == null) return;
            inorderTree(root.left, list);
            list.Add(root.val);
            inorderTree(root.right, list);
        }
        private int findMin(List<int> list, int q)
        {
            //largest value in the tree that is smaller than or equal to q
            int low = 0, high = list.Count - 1;
            while (low < high)
            {
                //这是因为我们要找的是小于等于查询值的最大值，而不是小于查询值的最大值
                int mid = low + (high - low) / 2 + 1;
                if (list[mid] <= q)
                {
                    low = mid;//这个情境下，我们是在查找最大的小于等于查询值的元素
                }
                else
                    high = mid - 1;
            }
            return list[low] > q ? -1 : list[low];
        }
        private int findMax(List<int> list, int q)
        {
            //smallest value in the tree that is greater than or equal to q
            int low = 0, high = list.Count - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (list[mid] >= q)
                {
                    high = mid;
                }
                else
                    low = mid + 1;
            }
            return list[high] < q ? -1 : list[high];
        }