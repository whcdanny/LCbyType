//Leetcode 1361. Validate Binary Tree Nodes med
//题意：给定一个有 n 个节点的二叉树，节点编号为 0 到 n-1，以及两个数组 leftChild 和 rightChild，表示每个节点的左孩子和右孩子。如果 leftChild[i] != -1，则节点 i 的左子节点是 leftChild[i]。同理，如果 rightChild[i] != -1，则节点 i 的右子节点是 rightChild[i]。判断这个二叉树是否是一个有效的树，即满足以下条件：有且仅有一个根节点。除了根节点之外的每个节点都有且仅有一个父节点。
//思路：BFS 遍历整个二叉树, 先建立一个父辈的list，从中找到root头儿，然后历遍left和right，最后如果发现有node没有visited，那么就不是binary tree；
//时间复杂度: O(n)
//空间复杂度：O(n)
        public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            int[] parent = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (leftChild[i] != -1)
                {
                    parent[leftChild[i]]++;
                }

                if (rightChild[i] != -1)
                {
                    parent[rightChild[i]]++;
                }
            }

            int rootNode = -1;

            for (int i = 0; i < n; i++)
            {
                if (parent[i] == 0)
                {
                    rootNode = i;
                    break;
                }
            }

            if (rootNode == -1)
            {
                return false;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(rootNode);
            bool[] visited = new bool[n];

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (visited[current])
                {
                    return false;
                }

                visited[current] = true;

                if (leftChild[current] != -1)
                {
                    queue.Enqueue(leftChild[current]);
                }

                if (rightChild[current] != -1)
                {
                    queue.Enqueue(rightChild[current]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    return false;
                }
            }

            return true;
        }
