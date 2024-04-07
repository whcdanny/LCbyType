//Leetcode 2508. Add Edges to Make Degrees of All Nodes Even hard
//题意：给定一个包含n个节点的无向图，节点编号从1到n。还给定一个二维数组edges，表示图中的边。
//可以在图中添加最多两条额外的边（可能为零），使得每个节点的度数都是偶数。判断是否可能实现这样的情况。
//思路：hashtable, 先构图，然后找的奇数的点位；
//因为连线，所以必须要有2个或者4个的奇数点；
//如果m等于1，那么任何新连接到m的边，都会破坏另一个节点度的偶性。
//如果m等于2，那么(1) 如果这两点之间没有边，那么就一条边将其相邻即可。(2) 如果这两点a,b之间已经有边，那么我们需要令找一个（度为偶数）的点c，且该点ac和bc都能再连一条边。
//如果m等于3，我们无法用两条边，仅改变这三个点的度的奇性。
//如果m等于4，我们令其为a,b,c,d。只有ab、cd可连边，或者ac、bd可连边，或者ad、bc可连边，三种情况能符合要求。
//如果m大于等于5，我们无法用两条边连到5个或更多的点（改变它们的度），返回false。             
//时间复杂度：O(n)
//空间复杂度：O(n)
        public bool IsPossible(int n, IList<IList<int>> edges)
        {
            HashSet<int>[] map = new HashSet<int>[100005];
            for (int i = 1; i <= n; i++)
            {
                map[i] = new HashSet<int>();
            }

            foreach (var edge in edges)
            {
                int a = edge[0], b = edge[1];
                map[a].Add(b);
                map[b].Add(a);
            }

            List<int> odds = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if ((map[i].Count % 2) == 1)
                {
                    odds.Add(i);
                }
            }

            if (odds.Count == 0) 
                return true;

            if (odds.Count == 2)
            {
                int a = odds[0], b = odds[1];
                if (!map[a].Contains(b)) 
                    return true;
                foreach (int i in Enumerable.Range(1, n))
                {
                    if (i == a || i == b) continue;
                    if (!map[i].Contains(a) && !map[i].Contains(b)) 
                        return true;
                }
                return false;
            }

            if (odds.Count == 4)
            {
                int a = odds[0], b = odds[1], c = odds[2], d = odds[3];
                if (!map[a].Contains(b) && !map[c].Contains(d)) return true;
                if (!map[a].Contains(c) && !map[b].Contains(d)) return true;
                if (!map[a].Contains(d) && !map[b].Contains(c)) return true;
                return false;
            }

            return false;
        }