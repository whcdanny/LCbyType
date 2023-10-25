//Leetcode 380. Insert Delete GetRandom O(1) med
//题意：设计一个支持在平均时间复杂度 O(1) 下，执行以下操作的数据结构。
//insert(val)：当元素 val 不存在时，向集合中插入它。
//remove(val)：元素 val 存在时，从集合中移除它。
//getRandom()：随机返回集合中的一个元素。
//思路：使用哈希表来存储每个元素和其在数组中的索引。使用动态数组来存储元素，以便支持随机访问。insert(val) 操作：首先检查元素是否已存在于哈希表中，如果存在则返回 false，否则将元素插入到动态数组末尾，并更新哈希表中的索引。remove(val) 操作：首先检查元素是否存在于哈希表中，如果不存在则返回 false，否则将元素从动态数组中移除，并更新哈希表中的索引。getRandom() 操作：随机生成一个索引，从动态数组中获取相应的元素
//时间复杂度：插入、删除和获取随机元素的操作都可以在 O(1)
//空间复杂度：O(n)，其中 n 是集合中的元素数量      
        public class RandomizedSet
        {
            // 存储元素的值
            List<int> list;
            // 记录每个元素对应在 nums 中的索引位置
            Dictionary<int, int> valToIndex;
            Random random;

            public RandomizedSet()
            {
                list = new List<int>();
                valToIndex = new Dictionary<int, int>();
                random = new Random();
            }

            public bool Insert(int val)
            {
                if (valToIndex.ContainsKey(val))
                    return false;
                list.Add(val);
                valToIndex.Add(val, list.Count - 1);
                return true;
            }

            public bool Remove(int val)
            {
                if (!valToIndex.ContainsKey(val))
                    return false;
                // 先拿到 val 的索引位置
                int index = valToIndex[val];
                // 将最后一个元素对应的索引修改为 index
                int last = list[list.Count - 1];
                list[index] = last;
                valToIndex[last] = index;
                // 在数组中删除元素 val
                list.RemoveAt(list.Count - 1);
                // 删除元素 val 对应的索引
                valToIndex.Remove(val);
                return true;
            }

            public int GetRandom()
            {
                return list[random.Next(list.Count)];
            }
        }