//Leetcode 2856. Minimum Array Length After Pair Removals med
//题意：给定一个升序排序的整数数组 nums。可以进行以下操作任意次数：
//选择两个索引 i 和 j，其中 i<j 且 nums[i] < nums[j]。
//然后，从 nums 中移除索引为 i 和 j 的元素。剩余元素保持原始顺序，数组重新索引。
//要求返回在进行任意次操作后（包括零次）nums 的最小长度。
//注意：nums 是升序排列的。
//思路：左右针，逻辑是因为是递增，所以数组中必须有足够的数字来删除多余的数字，所以一半然后只要left的值小于right，那么就可以删除所以总长度-2；
//时间复杂度: O(n)
//空间复杂度：O(1)
        public int MinLengthAfterRemovals(IList<int> nums)
        {
            int n = nums.Count, remaining = n;
            int l = 0, r = (n + 1) / 2;
            while (l < n / 2 && r < nums.Count)
            {
                if (nums[l++] < nums[r++])
                {
                    remaining -= 2;
                }
            }
            return remaining;
        }
		
		public int MinLengthAfterRemovals1(IList<int> nums)
        {
            var list = CreateCountList(nums);
            var max = list.Max(); //原始数组中任意两个相邻相同元素中的较大长度
            if (max <= nums.Count / 2)
            {
                return nums.Count % 2;
            }
            //说明在移除一些元素后，还需要保留一部分元素
            //nums.Count - max 表示需要移除的元素个数。
            var rs = max - (nums.Count - max);
            return rs;
        }
        //函数的作用是将原始数组中相邻的相同元素进行分组，并记录每组的长度
        //原始数组 [1, 1, 2, 2, 2, 3] 会被转换成 [2, 3, 1]，表示有两个相邻的1，三个相邻的2，一个相邻的3。
        private List<int> CreateCountList(IList<int> nums)
        {
            var rs = new List<int> { 1 };
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i - 1] == nums[i])
                {
                    rs[rs.Count - 1]++;
                }
                else
                {
                    rs.Add(1);
                }
            }
            return rs;
        }