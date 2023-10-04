//Leetcode 314. Binary Tree Vertical Order Traversal med 
//题意：给定一个二叉树，返回其按垂直顺序遍历的节点值。对于每一列（从左到右），先从根节点开始，从上到下依次访问节点值
//思路：广度优先搜索（BFS）序列化：记录每个节点的水平坐标（horizontal coordinate）。根节点的水平坐标为0，左子节点水平坐标减一，右子节点水平坐标加一。
//时间复杂度: 遍历整棵树需要 O(n) 的时间，其中 n 是二叉树的节点数, 排序节点需要 O(nlogn)。O(n + nlogn) = O(nlogn)
//空间复杂度：取决于队列的大小，最坏情况下是都是 O(n)，因为队列可能包含所有节点。

        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Dictionary<int, List<int>> columnMap = new Dictionary<int, List<int>>();            
            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(new Tuple<TreeNode, int>(root, 0));

            int minCol = int.MaxValue, maxCol = int.MinValue;
            int colum = 0;
            while (queue.Count > 0)
            {
                var tuple = queue.Dequeue();
                TreeNode node = tuple.Item1;               
                int col = tuple.Item2;

                if (!columnMap.ContainsKey(col))
                {
                    columnMap[col] = new List<int>();
                }
                columnMap[col].Add(node.val);

                minCol = Math.Min(minCol, col);
                maxCol = Math.Max(maxCol, col);

                if (node.left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.left, col - 1));
                }
                if (node.right != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.right, col + 1));
                }
            }

            for (int i = minCol; i <= maxCol; i++)
            {
                result.Add(columnMap[i]);
            }

            return result;
        }