//Leetcode 2465. Number of Distinct Averages ez
//题意：给定一个长度为偶数的整数数组 nums。在数组不为空的情况下，要求重复执行以下步骤：
//找到数组中的最小值并删除它。
//找到数组中的最大值并删除它。
//计算这两个被删除数字的平均值。
//两个数字 a 和 b 的平均值为(a + b) / 2。    
//返回使用上述过程计算得到的不同平均值的数量。
//思路：左右针，进行排序，使得数组中的最小值和最大值分别位于数组的两端,找平均值，然后找出一个有多少不一样的值；
//注：用HashSet存因不会有重复的平均值；
//时间复杂度: O(n log n)
//空间复杂度：O(n)
        public int DistinctAverages(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            HashSet<double> list = new HashSet<double>();            
            for (int i = 0, j = n - 1; i < j; i++, j--)
            {
                double avg = (nums[i] + nums[j]) / 2.0;
                list.Add(avg);              
            }

            return list.Count;
        }
        public int DistinctAverages1(int[] nums)
        {
            Array.Sort(nums);
            HashSet<double> my = new HashSet<double>();
            for (int i = 0; i < nums.Length / 2; i++)
                my.Add((double)(nums[i] + nums[nums.Length - i - 1]) / 2);
            return my.Count;
        }