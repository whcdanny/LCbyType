//362. Design Hit Counter mid
//设计一个计数器，能够记录在过去的5分钟内（300秒）被点击的次数，并能够返回过去5分钟内的总点击数。
//hit(int timestamp)： 记录一个在timestamp（以秒为单位）时间戳被点击的事件。
//getHits(int timestamp)：返回过去5分钟内（包括timestamp）的点击数（即在[t - 300, t] 范围内的点击次数，其中t表示当前时间戳）。
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