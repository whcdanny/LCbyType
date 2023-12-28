//Leetcode 2080. Range Frequency Queries med
//题意：设计一个数据结构，用于查询给定子数组中指定值的频率。
//子数组中某个值的频率是该值在子数组中出现的次数。
//实现 RangeFreqQuery 类：
//RangeFreqQuery(int[] arr) : 用给定的数组 arr 构造类的实例。
//int query(int left, int right, int value): 返回子数组 arr[left...right] 中值为 value 的频率。
//思路：二分搜索,使用字典 valueToIndices 存储每个值在数组中出现的索引列表。在构造函数中，初始化字典。对于 Query 方法，使用二分查找找到值为 value 的索引范围，计算频率。使用二分查找的下界和上界实现。
//时间复杂度: O(log n)
//空间复杂度：O(n)       
        public class RangeFreqQuery
        {

            private Dictionary<int, List<int>> valueToIndices;
            private int[] arr;

            public RangeFreqQuery(int[] arr)
            {
                this.arr = arr;
                this.valueToIndices = new Dictionary<int, List<int>>();
                Initialize();
            }

            private void Initialize()
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!valueToIndices.ContainsKey(arr[i]))
                    {
                        valueToIndices[arr[i]] = new List<int>();
                    }
                    valueToIndices[arr[i]].Add(i);
                }
            }

            public int Query(int left, int right, int value)
            {
                if (valueToIndices.ContainsKey(value))
                {
                    int leftIndex = LowerBound(valueToIndices[value], left);
                    int rightIndex = UpperBound(valueToIndices[value], right);
                    return rightIndex - leftIndex;
                }
                return 0;
            }

            private int LowerBound(List<int> indices, int target)
            {
                int left = 0, right = indices.Count;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (indices[mid] < target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                return left;
            }

            private int UpperBound(List<int> indices, int target)
            {
                int left = 0, right = indices.Count;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (indices[mid] <= target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                return left;
            }
        }

        /**
         * Your RangeFreqQuery object will be instantiated and called as such:
         * RangeFreqQuery obj = new RangeFreqQuery(arr);
         * int param_1 = obj.Query(left,right,value);
         */