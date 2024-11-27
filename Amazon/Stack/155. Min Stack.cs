//155. Min Stack med
//题意：根据要求写一个Min Stack
/*
MinStack() initializes the stack object.
void push(int val) pushes the element val onto the stack.
void pop() removes the element on the top of the stack.
int top() gets the top element of the stack.
int getMin() retrieves the minimum element in the stack.*/
//思路：给两个stack一个存每一个数，一个只存每个时刻的最小值，这样保证minStack的最上面总是当前最小的数；
//时间复杂度：push、pop、top 和 getMin 操作的时间复杂度都是 O(1)。
//空间复杂度：O(n)
        public class MinStack
        {

            /** initialize your data structure here. */
            Stack<int> stack = new Stack<int>();
            Stack<int> minStack = new Stack<int>();

            public MinStack()
            {

            }

            public void Push(int x)
            {
                stack.Push(x);
                if (minStack.Count == 0 || x <= GetMin())
                    minStack.Push(x);
            }

            public void Pop()
            {
                if (stack.Count == 0)
                    return;
                int x = stack.Pop();
                if (x == minStack.Peek())
                    minStack.Pop();
            }

            public int Top()
            {
                return stack.Peek();
            }

            public int GetMin()
            {
                return minStack.Peek();
            }
        }

        /**
         * Your MinStack object will be instantiated and called as such:
         * MinStack obj = new MinStack();
         * obj.Push(x);
         * obj.Pop();
         * int param_3 = obj.Top();
         * int param_4 = obj.GetMin();
         */