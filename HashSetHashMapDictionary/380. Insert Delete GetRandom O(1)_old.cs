//380. Insert Delete GetRandom O(1) med
//设计一个支持时间复杂度位O(1)的插入，删除和随机选取数字的functions
//思路：用list存元素值，用dictionary存元素和所在位置，
//注意难点在删除，先拿到 val 的索引位置， 将最后一个元素对应的索引修改为 index，在数组中删除元素 val，删除元素 val 对应的索引
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
                list[index]=last;
				valToIndex[last]=index;
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