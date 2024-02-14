//Leetcode 2335. Minimum Amount of Time to Fill Cups med
//题意：你有一个水机，可以供应冷水、温水和热水。每秒钟，你可以选择以下两种操作之一：
//用不同类型的水装满 2 杯。
//用任意类型的水装满 1 杯。
//给定一个长度为 3 的整数数组 amount，其中 amount[0]、amount[1] 和 amount[2] 分别表示你需要装满的冷水杯数、温水杯数和热水杯数。返回装满所有杯子所需的最少秒数。
//思路：PriorityQueue 存入 amount[0]、amount[1] 和 amount[2] 分别表示你需要装满的冷水杯数、温水杯数和热水杯数
//每一次Dequeue最小的两杯水，然后如果不为0，那么就是-1，t+1；
//时间复杂度: O(nlogn)
//空间复杂度：O(1) 
        public int FillCups(int[] amount)
        {
            var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));

            pq.Enqueue(amount[0], amount[0]);
            pq.Enqueue(amount[1], amount[1]);
            pq.Enqueue(amount[2], amount[2]);

            var t = 0;

            while (pq.Peek() != 0)
            {
                var max1 = pq.Dequeue();
                var max2 = pq.Dequeue();

                if (max1 != 0)
                {
                    max1--;
                }
                pq.Enqueue(max1, max1);

                if (max2 != 0)
                {
                    max2--;
                }
                pq.Enqueue(max2, max2);
                t++;
            }

            return t;
        }