//Leetcode 432. All Oone Data Structure hard
//题意：设计一种数据结构来存储字符串的计数，并能够返回具有最小和最大计数的字符串。
//实现类 AllOne，要求支持以下操作：AllOne()初始化数据结构对象。
//inc(String key)将字符串 key 的计数增加 1。如果 key 不存在，则插入 key，初始计数为 1。如果 key 已存在，则将其计数加 1。
//dec(String key)将字符串 key 的计数减少 1。如果计数减为 0，则从数据结构中移除该字符串。保证调用 dec 时，key 在数据结构中一定存在。
//getMaxKey()返回一个计数值最大的字符串。如果没有元素，返回空字符串 ""。
//getMinKey()返回一个计数值最小的字符串。如果没有元素，返回空字符串 ""。
//思路：用一个Dictionary<string, int> countMap 存每个string的个数
//Dictionary<int, HashSet<string>> map存每个个数里出现的string
//SortedSet<int> sortedCounts 排序从小到大出现的个数
//AllOne：初始化Dictionary<string, int> countMap; Dictionary<int, HashSet<string>> map; SortedSet<int> sortedCounts;
//Inc(string key)：先判断是否countMap存在，然后的出currCount，然后检查是否当前然currCount==0，从而删除currCount从map和sortedCounts
//然后newCount = currentCount + 1;跟新countMap，map还有sortedCounts；如果countMap不存在就添加1
//Dec(string key)：countMap存在，然后的出currCount，然后检查是否当前然currCount==0，从而删除currCount从map和sortedCounts
//然后newCount = currentCount - 1;跟新countMap，map还有sortedCounts；
//GetMaxKey(): sortedCounts.Max; 然后map[maxCount].First();
//GetMinKey()：sortedCounts.Min; 然后map[minCount].First();
//时间复杂度:  所有O(1) 
//空间复杂度： O(n)
        public class AllOne
        {
            private Dictionary<string, int> countMap;

            private Dictionary<int, HashSet<string>> map;

            private SortedSet<int> sortedCounts;
            public AllOne()
            {
                countMap = new Dictionary<string, int>();
                map = new Dictionary<int, HashSet<string>>();
                sortedCounts = new SortedSet<int>();
            }

            public void Inc(string key)
            {
                if (countMap.ContainsKey(key))
                {
                    int currentCount = countMap[key];
                    // Remove the key from the current bucket
                    map[currentCount].Remove(key);
                    if (map[currentCount].Count == 0)
                    {
                        map.Remove(currentCount);
                        sortedCounts.Remove(currentCount);
                    }

                    // Increment the count
                    int newCount = currentCount + 1;
                    countMap[key] = newCount;

                    // Add the key to the new bucket
                    if (!map.ContainsKey(newCount))
                    {
                        map[newCount] = new HashSet<string>();
                        sortedCounts.Add(newCount);
                    }
                    map[newCount].Add(key);
                }
                else
                {
                    // New key, set count to 1
                    countMap[key] = 1;
                    if (!map.ContainsKey(1))
                    {
                        map[1] = new HashSet<string>();
                        sortedCounts.Add(1);
                    }
                    map[1].Add(key);
                }
            }

            public void Dec(string key)
            {
                if (countMap.ContainsKey(key))
                {
                    int currentCount = countMap[key];
                    // Remove the key from the current bucket
                    map[currentCount].Remove(key);
                    if (map[currentCount].Count == 0)
                    {
                        map.Remove(currentCount);
                        sortedCounts.Remove(currentCount);
                    }

                    // Decrement the count or remove if it reaches 0
                    if (currentCount == 1)
                    {
                        countMap.Remove(key);
                    }
                    else
                    {
                        int newCount = currentCount - 1;
                        countMap[key] = newCount;

                        // Add the key to the new bucket
                        if (!map.ContainsKey(newCount))
                        {
                            map[newCount] = new HashSet<string>();
                            sortedCounts.Add(newCount);
                        }
                        map[newCount].Add(key);
                    }
                }
            }

            public string GetMaxKey()
            {
                if (sortedCounts.Count == 0)
                {
                    return "";
                }
                int maxCount = sortedCounts.Max;
                return map[maxCount].First();
            }

            public string GetMinKey()
            {
                if (sortedCounts.Count == 0)
                {
                    return "";
                }
                int minCount = sortedCounts.Min;
                return map[minCount].First();
            }
        }