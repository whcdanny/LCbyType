//Leetcode 2359. Find Closest Node to Given Two Nodes med
//题意：寻找两个节点的公共祖先，并且要求找到的祖先离这两个节点的距离最远，而且如果有多个答案，返回节点索引最小的那个。        
//思路：深度优先搜索 (DFS) 的方式，分别计算从node1和node2经过每个点的距离，然后经过相同点的话，选择最大的距离值，然后从这些距离值找到最小的距离，如果有相同最小距离，就选最小的node
//注：如果有相同最小距离，就选最小的node
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int ClosestMeetingNode(int[] edges, int node1, int node2)
        {
            Dictionary<int, int> walk1 = DFS_ClosestMeetingNode(edges, node1, 0);
            Dictionary<int, int> walk2 = DFS_ClosestMeetingNode(edges, node2, 0);
            //var distances = walk1.Concat(walk2);
            //var groupedDistances = distances.ToLookup(x => x.Key, x => x.Value);
            //var commonAncestors = groupedDistances.Where(x => x.Count() > 1);
            //var selectedAncestor = commonAncestors.Select(x => (x.Key, x.Max(y => y))).DefaultIfEmpty((-1, -1));
            //var result = selectedAncestor.Min(x => (maxDistance: x.Item2, node: x.Item1)).node;
            int res = int.MaxValue;
            int minDis = int.MaxValue;
            foreach(var keyvalue in walk1)
            {
                int key = keyvalue.Key;
                int value = keyvalue.Value;
                if (walk2.ContainsKey(key))
                {
                    int tempMaxValue = Math.Max(value, walk2[key]);
                    if (tempMaxValue < minDis)
                    {
                        minDis = tempMaxValue;
                        res = key;
                        
                    }
                    else if (res > key && tempMaxValue == minDis)
                        res = key;
                }
            }
            return res == int.MaxValue? -1 : res;            
        }

        public Dictionary<int, int> DFS_ClosestMeetingNode(int[] edges, int node, int step)
        {
            var visited = new Dictionary<int, int>();
            visited[node] = step++;
            while (edges[node] >= 0)
            {
                node = edges[node];
                if (visited.ContainsKey(node))
                {
                    break;
                }
                visited[node] = step++;
            }
            return visited;
        }