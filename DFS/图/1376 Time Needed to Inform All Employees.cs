//Leetcode 1376 Time Needed to Inform All Employees med
//题意：假设有一个公司，每个员工都有一个直接上级（除了公司的老板没有直接上级），员工之间通过一系列的管理关系连接在一起。现在需要向所有员工发送通知，当某个员工收到通知后，他会将通知传递给他的下属，直到所有员工都收到通知为止。每个员工接收通知所需的时间是不同的。给定每个员工的通知时间和每个员工的直接上级，以及公司的老板，求通知所有员工所需的最短时间。
//思路：深度优先搜索（DFS）: 构建一个以老板为根节点的树，每个员工作为根节点的子树代表一个部门。从老板开始，依次遍历每个部门，计算每个员工接收通知的时间，并记录最大的接收时间。最终得到的最大接收时间即为通知所有员工所需的最短时间
//时间复杂度:  公司共有 n 个员工, O(n)
//空间复杂度： O(n)
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                if (!tree.ContainsKey(manager[i]))
                {
                    tree[manager[i]] = new List<int>();
                }
                tree[manager[i]].Add(i);
            }
            return NumOfMinutes_DFS(tree, informTime, headID);
        }
        private int NumOfMinutes_DFS(Dictionary<int, List<int>> tree, int[] informTime, int node)
        {
            if (!tree.ContainsKey(node))
            {
                return 0;
            }
            int maxTime = 0;
            foreach (int subNode in tree[node])
            {
                maxTime = Math.Max(maxTime, NumOfMinutes_DFS(tree, informTime, subNode));
            }
            return maxTime + informTime[node];
        }