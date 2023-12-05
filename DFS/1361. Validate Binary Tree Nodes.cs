//Leetcode 1361. Validate Binary Tree Nodes med
//题意：给定一个有 n 个节点的二叉树，节点编号为 0 到 n-1，以及两个数组 leftChild 和 rightChild，表示每个节点的左孩子和右孩子。如果 leftChild[i] != -1，则节点 i 的左子节点是 leftChild[i]。同理，如果 rightChild[i] != -1，则节点 i 的右子节点是 rightChild[i]。判断这个二叉树是否是一个有效的树，
//即满足以下条件：有且仅有一个根节点。除了根节点之外的每个节点都有且仅有一个父节点。
//思路：DFS, 二叉树必须有根。这是一个没有入边的节点——也就是说，根没有父节点；除根节点外的每个节点都必须有一个父节点；树必须是连接的——每个节点都必须可以从一个节点（根）到达；不可能有循环。
//时间复杂度: O(n)，其中 n 是节点的数量
//空间复杂度：O(n)
        public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            var inDegree = new int[n];
            int root = -1;

            for (int i = 0; i < leftChild.Length; i++)
            {
                var leftNode = leftChild[i];
                var rightNode = rightChild[i];
                //除了根节点之外的每个节点都有且仅有一个父节点,所以如果以及有过degree就证明错
                if (leftNode != -1 && inDegree[leftNode] == 1)
                {
                    return false;
                }
                else if (rightNode != -1 && inDegree[rightNode] == 1)
                {
                    return false;
                }

                if (leftNode != -1)
                {
                    inDegree[leftNode]++;
                }

                if (rightNode != -1)
                {
                    inDegree[rightNode]++;
                }
            }

            //仅有一个根节点，如果多个degree==0 错
            for (int i = 0; i < leftChild.Length; i++)
            {
                if (inDegree[i] == 0)
                {
                    if (root == -1)
                    {
                        root = i;
                    }
                    else 
                    {
                        return false;
                    }
                }
            }

            if (root == -1)
            {
                return false;
            }
            //算出所有历遍的点数检查与n是否相同；
            return DFS_ValidateBinaryTreeNodes(leftChild, rightChild, root) == n;
        }
        
        private int DFS_ValidateBinaryTreeNodes(int[] leftChild, int[] rightChild, int root)
        {
            if (root == -1)
            {
                return 0;
            }

            return 1 + DFS_ValidateBinaryTreeNodes(leftChild, rightChild, leftChild[root]) + DFS_ValidateBinaryTreeNodes(leftChild, rightChild, rightChild[root]);
        }