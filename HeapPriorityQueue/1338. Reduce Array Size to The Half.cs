//Leetcode 1338. Reduce Array Size to The Half med
//题意：给定一个整数数组 arr，你可以选择一组整数并移除数组中所有这些整数的出现。要求返回移除的整数集合的最小大小，使得至少一半的整数被移除。
//思路：PriorityQueue, 先算出数字出现的个数，然后pq从大到小排序arr中的出现的个数      
//时间复杂度: O(nlogn)
//空间复杂度：O(n)
        public int MinSetSize(int[] arr)
        {
            var dict = new Dictionary<int, int>();

            foreach (var item in arr)
            {
                dict.TryAdd(item, 0);
                dict[item]++;
            }

            var pq = new PriorityQueue<int, int>();

            foreach (var item in dict.Values)
            {
                pq.Enqueue(item, -item);
            }

            var size = arr.Length / 2;

            var currentCount = 0;
            var result = 0;

            while (pq.Count != 0 && currentCount < size)
            {
                var current = pq.Dequeue();
                currentCount += current;
                result++;
            }

            return result;
        }
        //思路：我们需要统计数组中每个整数的出现次数，并按照出现次数从大到小进行排序。
        //然后，我们从出现次数最多的整数开始移除，直到移除的整数数量达到数组长度的一半。
        //最后，返回移除的整数集合的大小。    
        //时间复杂度: O(nlogn)
        //空间复杂度：O(n)
        public int MinSetSize1(int[] arr)
        {
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                if (!freqMap.ContainsKey(num))
                {
                    freqMap[num] = 1;
                }
                else
                {
                    freqMap[num]++;
                }
            }

            List<int> freqList = freqMap.Values.ToList();
            freqList.Sort((a, b) => b - a);

            int count = 0, removed = 0;
            foreach (int freq in freqList)
            {
                count++;
                removed += freq;
                if (removed >= arr.Length / 2)
                {
                    break;
                }
            }

            return count;
        }