//Leetcode 281. Zigzag Iterator med
//题意：给定两个整数数组 nums1 和 nums2，以及一个标志值 flag 表示两个数组之间的遍历顺序，如果 flag 为 true，则以如下顺序遍历：nums1 的第一个元素，nums2 的第一个元素，nums1 的第二个元素，nums2 的第二个元素，依此类推；如果 flag 为 false，则以如下顺序遍历：nums2 的第一个元素，nums1 的第一个元素，nums2 的第二个元素，nums1 的第二个元素，依此类推。编写一个迭代器，要求能够实现该遍历顺序。
//思路：两个队列来存储输入数组 v1 和 v2。在 HasNext 方法中，判断两个队列是否都为空，如果都为空则返回 false，否则返回 true。在 Next 方法中，首先判断是否有下一个元素（调用 HasNext 方法）。然后交替从两个队列中取出元素，返回一个队列中的队首元素，并将其重新放入队列的队尾，以保持交替迭代的顺序。
//时间复杂度：初始化迭代器：O(m + n)，其中 m 和 n 分别是两个输入数组的长度。每次调用 HasNext 方法：O(1)。每次调用 Next 方法：O(1)。
//空间复杂度：O(m + n)，其中 m 和 n 分别是两个输入数组的长度。
        public class ZigzagIterator
        {
            private Queue<int> queue1;
            private Queue<int> queue2;

            public ZigzagIterator(int[] v1, int[] v2)
            {
                queue1 = new Queue<int>(v1);
                queue2 = new Queue<int>(v2);
            }

            public bool HasNext()
            {
                return queue1.Count > 0 || queue2.Count > 0;
            }

            public int Next()
            {
                if (queue1.Count > 0)
                {
                    int val = queue1.Dequeue();
                    queue2.Enqueue(val);
                    return val;
                }
                else
                {
                    int val = queue2.Dequeue();
                    queue1.Enqueue(val);
                    return val;
                }
            }
        }
        public class ZigzagIterator_1
        {
            private Queue<int> queue;
            private Queue<int> index;
            private IList<int> v1;
            private IList<int> v2;

            public ZigzagIterator_1(IList<int> v1, IList<int> v2)
            {
                queue = new Queue<int>();
                index = new Queue<int>();
                this.v1 = v1;
                this.v2 = v2;

                if (v1.Count > 0)
                {
                    queue.Enqueue(v1[0]);
                    index.Enqueue(0);
                }

                if (v2.Count > 0)
                {
                    queue.Enqueue(v2[0]);
                    index.Enqueue(1);
                }
            }

            public bool HasNext()
            {
                return queue.Count > 0;
            }

            public int Next()
            {
                int val = queue.Dequeue();
                int idx = index.Dequeue();

                if (idx == 0 && queue.Count < v1.Count)
                {
                    queue.Enqueue(v1[queue.Count]);
                    index.Enqueue(0);
                }
                else if (idx == 1 && queue.Count < v1.Count + v2.Count - 1)
                {
                    queue.Enqueue(v2[queue.Count - v1.Count]);
                    index.Enqueue(1);
                }

                return val;
            }
        }