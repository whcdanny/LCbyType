//Leetcode 2336. Smallest Number in Infinite Set med
//题意：你有一个包含所有正整数 [1, 2, 3, 4, 5, ...] 的集合。
//实现 SmallestInfiniteSet 类：
//SmallestInfiniteSet() 初始化 SmallestInfiniteSet 对象以包含所有正整数。
//int popSmallest() 从无限集合中移除并返回最小的整数。
//void addBack(int num) 将一个正整数 num 添加回无限集合中，如果它尚未在无限集合中。
//思路：PriorityQueue 看code        
//时间复杂度: initialize O(1), enqueue/dequeue O(log(n))
//空间复杂度：O(1) 
        public class SmallestInfiniteSet
        {
            private SortedDictionary<int, bool> list;
            private PriorityQueue<int, int> pq;

            public SmallestInfiniteSet()
            {
                list = new SortedDictionary<int, bool>();
                pq = new PriorityQueue<int, int>();

                for (int i = 1; i <= 1000; i++)
                {
                    pq.Enqueue(i, i);
                    list.Add(i, false);
                }
            }

            public int PopSmallest()
            {
                var val = pq.Dequeue();
                list[val] = true;
                return val;
            }

            public void AddBack(int num)
            {
                if (list[num])
                {
                    list[num] = false;
                    pq.Enqueue(num, num);
                }
            }
        }

        /**
         * Your SmallestInfiniteSet object will be instantiated and called as such:
         * SmallestInfiniteSet obj = new SmallestInfiniteSet();
         * int param_1 = obj.PopSmallest();
         * obj.AddBack(num);
         */