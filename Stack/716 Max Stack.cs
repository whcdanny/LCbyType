//Leetcode 716 Max Stack med
/*push(x)：将元素 x 压入栈中。
pop()：移除栈顶元素。
top()：获取栈顶元素。
peekMax()：检索并返回栈中最大元素。
popMax()：检索并返回栈中最大元素，并将其移除。如果有多个最大元素，只要移除其中任意一个即可。
*/
//思路：两个stack，一个是普通的用于存储元素，另一个是maxStack存储当前栈中的最大值，这样保证maxStack的最上面总是当前最大的数；
//在 PopMax()中需要更新maxstack另外，还实现了获取栈中最大值的方法 GetMax()，以及弹出栈中最大值的方法 PopMax()。在 PopMax() 中，首先弹出最大值栈的栈顶元素，并且在普通栈中寻找到最大值的位置，将最大值之前的元素暂存到一个 buffer 栈中，然后再将 buffer 中的元素重新压回普通栈中。
//时间复杂度：push、pop、top、peekMax 和 popMax 操作的时间复杂度都是 O(1)。
//空间复杂度：n 是栈的元素数量O(n)
        public class MaxStack
        {
            private Stack<int> stack;
            private Stack<int> maxStack;

            public MaxStack()
            {
                stack = new Stack<int>();
                maxStack = new Stack<int>();
            }

            public void Push(int x)
            {
                stack.Push(x);
                if (maxStack.Count == 0 || x >= maxStack.Peek())
                {
                    maxStack.Push(x);
                }
            }

            public int Pop()
            {
                int x = stack.Pop();
                if (x == maxStack.Peek())
                {
                    maxStack.Pop();
                }
                return x;
            }

            public int Top()
            {
                return stack.Peek();
            }

            public int GetMax()
            {
                return maxStack.Peek();
            }

            public int PopMax()
            {
                int max = maxStack.Pop();
                Stack<int> buffer = new Stack<int>();
                while (stack.Peek() != max)
                {
                    buffer.Push(stack.Pop());
                }
                stack.Pop();
                while (buffer.Count > 0)
                {
                    Push(buffer.Pop());
                }
                return max;
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