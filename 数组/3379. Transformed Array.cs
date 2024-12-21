//Leetcode 3379. Transformed Array ez
//题意：给定一个nums表示循环数组的整数数组。您的任务是创建一个相同result大小的新数组，遵循以下规则：
//对于每个索引i（其中0 <= i<nums.length），执行以下独立操作：
//如果nums[i]> 0：从索引处开始，在循环数组中向右i移动nums[i] 步骤。设置为您着陆的索引的值。result[i]
//如果nums[i] < 0：从索引处开始i，在循环数组中向左abs(nums[i])移动步骤。设置为您着陆的索引的值。result[i]
//如果nums[i] == 0：设置result[i] 为nums[i]。
//返回新数组result。
//注意：由于nums是循环的，所以移动到最后一个元素之后会绕回到开头，移动到第一个元素之前会绕回到结尾。        
//思路：这里要注意的就是，
//如果是正数就是res[i] = nums[(i + nums[i]) % n];
//如果是负数，就index = (i + nums[i]) % n; index = index + n;
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public int[] ConstructTransformedArray(int[] nums)
        {
            int n = nums.Length;
            var res = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 0)
                {
                    res[i] = nums[i];
                    continue;
                }
                if (nums[i] > 0)
                {
                    res[i] = nums[(i + nums[i]) % n];
                }
                else
                {
                    var index = (i + nums[i]) % n;
                    if (index < 0) index = index + n;
                    res[i] = nums[index];
                }
            }
            return res;
        }