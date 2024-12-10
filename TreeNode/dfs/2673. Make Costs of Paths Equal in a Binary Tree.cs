//Leetcode 2673. Make Costs of Paths Equal in a Binary Tree med
//题意：给定一个整数n，表示一个完美二叉树的节点数，节点从 1 到 n 编号。
//树的根节点是节点 1，每个节点 i 有两个子节点：
//左子节点为 2×i
//右子节点为 2×i+1
//每个节点 i 的成本由一个大小为 n 的数组 cost 提供，其中cost[i] 表示节点 i+1 的成本。
//你可以任意多次将节点的成本加 1。
//返回使从根节点到每个叶子节点的路径成本相等的最小增量次数。
//思路：1. 基本思路递归遍历树的所有节点，自底向上计算每个节点到叶子的路径成本。
//如果左右子树的路径成本不同，通过调整较小的路径使两者相等。
//2. 递归函数逻辑终止条件：如果当前节点node 超出了节点范围（超过 n），返回 0，因为没有对应的子节点。
//递归计算左右子树路径成本：递归计算左子树 left = DFS(2 * node)递归计算右子树 right = DFS(2 * node + 1)
//累积调整次数：调整次数等于 Math.Abs(left - right)，即平衡左右子树所需的增量。
//返回路径成本：当前节点的路径成本等于自身成本 cost[node - 1] 加上左右子树的较大路径成本。   
//时间复杂度: O(n) 
//空间复杂度：O(logn) 
        public int MinIncrements(int n, int[] cost)
        {
            int res = 0;
            // 自底向上计算路径成本
            int dfsMinIncrements(int node)
            {
                // 超出节点范围
                if (node > n)
                    return 0;

                int left = dfsMinIncrements(2 * node);
                int right = dfsMinIncrements(2 * node + 1);

                res += Math.Abs(left - right);
                // 返回当前节点的总路径成本
                return cost[node - 1] + Math.Max(left, right);
            }

            dfsMinIncrements(1);
            return res;
        }