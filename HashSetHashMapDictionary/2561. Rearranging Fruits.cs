//Leetcode 2561. Rearranging Fruits hard
//题意：给定两个装有水果的篮子，每个篮子包含 n 个水果。你被给出两个数组 basket1 和 basket2，分别表示每个篮子中水果的成本。你想要使两个篮子相同。为了实现这一目标，你可以多次使用以下操作：
//选择两个索引 i 和 j，并交换 basket1 的第 i 个水果与 basket2 的第 j 个水果。交换的成本为 min(basket1[i], basket2[j])。
//如果根据水果成本排序后两个篮子完全相同，则认为它们相等。
//要求返回使两个篮子相等的最小成本，如果不可能使篮子相等则返回 -1。
//思路：hashtable, 用SortedDictionary 把每个数字出现在basket1和basket2的总和，出现在basket1的+，出现在basket2的-；
//这样如果某个数是0，那么就证明已经都有了，如果不是%0，说明没办法保证两个篮子都有相同数，-1；
//如果大于0，那么就是basket1放入basket2，如果小于0，那么就是basket2放入basket1里；都是分一半；
//注：这里有个坎儿，为什么用SortedDictionary，因为在算翻入篮子的时候，交换的成本为 min(basket1[i], basket2[j])，
//所以要看数篮子中最小的那个值 ret += Math.Min(list[i], 2 * minKey); 
//就好比 我们要交换（10，20）那费用是10，但是如果用1，就是（10，1）（1，20）然后总共费用才是2；
//时间复杂度：O(n1+n2) 
//空间复杂度：O(n1+n2)
        public long MinCost(int[] basket1, int[] basket2)
        {
            SortedDictionary<long, long> map = new SortedDictionary<long, long>();

            foreach (int x in basket1)
            {
                if (!map.ContainsKey(x))
                    map[x] = 0;            
                map[x]++;
            }               

            foreach (int x in basket2)
            {
                if (!map.ContainsKey(x))
                    map[x] = 0;                
                map[x]--;

            }               

            // 获取第一个键值对的键作为 t
            long minKey = map.Keys.First();

            // 计算 list 数组
            List<long> list = new List<long>();
            foreach (var kvp in map)
            {
                if (kvp.Value % 2 != 0) return -1;

                //第一个篮子放入到第二个
                if (kvp.Value > 0)
                {
                    for (int i = 0; i < kvp.Value / 2; i++)
                        list.Add(kvp.Key);
                }
                //第二个篮子放入第一个
                else
                {
                    for (int i = 0; i < Math.Abs(kvp.Value / 2); i++)
                        list.Add(kvp.Key);
                }
            }

            // 对 list 数组进行排序
            list.Sort();

            // 计算总的交换成本
            int n = list.Count;
            long ret = 0;
            for (int i = 0; i < n / 2; i++)
                ret += Math.Min(list[i], 2 * minKey);

            return ret;
        }