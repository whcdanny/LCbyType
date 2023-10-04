//Leetcode 133. Clone Graph med
//题意：给定一个无向连通图中的一个节点的引用，返回该图的深拷贝（克隆）。图中的每个节点都包含它的值 val（Int） 和其邻居的列表（list[Node]）。
//思路：广度优先搜索（BFS）序列化：克隆一个图，首先要克隆节点。由于图可能存在循环，我们需要记录哪些节点已经被访问过以避免无限循环。我们可以使用哈希表来做这个记录, 将原图中的节点作为键，克隆节点作为值。然后，对于每个节点，我们遍历其邻居节点，并将克隆节点的邻居列表初始化为原节点的邻居列表的克隆。
//时间复杂度: O(n+m)
//空间复杂度：O(n)
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
        private Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
        public Node CloneGraph(Node node)
        {
            if (node == null)
                return null;
            if (visited.ContainsKey(node))
            {
                return visited[node];
            }
            Node cloneNode = new Node(node.val, new List<Node>());
            visited[node] = cloneNode;
            foreach(var neighbro in node.neighbors)
            {
                cloneNode.neighbors.Add(CloneGraph(neighbro));
            }
            return cloneNode;
        }