//232. Implement Queue using Stacks ez
/*void push(int x) Pushes element x to the back of the queue.
int pop() Removes the element from the front of the queue and returns it.
int peek() Returns the element at the front of the queue.
boolean empty() Returns true if the queue is empty, false otherwise.*/
//思路：用两个stack来实现queue
    public class MyQueue
    {
        Stack<int> s1;
        Stack<int> s2;
        /** Initialize your data structure here. */
        public MyQueue()
        {
            s1 = new Stack<int>();
            s2 = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            while (s1.Count != 0)
            {
                s2.Push(s1.Pop());
            }
            s1.Push(x);
            while (s2.Count != 0)
            {
                s1.Push(s2.Pop());
            }
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            return s1.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            return s1.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return (s1.Count == 0);
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */