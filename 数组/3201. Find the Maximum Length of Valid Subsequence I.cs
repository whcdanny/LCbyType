//Leetcode 3201. Find the Maximum Length of Valid Subsequence I  med
//题目：给定一个整数数组 nums。一个长度为 x 的子序列 sub 被称为有效的，当它满足以下条件时：
//(sub[0] + sub[1]) % 2 == (sub[1] + sub[2]) % 2 == ... == (sub[x - 2] + sub[x - 1]) % 2        
//要求返回 nums 的最长有效子序列的长度。
//一个子序列是可以从数组中通过删除一些或不删除元素获得的，并保持剩余元素的相对顺序。
//思路:  nums 中的最长有效子序列，满足以下条件之一：
//所有元素都是偶数。
//所有元素都是奇数。
//元素奇偶性交替出现。
//所以用nums[i] % 2 找出奇偶个数，然后再根据当前nums[i] % 2和前一个nums[i-1] % 2的检查是否交替
//最后Math.Max(even, Math.Max(odd, wave));
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MaximumLength(int[] nums)
        {
            int len = nums.Length;
            int even = 0, odd = 0, wave = 1, next = (nums[0]) % 2;
            if (len <= 2)
                return len;

            for (int i = 0; i < len; i++)
            {
                int mod = nums[i] % 2;
                if (mod == 0)
                    even++;
                else
                    odd++;
                if (mod != next)
                {
                    wave++;
                    next = mod;
                }
            }
            return Math.Max(even, Math.Max(odd, wave));
        }