//Leetcode 2349. Design a Number Container System med
//题意：设计一个数字容器系统，该系统可以执行以下操作：
//在给定索引处插入或替换一个数字。
//返回系统中给定数字的最小索引。
//实现 NumberContainers 类：
//NumberContainers()：初始化数字容器系统。
//void change(int index, int number)：在索引 index 处填充数字 number。如果该索引处已有数字，则替换它。
//int find(int number)：返回给定数字的最小索引，如果系统中没有由 number 填充的索引，则返回 -1。
//思路：PriorityQueue 看code        
//时间复杂度: 初始化：O(1)，没有任何操作。插入或替换数字：O(logn)，在最小堆中插入或替换元素。查找最小索引：O(1)，直接从最小堆中取出元素。
//空间复杂度：O(n) 
        public class NumberContainers
        {
            //private readonly Dictionary<int, SortedSet<int>> n2i;
            Dictionary<int, PriorityQueue<int, int>> hash_number;
            //private readonly Dictionary<int, int> i2n;
            Dictionary<int, int> hash_index;

            public NumberContainers()
            {
                hash_number = new Dictionary<int, PriorityQueue<int, int>>();
                hash_index = new Dictionary<int, int>();
                //i2n = new Dictionary<int, int>();
                //n2i = new Dictionary<int, SortedSet<int>>();
            }

            public void Change(int index, int number)
            {
                if (hash_index.ContainsKey(index) == false)
                {
                    hash_index.Add(index, number);
                }
                else
                {
                    hash_index[index] = number;
                }

                if (hash_number.ContainsKey(number) == false)
                {
                    hash_number.Add(number, new PriorityQueue<int, int>());
                }
                hash_number[number].Enqueue(index, index);
                //if (i2n.ContainsKey(index))
                //{
                //    var oldNumber = i2n[index];
                //    n2i[oldNumber].Remove(index);
                //    i2n[index] = number;
                //}
                //else
                //{
                //    i2n.Add(index, number);
                //}

                //if (!n2i.ContainsKey(number))
                //{
                //    var s = new SortedSet<int>();
                //    n2i.Add(number, s);
                //}

                //n2i[number].Add(index);               
            }

            public int Find(int number)
            {
                if (hash_number.ContainsKey(number) == false) return -1;

                var pq = hash_number[number];

                int result = -1;
                while (pq.Count > 0)
                {
                    result = pq.Peek();

                    if (number == hash_index[result])
                    {
                        break;
                    }
                    else
                    {
                        result = -1;
                        pq.Dequeue();
                    }
                }

                return result;
                // n2i.ContainsKey(number) && n2i[number].Count > 0 ? n2i[number].Min : -1;
            }
        }

        /**
         * Your NumberContainers object will be instantiated and called as such:
         * NumberContainers obj = new NumberContainers();
         * obj.Change(index,number);
         * int param_2 = obj.Find(number);
         */