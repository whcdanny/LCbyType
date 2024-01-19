//Leetcode 922. Sort Array By Parity II ez
//题意：给定一个整数数组 nums，数组中一半的整数是奇数，另一半是偶数。要求将数组排序，使得当 nums[i] 是奇数时，i 也是奇数，当 nums[i] 是偶数时，i 也是偶数。返回满足这个条件的任意一个答案数组。
//思路：双指针，新的数组 result，用于存放排序后的结果。
//使用两个指针 evenIndex 和 oddIndex 分别表示偶数位置和奇数位置。
//遍历原始数组 nums，对每个元素判断其奇偶性。
//如果元素是偶数，则将其放在 result 数组的偶数位置，并更新 evenIndex。
//如果元素是奇数，则将其放在 result 数组的奇数位置，并更新 oddIndex。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] SortArrayByParityII(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];

            int evenIndex = 0;
            int oddIndex = 1;

            foreach (int num in nums)
            {
                if (num % 2 == 0)
                {
                    result[evenIndex] = num;
                    evenIndex += 2;
                }
                else
                {
                    result[oddIndex] = num;
                    oddIndex += 2;
                }
            }

            return result;
        }