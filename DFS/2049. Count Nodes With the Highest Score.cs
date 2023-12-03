//Leetcode 2049. Count Nodes With the Highest Score med
//题意：一个关于二叉树的问题，每个节点都有一个得分，得分的计算规则是移除节点及其连接边后，树将分裂为一个或多个非空子树，得分是这些子树大小的乘积，然后找出出现最大乘积的数量；
//思路：DFS, 找到每个node的连接的左右两个点，如果没有就是-1；这是如果是最边缘的点，left和right就会是0；那么就要改成1；如果发现剩余的node数为0，也就是我们刚好算到root，那么也要改成1；
//注：这里重点是构图
//时间复杂度:  O(N)，其中 N 是节点的数量
//空间复杂度： O(N)，其中 N 是节点的数量
        Dictionary<int, int[]> children_CountHighestScoreNodes = new Dictionary<int, int[]>();
        long maxScore_CountHighestScoreNodes = 0;
        int result_CountHighestScoreNodes = 0;
        public int CountHighestScoreNodes(int[] parents)
        {

            int n = parents.Length;
            
            //找到每个node的连接的左右两个点，如果没有就是-1；
            for (int i = 0; i < parents.Length; i++)
            {
                int[] arr = new int[2] { -1, -1 };
                if (children_CountHighestScoreNodes.ContainsKey(parents[i]))
                {
                    children_CountHighestScoreNodes[parents[i]][1] = i;
                }
                else
                {
                    arr[0] = i;
                    children_CountHighestScoreNodes.Add(parents[i], arr);
                }
            }

            for (int i = 0; i < parents.Length; i++)
            {
                int[] arr = new int[2] { -1, -1 };
                if (!children_CountHighestScoreNodes.ContainsKey(i))
                {
                    children_CountHighestScoreNodes.Add(i, arr);
                }
            }

            CountNodes(0, n);
            return result_CountHighestScoreNodes;
        }
        public long CountNodes(int root, int n)
        {
            long score = 0;
            long subtreeCount = 0;

            if (root == -1)
            {
                return 0;
            }

            long leftCount = CountNodes(children_CountHighestScoreNodes[root][0], n);
            long rightCount = CountNodes(children_CountHighestScoreNodes[root][1], n);
            subtreeCount = leftCount + rightCount + 1;
            //得到剩余的node；
            long remCount = n - subtreeCount;

            //这是如果是最边缘的点，left和right就会是0；那么就要改成1；
            score = (leftCount == 0 ? 1 : leftCount) * (rightCount == 0 ? 1 : rightCount);
            //如果发现剩余的node数为0，也就是我们刚好算到root，那么也要改成1；
            score *= remCount == 0 ? 1 : remCount;

            //找出最大值，并更新res为1；
            if (score > maxScore_CountHighestScoreNodes)
            {
                maxScore_CountHighestScoreNodes = score;
                result_CountHighestScoreNodes = 1;
            }            
            else if (score == maxScore_CountHighestScoreNodes)
            {
                result_CountHighestScoreNodes++;
            }
            return subtreeCount;
        }
