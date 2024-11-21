//Leetcode 238. Product of Array Except Self med
//题目：给定一个整数数组nums，返回一个数组 answer ，使得等于 除之外answer[i] 的所有元素的乘积 。nums nums[i]
//任何前缀或后缀的乘积都保证nums适合32位整数。
//您必须编写一个能够及时运行 O(n) 且无需使用除法运算的算法。
//思路: 要求除了i本身以外乘积，
//那么先找出每个i不包含自己前面的乘积
//然后找出每个i不包含自己后面的乘积
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            int prefixProduct = 1;
            for (int i = 0; i < n; i++)
            {
                res[i] = prefixProduct;
                prefixProduct *= nums[i];
            }
            int suffixProduct = 1;
            for(int i = n - 1; i >= 0; i--)
            {
                res[i] *= suffixProduct;
                suffixProduct *= nums[i];
            }
            return res;
        }