//Leetcode 987 Vertical Order Traversal of a Binary Tree hard
//题意：给定一个二叉树，要求按垂直顺序遍历并返回节点的值
//思路：DFS，创建一个哈希表，用于将每个节点的坐标作为键，将节点的值作为值进行存储。深度优先搜索（DFS）来遍历二叉树，同时在遍历的过程中记录每个节点的坐标。对哈希表中的键进行排序，以保证按照从左到右的顺序返回节点的值。
//时间复杂度:   n 是二叉树的节点个数,,  O(n * log(n))
//空间复杂度： O(n)
        private Dictionary<int, List<(int, int)>> coordinateMap;
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            coordinateMap = new Dictionary<int, List<(int, int)>>();
            VerticalTraversal_DFS(root, 0, 0);

            List<int> sortedCoordinates = coordinateMap.Keys.ToList();
            sortedCoordinates.Sort();

            IList<IList<int>> res = new List<IList<int>>();

            foreach(int x in sortedCoordinates)
            {
                List<(int, int)> nodes = coordinateMap[x];
                nodes.Sort((a, b) => a.Item2 != b.Item2 ? a.Item2.CompareTo(b.Item2) : a.Item1.CompareTo(b.Item1));

                List<int> temp = new List<int>();
                foreach((int, int)val in nodes)
                {
                    temp.Add(val.Item1);
                }
                res.Add(temp);
            }
            return res;
        }

        private void VerticalTraversal_DFS(TreeNode node, int x, int y)
        {
            if (node == null)
                return;
            if (!coordinateMap.ContainsKey(x))
            {
                coordinateMap[x] = new List<(int, int)>();
            }
            coordinateMap[x].Add((node.val, y));

            VerticalTraversal_DFS(node.left, x - 1, y + 1);
            VerticalTraversal_DFS(node.right, x + 1, y + 1);
        }