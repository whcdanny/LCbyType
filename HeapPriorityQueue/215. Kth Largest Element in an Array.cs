//Leetcode 215. Kth Largest Element in an Array med
//题意: 找出所给的乱序数组中 倒数第k个大的；
//思路：PriorityQueue. 按从小到大排序，然后找到第k个
//时间复杂度: N + k *log k
//空间复杂度：O(k)   
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

            foreach (var num in nums)
            {
                minHeap.Enqueue(num, num); 
                
                if (minHeap.Count > k)
                    minHeap.Dequeue();
            }
            
            return minHeap.Peek();
        }