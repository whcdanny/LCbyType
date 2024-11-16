//Leetcode 1172. Dinner Plate Stacks hard
//题意：实现一个 DinnerPlates 类，这个类需要实现以下功能：
//DinnerPlates(int capacity)：初始化一个 DinnerPlates 对象，设置栈的最大容量为 capacity。
//void push(int val)：将整数 val 压入第一个非满栈的最左侧。
//int pop()：从最右侧的非空栈中弹出并返回栈顶的值，如果所有栈都为空，则返回 -1。
//int popAtStack(int index)：从给定索引的栈中弹出并返回栈顶的值，如果该栈为空，则返回 -1。
//思路：PriorityQueue, 看code   
//时间复杂度: Push 操作的时间复杂度为 O(n)，其中 n 是栈的数量。Pop 和 PopAtStack 操作的平均时间复杂度为 O(1)。
//空间复杂度：O(n * m)，其中 n 是栈的数量，m 是每个栈的容量
        public class DinnerPlates
        {

            private List<Stack<int>> plates;
            private int _capacity;
            private PriorityQueue<int, int> hasSpace;
            private PriorityQueue<int, int> hasValue;
            private ISet<int> deleted;
            public DinnerPlates(int capacity)
            {
                _capacity = capacity;
                plates = new List<Stack<int>>();
                hasSpace = new PriorityQueue<int, int>();
                hasValue = new PriorityQueue<int, int>();
                deleted = new HashSet<int>();
            }

            public void Push(int val)
            {
                if (hasSpace.Count == 0)
                {
                    Stack<int> stack = new Stack<int>();
                    stack.Push(val);
                    int index = plates.Count;
                    if (_capacity != 1)
                    {
                        hasSpace.Enqueue(index, index);
                    }
                    if (deleted.Contains(index))
                    {
                        deleted.Remove(index);
                    }
                    else
                    {
                        hasValue.Enqueue(index, -index);
                    }
                    plates.Add(stack);
                    return;
                }
                int min = hasSpace.Peek();
                if (plates[min].Count == 0)
                {
                    if (deleted.Contains(min))
                    {
                        deleted.Remove(min);
                    }
                    else
                    {
                        hasValue.Enqueue(min, -min);
                    }
                }
                plates[min].Push(val);
                if (plates[min].Count == _capacity)
                {
                    hasSpace.Dequeue();
                }
            }

            public int Pop()
            {
                if (hasValue.Count == deleted.Count)
                {
                    return -1;
                }
                while (deleted.Contains(hasValue.Peek()))
                {
                    deleted.Remove(hasValue.Peek());
                    hasValue.Dequeue();
                }
                int max = hasValue.Peek();
                if (plates[max].Count == _capacity)
                {
                    hasSpace.Enqueue(max, max);
                }
                int pop = plates[max].Pop();
                if (plates[max].Count == 0)
                {
                    hasValue.Dequeue();
                }
                return pop;
            }

            public int PopAtStack(int index)
            {
                if (index > plates.Count || plates[index].Count == 0)
                {
                    return -1;
                }
                if (plates[index].Count == 1)
                {
                    deleted.Add(index);
                }
                if (plates[index].Count == _capacity)
                {
                    hasSpace.Enqueue(index, index);
                    return plates[index].Pop();
                }
                return plates[index].Pop();
            }
        }

        /**
         * Your DinnerPlates object will be instantiated and called as such:
         * DinnerPlates obj = new DinnerPlates(capacity);
         * obj.Push(val);
         * int param_2 = obj.Pop();
         * int param_3 = obj.PopAtStack(index);
         */