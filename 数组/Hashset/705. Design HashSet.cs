//Leetcode 705. Design HashSet ez
//题目：设计一个 HashSet，不使用任何内置哈希表库。
//实现MyHashSet类：
//void add(key)将值插入key到 HashSet 中。
//bool contains(key)返回该值是否key存在于 HashSet 中。
//void remove(key)key删除HashSet 中的值。如果keyHashSet 中不存在该值，则不执行任何操作。
//思路: 用数组int[]
//时间复杂度：O(n)
//空间复杂度：O(1)
        public class MyHashSet
        {
            int[] arr;
            public MyHashSet()
            {
                arr = new int[1000001];
            }

            public void Add(int key)
            {
                arr[key] = 1;
            }

            public void Remove(int key)
            {
                arr[key] = 0;

            }

            public bool Contains(int key)
            {
                return arr[key] == 1 ? true : false;
            }
        }

        /**
         * Your MyHashSet object will be instantiated and called as such:
         * MyHashSet obj = new MyHashSet();
         * obj.Add(key);
         * obj.Remove(key);
         * bool param_3 = obj.Contains(key);
         */