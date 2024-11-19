//Leetcode 1054. Distant Barcodes med
//题意：在一个仓库中，有一排条形码，其中第 i 个条形码是 barcodes[i]。
//重新排列这些条形码，使得相邻的条形码不相等。你可以返回任何一个符合条件的答案，题目保证答案存在。
//思路：PriorityQueue, 统计每个条形码的出现次数，并将其存储到字典中。
//使用优先队列（最大堆）来按照条形码的出现次数进行排序。
//从出现次数最多的条形码开始，依次将其放入结果数组的奇数索引位置，直到用完该条形码或者结果数组已经填满。
//然后再从次多的条形码开始，依次将其放入结果数组的偶数索引位置，直到用完该条形码或者结果数组已经填满。
//最后返回结果数组。
//时间复杂度: 遍历一次条形码数组并统计频次的时间复杂度为 O(n)，构建优先队列的时间复杂度为 O(nlogn)，遍历一次优先队列并将条形码放入结果数组的时间复杂度为 O(nlogn)，总的时间复杂度为 O(nlogn)。
//空间复杂度：O(n)
        public int[] RearrangeBarcodes(int[] barcodes)
        {
            //存一个每个数字的数量；
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0; i < barcodes.Length; i++)
            {
                if (!freq.ContainsKey(barcodes[i])) 
                    freq.Add(barcodes[i], 0);
                freq[barcodes[i]]++;
            }
            //存入每个数字和相对应的个数；
            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
            foreach (var kv in freq)
                pq.Enqueue(new int[] { kv.Key, kv.Value }, -kv.Value);

            int[] res = new int[barcodes.Length];
            int[] prev = new int[2] { 0, 0 };
            for (int i = 0; i < res.Length; i++)
            {                
                var elem = pq.Dequeue();
                res[i] = elem[0];
                //add prev val in queue
                if (prev[1] > 0)
                {
                    pq.Enqueue(new int[] { prev[0], prev[1] }, -prev[1]);
                    prev[1] = 0;
                }
                //update prev
                if (elem[1] > 1)
                {
                    prev[0] = elem[0];
                    prev[1] = elem[1] - 1;
                }
            }
            return res;
        }