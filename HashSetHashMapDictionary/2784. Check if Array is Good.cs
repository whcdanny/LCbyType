//Leetcode 2784. Check if Array is Good ez
//题意：给定一个整数数组 nums，判断该数组是否是数组 base[n] 的一个排列。
//数组 base[n] 是由 1 到 n - 1 各出现一次，并且包含两个 n 的数组。例如，base[1] = [1, 1]，base[3] = [1, 2, 3, 3]。
//思路：hashtable, sort nums, 从1开始直到n-1的位置都要遵从1 - n-1，然后最后一个位置不用+1，然后看是否那满足；        
//时间复杂度：O(n)
//空间复杂度：O(1)
        public bool IsGood(int[] nums)
        {
            if (nums.Length == 1) 
                return false;
            Array.Sort(nums);

            var index = 1;
            foreach (var num in nums)
            {
                if (num != index) 
                    return false;
                if (index < nums.Length - 1) 
                    index++;
            }
            return true;
        }