//1429. First Unique Number med
//FirstUnique(int[] nums)：用来初始化整型数组 nums。
//int ShowFirstUnique()：返回在初始化的数组中第一个不重复的整数的值。如果不存在这样的整数，则返回 -1。
//void Add(int value)：将 value 插入到数组中。
//思路：用dictionary来存每一个num和出现数量，用queue来存出现一次
        private Dictionary<int, int> countMap;
        private Queue<int> queue;

        public void FirstUnique(int[] nums)
        {
            countMap = new Dictionary<int, int>();
            queue = new Queue<int>();
            foreach (int num in nums)
            {
                Add(num);
            }
        }

        public int ShowFirstUnique()
        {
            while (queue.Count > 0 && countMap[queue.Peek()] > 1)
            {
                queue.Dequeue();
            }
            return queue.Count > 0 ? queue.Peek() : -1;
        }

        public void Add(int value)
        {
            if (!countMap.ContainsKey(value))
            {
                countMap[value] = 0;
            }
            countMap[value]++;
            if (countMap[value] == 1)
            {
                queue.Enqueue(value);
            }
        }