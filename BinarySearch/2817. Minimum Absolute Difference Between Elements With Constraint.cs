//Leetcode 2817. Minimum Absolute Difference Between Elements With Constraint med
//题意：给定一个整数数组 nums 和一个整数 x。
//要求找到数组中至少相隔 x 个索引的两个元素之间的最小绝对差。
//换句话说，找到两个索引 i 和 j，使得 abs(i - j) >= x，且 abs(nums[i] - nums[j]) 的值最小。
//返回一个整数，表示至少相隔 x 个索引的两个元素之间的最小绝对差。
//思路：二分查找来解决, 因为位置dis是X，所以先建立一个x 开始到数组末尾的元素，并进行排序；
//然后从0开始依此算出跟与列表 list 中的元素的最小绝对差值；
//注：二分法用于查找，跟当前买家不重复房子的购买者；     
//时间复杂度:  O(n∗log(n))
//空间复杂度： O(n)
        public int MinAbsoluteDifference(IList<int> nums, int x)
        {
            if (x == 0) return 0;
            //数组 nums 中从索引 x 开始到数组末尾的元素，并进行排序
            var list = CreateInitListFromList(nums, x);
            //计算第一个元素 nums[0] 与 list 中的元素的最小绝对差值
            var rs = GetResult(nums[0], list);
            //从数组的第二个元素开始，依次处理每个元素，更新列表 list，然后调用 GetResult 方法计算当前元素与 list 中的元素的最小绝对差值，并将结果与之前的最小差值 rs 进行比较，更新 rs。
            for (int i = 1; i < nums.Count - x; i++)
            {
                //使得窗口中的元素满足索引差值至少为 x
                list.Remove(nums[i - 1 + x]);                
                var rs0 = GetResult(nums[i], list);
                rs = Math.Min(rs, rs0);
            }
            return rs;
        }

        //找到 num 与列表 list 中的元素的最小绝对差值
        private int GetResult(int num, List<int> list)
        {
            var left = 0;
            //如果 num 小于等于 list 中的最小的，直接返回差值 list[0] - num
            if (num <= list[left]) 
                return list[left] - num;
            //如果 num 大于等于 list 中的最大的，直接返回差值 num - list[list.Count - 1]。
            var right = list.Count - 1;
            if (list[right] < num) 
                return num - list[right];
            //进行二分查找，找到最接近 num 的元素的索引
            while (right - left > 1)
            {
                var indexMid = (left + right) / 2;
                if (list[indexMid] < num)
                {
                    left = indexMid;
                }
                else
                {
                    right = indexMid;
                }
            }
            //然后计算 num 与该元素的差值以及与该元素的下一个元素的差值，并返回最小值
            var rs = Math.Min(num - list[left], list[right] - num);
            return rs;
        }        
        private List<int> CreateInitListFromList(IList<int> nums, int x)
        {
            var rs = new List<int>();
            for (int i = x; i < nums.Count; i++)
            {
                rs.Add(nums[i]);
            }
            rs.Sort();
            return rs;
        }