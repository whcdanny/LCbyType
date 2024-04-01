//Leetcode 2671. Frequency Tracker med
//题意：要求设计一个数据结构 FrequencyTracker，用于跟踪其中的值并回答一些关于它们频率的查询。具体来说，需要实现以下几个方法：
//FrequencyTracker()：初始化一个空的数据结构。
//void Add(int number)：向数据结构中添加一个数字。
//void DeleteOne(int number)：从数据结构中删除一个数字的一个实例。
//bool HasFrequency(int frequency)：判断数据结构中是否存在某个数字的频率等于给定频率
//思路：hashtable, 把频繁出现的数字和频繁出现的个数，做成两个数组，       
//时间复杂度：O(n)
//空间复杂度：O(n)
        public class FrequencyTracker
        {
            private int[] numberFreq;
            private int[] freqCount;

            public FrequencyTracker()
            {
                numberFreq = new int[100001];
                freqCount = new int[100001];
            }

            public void Add(int number)
            {
                int oldFreq = numberFreq[number];
                freqCount[oldFreq]--;
                freqCount[oldFreq + 1]++;
                numberFreq[number]++;
            }

            public void DeleteOne(int number)
            {
                if (numberFreq[number] > 0)
                {
                    int oldFreq = numberFreq[number];
                    freqCount[oldFreq]--;
                    freqCount[oldFreq - 1]++;
                    numberFreq[number]--;
                }
            }

            public bool HasFrequency(int frequency)
            {
                return freqCount[frequency] > 0 ? true : false;
            }
        }