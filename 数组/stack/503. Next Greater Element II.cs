//503. Next Greater Element II med
//给没有重复元素的nums1和nums2，满足nums1[i]==nums2[j]，然后找到j的位置查看后面是否有比当前nums[j]大的数，由于这次可以环形找所以不存在找不到的情况，如没有比数大的才return-1；
//思路：用stack方法先把nums2里每一位后面大的数存入一个list，然后后将这个list和nums2存入一个dictionary，利用nums1里的数来查找相对应的value；这次可以环形找，所以要用到2*n-1 和 i%n；
		public int[] NextGreaterElements(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            Stack<int> s = new Stack<int>();
            // 数组长度加倍模拟环形数组
            for (int i = 2 * n - 1; i >= 0; i--)
            {
                // 索引 i 要求模，其他的和模板一样
                while (s.Count!=0 && s.Peek() <= nums[i % n])
                {
                    s.Pop();
                }
                res[i % n] = s.Count==0 ? -1 : s.Peek();
                s.Push(nums[i % n]);
            }
            return res;
        }