//Leetcode 362. Design Hit Counter mid
//设计一个计数器，能够记录在过去的5分钟内（300秒）被点击的次数，并能够返回过去5分钟内的总点击数。
//hit(int timestamp)： 记录一个在timestamp（以秒为单位）时间戳被点击的事件。
//getHits(int timestamp)：返回过去5分钟内（包括timestamp）的点击数（即在[t - 300, t] 范围内的点击次数，其中t表示当前时间戳）。
//思路：队列来保存击中事件的时间戳，队列中的元素按照时间顺序排列。在 hit 操作中，将当前时间戳加入队列，并移除所有超过5分钟的时间戳。在 getHits 操作中，遍历队列，统计在过去5分钟内的击中次数
//时间复杂度：hit 操作：O(n)，其中 n 是队列中的元素数量，最坏情况下可能需要遍历整个队列。getHits 操作：O(n)，其中 n 是队列中的元素数量。
//空间复杂度：O(timestamps)，其中 timestamps 是所有击中事件的数量

        private Queue<int> hits;

        public void HitCounter()
        {
            hits = new Queue<int>();
        }

        public void Hit(int timestamp)
        {
            hits.Enqueue(timestamp);
        }

        public int GetHits(int timestamp)
        {
            while (hits.Count > 0 && timestamp - hits.Peek() >= 300)
            {
                hits.Dequeue();
            }
            return hits.Count;
        }