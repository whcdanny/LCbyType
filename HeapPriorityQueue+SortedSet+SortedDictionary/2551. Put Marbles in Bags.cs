//Leetcode 2551. Put Marbles in Bags hard
//题意：你有 k 个袋子。给定一个整数数组 weights，其中 weights[i] 表示第 i 个弹珠的重量。同时给定一个整数 k。
//按照以下规则将弹珠分配到 k 个袋子中：
//每个袋子都不能是空的。
//如果第 i 个弹珠和第 j 个弹珠在同一个袋子中，那么所有索引在第 i 和第 j 之间的弹珠也必须在同一个袋子中。
//如果一个袋子包含了索引从 i 到 j（包括 i 和 j）的所有弹珠，则该袋子的成本为 weights[i] + weights[j]。
//分配弹珠后的得分是所有 k 个袋子的成本之和。
//返回弹珠分布中最大得分和最小得分之间的差值。
//思路：PriorityQueue
//[xx][xxx][x] 相当于 第一个和最后一个肯定会被选中，然后会发现每个x][x 也都会被选中，
//看似想插板，一共插入k-1个板子，这样就是看weights[i] + weights[i + 1]最大和最小
//时间复杂度: O(n)
//空间复杂度：O(k)       
        public long PutMarbles1(int[] weights, int k)
        {
            PriorityQueue<int, int> max = new PriorityQueue<int, int>();
            PriorityQueue<int, int> min = new PriorityQueue<int, int>();

            for (int i = 0; i < weights.Length - 1; i++)
            {
                int sum = weights[i] + weights[i + 1];
                max.Enqueue(sum, -sum);
                min.Enqueue(sum, sum);
            }

            long maxSum = 0;
            long minSum = 0;

            for (int i = 0; i < k - 1; i++)
            {
                maxSum += max.Dequeue();
                minSum += min.Dequeue();
            }

            return maxSum - minSum;
        }
        public long PutMarbles(int[] weights, int k)
        {
            int n = weights.Length;
            if (n == 1) return 0;

            List<long> arr = new List<long>();
            for (int i = 0; i < n - 1; i++)
            {
                arr.Add(weights[i] + weights[i + 1]);
            }

            arr.Sort();

            long ret = 0;
            for (int i = 0; i < k - 1; i++)
            {
                ret += arr[arr.Count - 1 - i];
            }

            for (int i = 0; i < k - 1; i++)
            {
                ret -= arr[i];
            }

            return ret;
        }