//Leetcode 1530. Number of Good Leaf Nodes Pairs med
//题意：二叉树的根节点和一个整数 distance。二叉树中两个不同的叶子节点组成的一对被称为“好”的叶子节点对，如果它们之间的最短路径的长度小于或等于 distance。要求返回树中好叶子节点对的数量。
//思路： DFS, 对于每个节点，计算其左子树和右子树中好叶子节点对的数量和叶子节点到根节点的距离数组。使用递归函数 CountPairsDFS 返回一个元组，其中第一个元素是以当前节点为根的子树中好叶子节点对的数量，第二个元素是叶子节点到当前节点的距离数组。在递归的过程中，根据左子树和右子树的结果，计算当前节点的好叶子节点对数量，同时更新叶子节点到当前节点的距离数组。最终返回以当前节点为根的子树中好叶子节点对的数量和叶子节点到当前节点的距离数组。       
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(distance)，递归调用栈的最大深度。
        private int goodPairs_CountPairs = 0;
        public int CountPairs(TreeNode root, int distance)
        {
            DFS_CountPairs(root, distance);
            return goodPairs_CountPairs;
        }

        private List<int> DFS_CountPairs(TreeNode node, int distance)
        {
            var res = new List<int>();            
            if (node == null)
            {
                return res;
            }
            if (node.left == null && node.right == null)
            {
                res.Add(1);
                return res;
            }
            //得到所有在current右侧和左侧的最低端的距离，
            var distanceLeft = DFS_CountPairs(node.left, distance);
            var distanceRight = DFS_CountPairs(node.right, distance);
            
            foreach (var left in distanceLeft)
            {
                foreach (var right in distanceRight)
                {
                    if (left + right <= distance)
                        goodPairs_CountPairs++;
                }
            }
            //合并list
            distanceLeft.AddRange(distanceRight);
            //如果不是最低端的node，返回给parent的时候需要+1；
            return distanceLeft.Select(i => i += 1).ToList();
        }