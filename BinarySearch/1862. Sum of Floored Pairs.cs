//Leetcode 1862. Sum of Floored Pairs hard
//题意：题目要求给定一个整数数组 nums，计算所有下标对 (i, j) 满足 0 <= i, j < nums.length 的 floor(nums[i] / nums[j]) 的和。这里的 floor(x) 表示对 x 进行整数除法后的整数部分。由于答案可能会很大，需要对结果取模 10^9 + 7。
//注：floor取的下面 floor(5 / 2) = 2
//思路：用二分法定义，用二分法先找到第一个比nums[i]大的位置j，也就是说再i之前的如果num[i]/之前的数都为0，然后我们来找nums[i]这个数的倍数2，3，4，倍数，如果存在ind，那么就用ind-j，这个区间表示有比nums[i]大c倍的数；
//然后依此用二分法找，
//注：这里要考虑数重复的问题，看code注解就理解；
//时间复杂度: 排序的时间复杂度为 O(n log n)，两层循环的时间复杂度为 O(n^2)，因此总体时间复杂度为 O(n^2 log n)
//空间复杂度：O(1)
        public int SumOfFlooredPairs(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int mod = 1_000_000_007;
            long result = 0;
            int i = 0;
            while (i < n)
            {
                //x: nums[i]对应的位置，
                //j表示每一次二分搜索移动的位置；
                //k表示当i的位置，因为i要被用替换成当前二分搜索的位置j
                //temp_sum：表示以i来搜索的当前总和；
                //duplicates表示在x到i之间这些数都与nums[i]，避免重复运算；
                //c表示我们要查找比nums[i]的倍数；
                int x = upperBound_SumOfFlooredPairs(nums, nums[i]);
                int j = x, k = i, c = 2;
                long tmp_sum = 0, duplicates = x - i;
                i = j;
                while (j < n)
                {
                    //y表示nums[k]的c倍数
                    //ind表示最多能到nums中的位置；
                    int y = nums[k] * c;
                    int ind = upperBound_SumOfFlooredPairs(nums, y - 1);
                    //ind - j表示有这么多个比y到j区间，然后因为时c倍数所以-1;
                    tmp_sum = (tmp_sum + (ind - j) * (c - 1)) % mod;
                    //j表示每一次二分搜索移动的位置；
                    j = ind;
                    //倍数+1；
                    c++;
                }
                //重复的 再加上 他们本身可以跟本身除，所以相当于 2，2，2：这里有三个重复的2，2a/2a,2b/2b,2c/2c,这样一共2a有三个，那么总共就是3*3；
                tmp_sum = tmp_sum * duplicates + (duplicates * duplicates);
                result = (result + tmp_sum) % mod;
            }
            return (int)result;
        }

        //upper_bound函数用于查找在有序容器中第一个大于给定值的元素的位置。
        private int upperBound_SumOfFlooredPairs(int[] list, int val)
        {
            int l = 0, r = list.Length;
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