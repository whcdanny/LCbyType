//Leetcode 427. Construct Quad Tree med
//题意：给定一个 n×n 的矩阵 grid，矩阵中的元素仅包含 0 和 1。我们需要用 四叉树 来表示该矩阵。
//四叉树定义：
//四叉树是一个树形数据结构，其中每个内部节点恰好有四个子节点。
//每个节点有以下两个属性：
//val：布尔值。如果节点表示的网格全是 1，则为 True；如果全是 0，则为 False。
//isLeaf：布尔值。如果节点是叶子节点，则为 True；否则为 False。
//四叉树构建规则：
//如果当前网格的值全相同（全 1 或全 0），设置 isLeaf 为 True，val 为网格值，并将四个子节点设置为 null。
//如果当前网格的值不同，设置 isLeaf 为 False，val 可设置为任意值。将当前网格划分为四个子网格（左上、右上、左下、右下），递归构建每个子网格的四叉树节点。
//思路：递归方法：
//检查当前网格是否全为 0 或 1。
//如果是全 0 或全 1，创建叶子节点并返回。
//否则，将当前网格划分为四个子网格，递归地为每个子网格创建四叉树节点。
//返回一个非叶子节点，子节点是四个递归调用的结果。
//划分网格：
//每次将网格按照中心划分为四个子网格，分别是：
//左上角网格
//右上角网格
//左下角网格
//右下角网格
//时间复杂度：O(n^2logn) logn 是递归深度
//空间复杂度：O(n)
        public Node Construct(int[][] grid)
        {
            return BuildQuadTree(grid, 0, 0, grid.Length);
        }

        private Node BuildQuadTree(int[][] grid, int row, int col, int size)
        {
            if (size == 1)
            {
                // 基本情况：单个网格
                return new Node(grid[row][col] == 1, true);
            }

            // 划分网格为四部分
            int halfSize = size / 2;
            Node topLeft = BuildQuadTree(grid, row, col, halfSize);
            Node topRight = BuildQuadTree(grid, row, col + halfSize, halfSize);
            Node bottomLeft = BuildQuadTree(grid, row + halfSize, col, halfSize);
            Node bottomRight = BuildQuadTree(grid, row + halfSize, col + halfSize, halfSize);

            // 检查四个子节点是否可以合并
            if (topLeft.isLeaf && topRight.isLeaf && bottomLeft.isLeaf && bottomRight.isLeaf &&
                topLeft.val == topRight.val && topLeft.val == bottomLeft.val && topLeft.val == bottomRight.val)
            {
                return new Node(topLeft.val, true); // 合并为叶子节点
            }

            // 无法合并，返回非叶子节点
            return new Node(false, false, topLeft, topRight, bottomLeft, bottomRight);
        }
        public class Node
        {
            public bool val;
            public bool isLeaf;
            public Node topLeft;
            public Node topRight;
            public Node bottomLeft;
            public Node bottomRight;

            public Node()
            {
                val = false;
                isLeaf = false;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = _topLeft;
                topRight = _topRight;
                bottomLeft = _bottomLeft;
                bottomRight = _bottomRight;
            }
        }