//Leetcode 1429. First Unique Number med
//FirstUnique(int[] nums)：用来初始化整型数组 nums。
//int ShowFirstUnique()：返回在初始化的数组中第一个不重复的整数的值。如果不存在这样的整数，则返回 -1。
//void Add(int value)：将 value 插入到数组中。
//思路：使用两个队列，一个用于存储所有添加的元素，另一个用于存储出现次数为1的元素（即唯一元素）。
//时间复杂度：add 操作：O(1) showFirstUnique 操作：O(1)
//空间复杂度：哈希表用于存储元素和对应的节点，空间复杂度为 O(n)。双向链表用于存储出现次数为1的元素，空间复杂度也为 O(n)。总的空间复杂度为 O(n)。
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