//281. Zigzag Iterator med
//给定两个整数数组 nums1 和 nums2，以及一个标志值 flag 表示两个数组之间的遍历顺序，如果 flag 为 true，则以如下顺序遍历：nums1 的第一个元素，nums2 的第一个元素，nums1 的第二个元素，nums2 的第二个元素，依此类推；如果 flag 为 false，则以如下顺序遍历：nums2 的第一个元素，nums1 的第一个元素，nums2 的第二个元素，nums1 的第二个元素，依此类推。编写一个迭代器，要求能够实现该遍历顺序。
//思路：给一个
        public class ZigzagIterator
        {
            private Queue<int> queue;
            private Queue<int> index;
            private IList<int> v1;
            private IList<int> v2;

            public ZigzagIterator(IList<int> v1, IList<int> v2)
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