//622. Design Circular Queue med
//题意：设计你的循环队列实现。循环队列是一种线性数据结构，其中的操作基于 FIFO（先进先出）原则执行，最后一个位置与第一个位置连接起来形成一个循环。它也被称为“环形缓冲区”。
//循环队列的一个好处是，我们可以利用队列前面的空间。在普通队列中，一旦队列满了，即使队列前面有空间，我们也无法插入下一个元素。但使用循环队列，我们​​可以利用空间来存储新值。
//实现MyCircularQueue类：
//MyCircularQueue(k)使用队列的大小初始化对象k。
//int Front()从队列中获取最前面的项目。如果队列为空，则返回-1。
//int Rear()获取队列中的最后一项。如果队列为空，则返回-1。
//boolean enQueue(int value)将元素插入循环队列。true如果操作成功则返回。
//boolean deQueue()从循环队列中删除一个元素。true如果操作成功则返回。
//boolean isEmpty()检查循环队列是否为空。
//boolean isFull()检查循环队列是否已满。
//您必须在不使用编程语言中的内置队列数据结构的情况下解决问题。 
//思路：用list来存
//时间复杂度：
//空间复杂度：O(n)
        public class MyCircularQueue
        {
            int curSize = 0, size;
            List<int> data;
            public MyCircularQueue(int k)
            {
                size = k;
                data = new List<int>();
            }

            public bool EnQueue(int value)
            {
                if (curSize == size) return false;
                data.Add(value);
                curSize++;
                return true;
            }

            public bool DeQueue()
            {
                if (curSize == 0) return false;
                data.RemoveAt(0);
                curSize--;
                return true;
            }

            public int Front()
            {
                if (curSize == 0) return -1;
                return data[0];
            }

            public int Rear()
            {
                if (curSize == 0) return -1;
                return data[data.Count - 1];
            }

            public bool IsEmpty()
            {
                if (curSize == 0) return true;
                return false;
            }

            public bool IsFull()
            {
                if (size == curSize) return true;
                return false;
            }
        }

        /**
         * Your MyCircularQueue object will be instantiated and called as such:
         * MyCircularQueue obj = new MyCircularQueue(k);
         * bool param_1 = obj.EnQueue(value);
         * bool param_2 = obj.DeQueue();
         * int param_3 = obj.Front();
         * int param_4 = obj.Rear();
         * bool param_5 = obj.IsEmpty();
         * bool param_6 = obj.IsFull();
         */