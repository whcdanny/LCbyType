//Leetcode 413. Arithmetic Slices med
//题意：如果整数数组至少由三个元素组成，并且任意两个连续元素之间的差相同，则称该整数数组为算术数组。
//例如，[1,3,5,7,9]、[7,7,7,7]和[3, -1, -5, -9] 是等差序列。
//给定一个整数数组nums，返回的算术子数组的数量 nums。
//子数组是数组的连续子序列。
//思路：如果nums大小小于3 就是0
//然后从第一个开始以每两个差，一个一个往后历遍，
//如果满足，那么就可以count++，直到差不一样。
//时间复杂度:  O(n*n)
//空间复杂度： O(1)
        public int NumberOfArithmeticSlices(int[] nums)
        {
            int n = nums.Length;
            if (n < 3)
                return 0;
            int total = 0;
            for(int i = 1; i < n; i++)
            {
                int dif = nums[i] - nums[i-1];
                int count = 0;
                int k = i;
                for(int j = i + 1; j < n; j++)
                {
                    int tempDif = nums[j] - nums[k];
                    if (dif == tempDif)
                    {
                        count++;
                        k++;
                    }
                    else
                    {
                        break;
                    }
                }
                total += count;
            }
            return total;
        }