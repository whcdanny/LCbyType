//Leetcode 895. Maximum Frequency Stack hard
//设计一个最大频率栈 push(int x)：将元素 x 推入栈中。pop()：从栈顶移除并返回频率最高的元素。如果有多个元素频率相同，则返回最近添加的那个元素
//思路：Stack, HashMap（freqMap），用于记录每个元素出现的频率。HashMap 的值为栈（stackMap），其中键是频率，值是一个栈，用于存储对应频率的元素。
//当push的时候跟新出现的最多的数字，然后更新stackMap里的stack；pop的时候，先pop出数，然后更新出现最多的stack；
//时间复杂度：对于 push 操作，需要更新频率表和元素列表，以及堆的操作，时间复杂度为 O(log(n))，其中 n 是元素总数。对于 pop 操作，直接从堆中取出堆顶元素，时间复杂度为 O(1)。
//空间复杂度：需要维护两个哈希表 freq 和 group，以及一个最大堆 maxHeap，所以空间复杂度为 O(n)。
        public class FreqStack
        {
            private Dictionary<int, int> freqMap;
            private Dictionary<int, Stack<int>> stackMap;
            private int maxFreq;

            public FreqStack()
            {
                freqMap = new Dictionary<int, int>();
                stackMap = new Dictionary<int, Stack<int>>();
                maxFreq = 0;
            }

            public void Push(int x)
            {
                if (!freqMap.ContainsKey(x))
                {
                    freqMap[x] = 0;
                }

                freqMap[x]++;
                maxFreq = Math.Max(maxFreq, freqMap[x]);

                if (!stackMap.ContainsKey(freqMap[x]))
                {
                    stackMap[freqMap[x]] = new Stack<int>();
                }

                stackMap[freqMap[x]].Push(x);
            }

            public int Pop()
            {
                int x = stackMap[maxFreq].Pop();
                freqMap[x]--;

                if (stackMap[maxFreq].Count == 0)
                {
                    maxFreq--;
                }

                return x;
            }
        }