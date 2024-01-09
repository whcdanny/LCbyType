//Leetcode 1157. Online Majority Element In Subarray hard 超时
//题意：题意：设计一个数据结构，支持两个操作：
//MajorityChecker(int[] arr) - 构造函数，输入整数数组arr。
//Query(int left, int right, int threshold) - 查询函数，返回在子数组arr[left, right] 中出现次数超过threshold的主要元素。如果没有主要元素，则返回-1。
//思路：使用二分搜索, 先用map存每个数和其出现位置，然后根据这个建立P来存出现频率之和与其数排倒序；
//Query 根据left和right的位置，在p中找到对应的位置，然后算长度 如果跟大于threshold，就有，
//时间复杂度:构造函数时间复杂度为 O(NlogN)，主要由排序操作决定。查询函数时间复杂度为 O(logN)，主要由二分查找决定。
//空间复杂度：O(N)，主要由哈希表、前缀和数组和排序后的元素列表决定。
        public class MajorityChecker
        {

            private Dictionary<int, List<int>> Map;
            private List<Tuple<int, int>> q;

            public MajorityChecker(int[] arr)
            {
                Map = new Dictionary<int, List<int>>();
                q = new List<Tuple<int, int>>();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (!Map.ContainsKey(arr[i]))
                    {
                        Map[arr[i]] = new List<int>();
                    }

                    Map[arr[i]].Add(i);
                }


                foreach (var x in Map)
                    q.Add(new Tuple<int, int>(x.Value.Count, x.Key));

                q.Sort((a, b) => b.Item1.CompareTo(a.Item1));
            }

            public int Query(int left, int right, int threshold)
            {
                int total = right - left + 1;                
                for (int i = 0; i < q.Count; i++)
                {
                    int num = q[i].Item2;
                    if (Map[num].Count < threshold)
                        return -1;
                    int pos1 = lowerBound_MajorityChecker(Map[num].ToArray(), left);
                    if (pos1 < 0) pos1 = ~pos1;
                    int pos2 = upperBound_MajorityChecker(Map[num].ToArray(), right);
                    if (pos2 < 0) pos2 = ~pos2;

                    if (pos2 - pos1 >= threshold)
                        return num;
                    else
                        total -= pos2 - pos1;
                    if (total < threshold)
                        return -1;
                }

                return -1;
            }

            private int upperBound_MajorityChecker(int[] list, int val)
            {
                int l = 0, r = list.Length - 1;
                while (l < r)
                {
                    int m = (l + r) / 2;
                    if (list[m] <= val)
                        l = m + 1;
                    else
                        r = m;
                }
                return l;
            }

            private int lowerBound_MajorityChecker(int[] list, int val)
            {
                int l = 0, r = list.Length - 1;
                while (l < r)
                {
                    int m = (l + r) / 2;
                    if (list[m] < val)
                        l = m + 1;
                    else
                        r = m;
                }
                return l;
            }
        }