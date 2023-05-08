//346. Moving Average from Data Stream med
//MovingAverage(int size) 用窗口大小 size 初始化对象。
//double next(int val) 成员函数 next 每次调用都会往滑动窗口中添加一个整数 val ，并返回窗口中所有整数的平均值。
//思路：要把size和sum设为公共变量；
        public class MovingAverage
        {
            private Queue<int> queue;
            private int size;
            private int sum;

            public MovingAverage(int size)
            {
                queue = new Queue<int>();
                this.size = size;
                sum = 0;
            }

            public double Next(int val)
            {
                if (queue.Count == size)
                {
                    sum -= queue.Dequeue();
                }
                queue.Enqueue(val);
                sum += val;
                return (double)sum / queue.Count;
            }
        }