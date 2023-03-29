//496. Next Greater Element I med
//给没有重复元素的nums1和nums2，满足nums1[i]==nums2[j]，然后找到j的位置查看后面是否有比当前nums[j]大的数，有就输出，没有就是-1；
//思路：用stack方法先把nums2里每一位后面大的数存入一个list，然后后将这个list和nums2存入一个dictionary，利用nums1里的数来查找相对应的value；
		public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            // 记录 nums2 中每个元素的下一个更大元素
            int[] greater = NextGreaterElement(nums2);
            // 转化成映射：元素 x -> x 的下一个最大元素
            Dictionary<int, int> greaterMap = new Dictionary<int, int>();
            for (int i = 0; i < nums2.Length; i++)
            {
                greaterMap.Add(nums2[i], greater[i]);
            }
            // nums1 是 nums2 的子集，所以根据 greaterMap 可以得到结果
            int[] res = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                res[i] = greaterMap[nums1[i]];
            }
            return res;
        }
        public int[] NextGreaterElement(int[] nums)
        {
            int n = nums.Length;
            // 存放答案的数组
            int[] res = new int[n];
            Stack<int> s = new Stack<int>();
            // 倒着往栈里放
            for (int i = n - 1; i >= 0; i--)
            {
                // 判定个子高矮
                while (s.Count!=0 && s.Peek() <= nums[i])
                {
                    // 矮个起开，反正也被挡着了。。。
                    s.Pop();
                }
                // nums[i] 身后的更大元素
                res[i] = s.Count == 0 ? -1 : s.Peek();
                s.Push(nums[i]);
            }
            return res;
        }