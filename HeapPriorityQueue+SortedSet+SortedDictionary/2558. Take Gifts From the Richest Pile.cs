//Leetcode 2558. Take Gifts From the Richest Pile ez
//题意：给定一个整数数组 gifts，表示不同礼物堆中的礼物数量。每秒钟，你执行以下操作：
//选择具有最大礼物数量的堆。
//如果有多个堆具有最大礼物数量，则选择任意一个。
//留下堆中礼物数量的平方根的地板部分，取剩下的礼物。
//返回经过 k 秒后剩余的礼物数量。
//思路：PriorityQueue维护一个优先队列（最大堆），每次选择礼物最多的堆。
//每秒钟从堆中取出剩余礼物数量的平方根的地板部分，然后将剩余礼物数量更新为剩下的礼物数量减去这个地板部分。
//重复以上步骤 k 次，最后返回剩余礼物数量的总和。
//时间复杂度: O(klogn)，其中 n 是礼物堆的数量
//空间复杂度：O(n)       
        public long PickGifts(int[] gifts, int k)
        {
            var pq = new PriorityQueue<long, long>();
            foreach (var gift in gifts)
                pq.Enqueue(gift, -gift);

            long sum = 0;
            while (k != 0)
            {
                var root = (long)Math.Sqrt(pq.Dequeue());
                pq.Enqueue(root, -root);
                k--;
            }

            while (pq.Count != 0)
                sum += pq.Dequeue();

            return sum;
        }