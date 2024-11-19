//Leetcode 767. Reorganize String med
//题意：给定一个字符串，要求重新排列字符串中的字符，使得任意相邻的字符都不相同。如果这种重排列方式存在，返回任意一个合法的结果。
//思路：这个问题可以通过贪心算法来解决。首先统计每个字符出现的次数，并找出出现次数最多的字符。如果最多出现的字符次数超过了字符串长度的一半，那么无法重新排列使得相邻字符不相同，返回空字符串。否则，我们可以利用最大堆（PriorityQueue）来进行重新排列。我们将字符和其出现次数放入最大堆中，并依次取出堆顶的两个字符，放入结果字符串中，然后将字符的出现次数减一，再放回堆中
//时间复杂度：统计字符出现次数的时间复杂度是 O(n)。将字符和出现次数放入最大堆的时间复杂度是 O(k* log(k))，其中 k 是字符种类的数量。重复步骤 4 的次数最多是字符串长度 n，每次操作的时间复杂度是 O(log(k))。 O(n + k*log(k))
//空间复杂度：O(k)
        public string ReorganizeString(string s)
        {
            Dictionary<char, int> charFreq = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!charFreq.ContainsKey(c))
                {
                    charFreq[c] = 0;
                }
                charFreq[c]++;
            }

            PriorityQueue<KeyValuePair<char, int>> maxHeap = new PriorityQueue<KeyValuePair<char, int>>(
                (a, b) => b.Value - a.Value
            );

            foreach (var entry in charFreq)
            {
                maxHeap.Enqueue(entry);
            }

            StringBuilder result = new StringBuilder();
            while (maxHeap.Count > 1)
            {
                var entry1 = maxHeap.Dequeue();
                var entry2 = maxHeap.Dequeue();

                result.Append(entry1.Key);
                result.Append(entry2.Key);

                if (entry1.Value > 1)
                {
                    entry1 = new KeyValuePair<char, int>(entry1.Key, entry1.Value - 1);
                    maxHeap.Enqueue(entry1);
                }

                if (entry2.Value > 1)
                {
                    entry2 = new KeyValuePair<char, int>(entry2.Key, entry2.Value - 1);
                    maxHeap.Enqueue(entry2);
                }
            }

            if (maxHeap.Count > 0)
            {
                var lastEntry = maxHeap.Dequeue();
                if (lastEntry.Value > 1)
                {
                    return "";
                }
                result.Append(lastEntry.Key);
            }

            return result.ToString();
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
        //767. Reorganize String
        //重组string，保证任何相邻的两个字母不能相同
        //思路：先用dictionary存储字母相对于的次数，按照字符出现次数进行排序，最多出现次数的字符超过字符串长度的一半加一，则无法重新组织字符串，然后填充最多的开始，每隔一个位置添加，
        public string ReorganizeString1(string s)
        {
            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            // 统计每个字符的出现次数
            foreach (char c in s)
            {
                if (!charCounts.ContainsKey(c))
                    charCounts[c] = 0;
                charCounts[c]++;
            }

            // 按照字符出现次数进行排序
            List<char> sortedChars = charCounts.Keys.ToList();
            sortedChars.Sort((a, b) => charCounts[b].CompareTo(charCounts[a]));

            // 如果最多出现次数的字符超过字符串长度的一半加一，则无法重新组织字符串
            if (charCounts[sortedChars[0]] > (s.Length + 1) / 2)
                return "";

            char[] result = new char[s.Length];
            int index = 0;

            // 先填充出现次数最多的字符
            foreach (char c in sortedChars)
            {
                int count = charCounts[c];

                while (count > 0)
                {
                    result[index] = c;
                    index += 2; // 每隔一个位置填充字符
                    if (index >= s.Length) // 超过字符串长度时回到第二个位置
                        index = 1;

                    count--;
                }
            }

            // 填充剩余的字符
            foreach (char c in sortedChars)
            {
                while (charCounts[c] > 0 && index < s.Length)
                {
                    if (result[index] == '\0')
                    {
                        result[index] = c;
                        index += 2;
                    }
                    if (index >= s.Length) // 超过字符串长度时回到第二个位置
                        index = 1;

                    charCounts[c]--;
                }
            }

            return new string(result);
        }