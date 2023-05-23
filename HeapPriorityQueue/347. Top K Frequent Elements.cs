//347. Top K Frequent Elements med
//问题要求找出给定整数数组中出现频率最高的 K 个元素
//思路：dictionary记录出现频率，然后根据k找出max；
        public int[] TopKFrequent(int[] nums, int k)
        {
            int[] res = new int[k];
            Dictionary<int, int> list = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (list.ContainsKey(i))
                {
                    list[i]++;
                }
                else
                {
                    list[i] = 1;
                }
            }
            for (int i = 0; i < k; i++)
            {
                int max = Int32.MinValue;
                int value = 0;
                foreach (int key in list.Keys)
                {
                    int num = list[key];
                    if (num > max)
                    {
                        max = num;
                        value = key;
                    }
                }
                res[i] = value;
                list.Remove(value);
            }
            return res;
        }