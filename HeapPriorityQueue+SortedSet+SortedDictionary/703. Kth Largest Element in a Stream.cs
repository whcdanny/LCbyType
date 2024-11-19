//Leetcode 703. Kth Largest Element in a Stream ez
//题意：设计一个类来找到数据流中第 k 大的元素。注意，这里的第 k 大元素是按照排序顺序来计算的，并不是第 k 个不同的元素。
//实现 KthLargest 类：
//KthLargest(int k, int[] nums) 使用整数 k 和整数数组 nums 初始化对象。
//int add(int val) 将整数 val 添加到数据流中，并返回表示数据流中第 k 大元素的元素。
//思路：PriorityQueue, 前 k 个最大的元素。当新元素加入数据流时，我们将其与堆顶元素比较，如果大于堆顶元素，则将堆顶元素弹出，并将新元素加入堆中。这样，堆顶元素就是数据流中的第 k 大元素。
//时间复杂度: 初始化时，构建堆的时间复杂度为 O(klogk)，add 操作的时间复杂度为 O(logk)
//空间复杂度：O(k)       
        public class KthLargest
        {            
            PriorityQueue<int, int> pq;
            
            int k;

            public KthLargest(int k, int[] nums)
            {
                this.k = k;
                pq = new PriorityQueue<int, int>();

                foreach (int num in nums)
                {
                    Add(num);
                }
            }

            public int Add(int val)
            {                
                pq.Enqueue(val, val);
                
                while (pq.Count > k)
                {
                    pq.Dequeue();
                }

                return pq.Peek();
            }
        }