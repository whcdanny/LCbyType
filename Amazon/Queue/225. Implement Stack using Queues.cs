//225. Implement Stack using Queues med
//C#使用队列实现栈的下列操作：
//push(x) -- 元素 x 入栈
//pop() -- 移除栈顶元素
//top() -- 获取栈顶元素
//empty() -- 返回栈是否为空
//思路：定义两个队列 queue 和 queue_top，分别表示栈和临时队列，当push的时候，先把value放入quese，然后把queue_top放入（放入并删除）queue，然后再把queue的放入（放入并删除）queue_top；
//时间复杂度：push操作：O(1)。pop操作：O(n)，其中n是栈中的元素个数。top操作：O(n)，其中n是栈中的元素个数。empty操作：O(1)。
//空间复杂度：n是栈中的元素个数, O(n)
        /**
         * Your MyQueue object will be instantiated and called as such:
         * MyQueue obj = new MyQueue();
         * obj.Push(x);
         * int param_2 = obj.Pop();
         * int param_3 = obj.Peek();
         * bool param_4 = obj.Empty();
         */
        public class MyStack
        {
            private Queue<int> queue;
            private Queue<int> queue_top;

            /** Initialize your data structure here. */
            public MyStack()
            {
                queue = new Queue<int>();
                queue_top = new Queue<int>();
            }

            /** Push element x onto stack. */
            public void Push(int x)
            {
                queue.Enqueue(x);
                while (queue_top.Count != 0)
                {
                    queue.Enqueue(queue_top.Dequeue());
                }
                while (queue.Count != 0)
                {
                    queue_top.Enqueue(queue.Dequeue());
                }
            }

            /** Removes the element on top of the stack and returns that element. */
            public int Pop()
            {
                int res = queue_top.Dequeue();
                if (res != 0)
                    return res;
                return -1;
            }

            /** Get the top element. */
            public int Top()
            {
                return queue_top.Peek();
            }

            /** Returns whether the stack is empty. */
            public bool Empty()
            {
                return queue_top.Count == 0;
            }
        }