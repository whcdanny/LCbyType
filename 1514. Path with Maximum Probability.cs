1514. Path with Maximum Probability		
//C#		
		class Edge
        {
            public int node;
            public double probability;

            public Edge(int node, double probability)
            {
                this.node = node;
                this.probability = probability;
            }
        }
        public double maxProbability(int n, int[][] edges, double[] probabilities, int start, int end)
        {
            HashSet<Edge>[] graph = new HashSet<Edge>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new HashSet<Edge>();
            }
            for (int j = 0; j < edges.Length; j++)
            {
                int[] edge = edges[j];
                double probability = probabilities[j];
                graph[edge[0]].Add(new Edge(edge[1], probability));
                graph[edge[1]].Add(new Edge(edge[0], probability));
            }
            Queue<Edge> edgesToVisit = new Queue<Edge>();
            double[] maxProbabilities = new double[n];
            edgesToVisit.Enqueue(new Edge(start, 1D));
            while (edgesToVisit.Count()!=0)
            {
                Edge edge = edgesToVisit.Dequeue();
                int sourceNode = edge.node;
                double probability = edge.probability;
                HashSet<Edge> nextEdges = graph[sourceNode];
                foreach (Edge nextEdge in nextEdges)
                {
                    int nextNode = nextEdge.node;
                    double newProbability = probability * nextEdge.probability;
                    if (maxProbabilities[nextNode] < newProbability)
                    {
                        edgesToVisit.Enqueue(new Edge(nextNode, newProbability));
                        maxProbabilities[nextNode] = newProbability;
                    }
                }
            }
            return maxProbabilities[end];
        }