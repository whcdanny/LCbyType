//Leetcode 1146. Snapshot Array med
//题意：设计一个支持下列两种操作的数据结构：
//SnapshotArray(int length) - 构造函数，初始化一个长度为 length 的数组，初始值全部为 0。
//void Set(int index, int val) - 在数组中给定索引 index 处设置为 val。
//int Snap() - 拍照：记录当前数组的快照，并返回快照的 ID（从 0 开始递增）。
//int Get(int index, int snap_id) - 根据给定的 snap_id，返回对应索引 index 处的快照值。
//思路：构造函数思路：初始化数组为长度为 length 的全 0 数组。使用 List<List<int, int>> 来记录每次快照的修改。使用 snapId 记录当前的快照 ID。
//Set 操作思路：直接在数组中设置给定索引处的值。在输入的时候是根据snapId和val存入；
//Snap 操作思路：只需要snapId++，因为存入的时候我们会存入当前snapId和val
//Get 操作思路：遍历快照列表，用二分搜索找到最接近给定 snap_id 且小于等于 snap_id 的快照。在该快照中查找给定索引处的值。
//注：为什么用snapId，因为我们避免无效的sanp因为如果第一次是5，而直到第五次的时候这个值变了2，那么这之间我们不需要snap所以只需要snapID+=；
//时间复杂度:Set 操作为 O(1)。Snap 操作为 O(1)。Get 操作为 O(logN)，使用二分查找找到最接近的快照。
//空间复杂度：List<Dictionary<int, int>> 存储快照，空间复杂度为 O(N)。
        public class SnapshotArray
        {

            private int snapshot_id;
            private List<List<(int, int)>> records;

            public SnapshotArray(int length)
            {
                snapshot_id = 0;
                records = new List<List<(int, int)>>(length);
                for (int i = 0; i < length; i++) records.Add(new List<(int, int)> { (0, 0) });
            }

            public void Set(int index, int val)
            {
                records[index].Add((snapshot_id, val));
            }

            public int Snap()
            {
                return snapshot_id++;
            }

            public int Get(int index, int snap_id)
            {
                List<(int, int)> array = records[index];

                // inde x <= index
                int start = 0, end = array.Count - 1;
                while (start < end)
                {
                    int mid = (end + start) / 2;
                    if (array[mid].Item1 <= snap_id) start = mid;
                    else end = mid-1;
                }

                //if (array[end].Item1 <= snap_id) return array[end].Item2;
                return array[start].Item2;
            }
        }

        /**
         * Your SnapshotArray object will be instantiated and called as such:
         * SnapshotArray obj = new SnapshotArray(length);
         * obj.Set(index,val);
         * int param_2 = obj.Snap();
         * int param_3 = obj.Get(index,snap_id);
         */