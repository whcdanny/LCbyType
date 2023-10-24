//Leetcode 232. Implement Queue using Stacks ez
/*void push(int x) Pushes element x to the back of the queue.
int pop() Removes the element from the front of the queue and returns it.
int peek() Returns the element at the front of the queue.
boolean empty() Returns true if the queue is empty, false otherwise.*/
//思路：要使用栈来实现队列，我们需要两个栈，一个用于入队操作，一个用于出队操作
//时间复杂度：push 操作的时间复杂度是 O(1)。pop、peek、empty 操作的平均时间复杂度是 O(1)。
//空间复杂度：n 是栈的元素数量，O(n)
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