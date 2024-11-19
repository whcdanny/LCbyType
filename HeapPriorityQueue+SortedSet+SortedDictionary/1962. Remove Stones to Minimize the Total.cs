//Leetcode 1962. Remove Stones to Minimize the Total med
//题意：给定一个数组 piles，表示每个堆中的石头数量，以及一个整数 k。要求执行以下操作 k 次：
//每次选择一个堆 piles[i]，并从中移除 floor(piles[i] / 2) 个石头。
//注意，可以对同一个堆多次执行操作。
//返回执行 k 次操作后剩余石头的最小总数。
//其中 floor(x) 表示不大于 x 的最大整数。
//思路：PriorityQueue 每一次用pq输出当前最大的 然后/2，直到执行了k次；
//时间复杂度: O(klogn)
//空间复杂度：O(1)          
        public int MinStoneSum(int[] piles, int k)
        {
            int sum = piles.Sum();
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            for (int i = 0; i < piles.Length; i++)
            {
                pq.Enqueue(piles[i],  -piles[i]);
            }
            for (int i = 0; i < k; i++)
            {
                int sub = pq.Peek() / 2;
                sum -= sub;
                int addBack = pq.Dequeue();
                pq.Enqueue(addBack - sub,  -(addBack - sub));
            }
            return sum;
        }