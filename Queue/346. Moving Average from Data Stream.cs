//Leetcode 346. Moving Average from Data Stream med
//MovingAverage(int size) 用窗口大小 size 初始化对象。
//double next(int val) 成员函数 next 每次调用都会往滑动窗口中添加一个整数 val ，并返回窗口中所有整数的平均值。
//思路：我们可以使用一个队列来存储窗口内的元素，并使用一个变量来记录窗口的大小。每次有新的元素进来时，我们将其添加到队列尾部，并将队列头部超出窗口大小的元素移除。然后，计算当前窗口内所有元素的平均值。
//时间复杂度：添加新元素：O(1), 计算移动平均值：O(1)
//空间复杂度：n是窗口大小, O(n)
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