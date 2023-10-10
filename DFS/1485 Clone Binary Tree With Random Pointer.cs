//Leetcode 1485 Clone Binary Tree With Random Pointer med
//题意：给定一个二叉树，每个节点除了左右子节点之外，还有一个指向任意节点的指针。要求克隆这棵树并返回克隆后的树。
//思路：DFS，创建一个哈希表 visited 用于记录已经访问过的节点，防止重复访问。创建一个递归函数 CloneNode，接受一个节点 node 作为参数。
//时间复杂度:   n 是二叉树的节点个数,,  O(n)
//空间复杂度： O(n)
        private Dictionary<Node, Node> CopyRandomBinaryTree_visited = new Dictionary<Node, Node>();

        public Node CopyRandomBinaryTree(Node root)
        {
            return CloneNode(root);
        }

        private Node CloneNode(Node node)
        {
            if (node == null) return null;
            if (CopyRandomBinaryTree_visited.ContainsKey(node)) return CopyRandomBinaryTree_visited[node];

            Node newNode = new Node(node.val);
            CopyRandomBinaryTree_visited[node] = newNode;

            newNode.left = CloneNode(node.left);
            newNode.right = CloneNode(node.right);
            newNode.random = CloneNode(node.random);

            return newNode;
        }
