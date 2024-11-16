//Leetcode 692. Top K Frequent Words med
//题意：给定一个非空的字符串列表，返回其中出现频率前 k 高的单词
//思路：使用一个字典 wordFreq 来统计每个单词的出现频率。创建一个最小堆 minHeap，将单词按照出现频率放入堆中。遍历 wordFreq 中的每个单词，将其放入堆中，如果堆的大小超过 k，则将堆顶的元素（出现频率最小的单词）弹出。
//时间复杂度：统计单词频率的时间复杂度是 O(n)，其中 n 是单词的总数。将单词放入最小堆的时间复杂度是 O(n* log k)。总的时间复杂度是 O(n + n* log k)，近似于 O(n* log k)。
//空间复杂度：使用了一个字典 wordFreq 来存储单词频率，空间复杂度是 O(n)。使用了一个最小堆来存储单词，空间复杂度是 O(k)。总的来说，这个解法的时间复杂度是 O(n* log k)，空间复杂度是 O(n + k)
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> wordFreq = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (!wordFreq.ContainsKey(word))
                {
                    wordFreq[word] = 0;
                }
                wordFreq[word]++;
            }

            PriorityQueue<string> minHeap = new PriorityQueue<string>((a, b) => {
                if (wordFreq[a] == wordFreq[b])
                {
                    return string.Compare(b, a); // 如果频率相同，按字母顺序降序排序
                }
                return wordFreq[a] - wordFreq[b]; // 按频率升序排序
            });

            foreach (string word in wordFreq.Keys)
            {
                minHeap.Enqueue(word);
                if (minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }

            List<string> result = new List<string>();
            while (minHeap.Count > 0)
            {
                result.Insert(0, minHeap.Dequeue()); // 逆序插入结果列表
            }

            return result;
        }
		public class PriorityQueue<T>
        {
            //在最小堆（Min-Heap）中，每个节点的父节点和子节点的索引有一个特定的关系。
            //假设一个节点的索引是 i，那么它的父节点的索引是(i-1)/2，它的左子节点的索引是 2*i + 1，右子节点的索引是 2*i + 2。
            public List<T> heap;
            private Comparison<T> comparison;

            public int Count
            {
                get { return heap.Count; }
            }
            //public PriorityQueue()
            //{
            //    this.heap = new List<T>();
            //    this.comparison = 
            //}

            public PriorityQueue(Comparison<T> comparison)
            {
                this.heap = new List<T>();
                this.comparison = comparison;
            }

            public void Enqueue(T item)
            {
                heap.Add(item);
                int childIndex = heap.Count - 1;
                while (childIndex > 0)
                {
                    //计算当前子节点的父节点索引
                    int parentIndex = (childIndex - 1) / 2;
                    if (comparison(heap[parentIndex], heap[childIndex]) <= 0)
                        break;

                    Swap(parentIndex, childIndex);
                    childIndex = parentIndex;
                }
            }

            public T Dequeue()
            {
                int lastIndex = heap.Count - 1;
                T frontItem = heap[0];
                heap[0] = heap[lastIndex];
                heap.RemoveAt(lastIndex);

                lastIndex--;
                int parentIndex = 0;

                while (true)
                {
                    int leftChildIndex = parentIndex * 2 + 1;
                    if (leftChildIndex > lastIndex)
                        break;

                    int rightChildIndex = leftChildIndex + 1;
                    int minIndex = leftChildIndex;

                    if (rightChildIndex <= lastIndex && comparison(heap[rightChildIndex], heap[leftChildIndex]) < 0)
                        minIndex = rightChildIndex;

                    if (comparison(heap[parentIndex], heap[minIndex]) <= 0)
                        break;

                    Swap(parentIndex, minIndex);
                    parentIndex = minIndex;
                }

                return frontItem;
            }

            public T Peek()
            {
                return heap[0];
            }

            private void Swap(int i, int j)
            {
                T temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }
        }
		
		
		//692. Top K Frequent Words med 
        //题目要求从给定的字符串列表中找出出现频率前 k 高的单词，并按照频率从高到低、字母顺序从小到大的顺序返回结果
        //思路：Dictionary 统计每个单词的出现频率，SortedDictionary 将单词按照频率分组存储，高频率到低频率的顺序遍历 SortedDictionary，并按照字母顺序取出每个频率对应的单词
        public IList<string> TopKFrequent1(string[] words, int k)
        {
            Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

            // 统计每个单词的出现频率
            foreach (string word in words)
            {
                if (frequencyMap.ContainsKey(word))
                {
                    frequencyMap[word]++;
                }
                else
                {
                    frequencyMap[word] = 1;
                }
            }

            SortedDictionary<int, List<string>> sortedDict = new SortedDictionary<int, List<string>>();

            // 将单词按照频率分组存入 SortedDictionary
            foreach (var pair in frequencyMap)
            {
                string word = pair.Key;
                int frequency = pair.Value;

                if (sortedDict.ContainsKey(frequency))
                {
                    sortedDict[frequency].Add(word);
                }
                else
                {
                    sortedDict[frequency] = new List<string> { word };
                }
            }

            List<string> result = new List<string>();

            // 从高频率到低频率遍历 SortedDictionary，按照字母顺序取前 k 个单词
            foreach (var pair in sortedDict.Reverse())
            {
                List<string> wordsWithSameFrequency = pair.Value;
                wordsWithSameFrequency.Sort(); // 按照字母顺序排序

                foreach (string word in wordsWithSameFrequency)
                {
                    result.Add(word);
                    if (result.Count == k)
                    {
                        return result;
                    }
                }
            }

            return result;
        }