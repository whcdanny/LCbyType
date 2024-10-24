//Leetcode 3289. The Two Sneaky Numbers of Digitville ez
//题目：在数字村(Digitville)中，有一个叫做 nums 的数字列表，列表中包含从 0 到 n-1 的整数，每个数字应该恰好出现一次。
//然而，有两个数字偷偷出现了多一次，导致列表的长度比正常情况更长。
//作为小镇的侦探，你需要找到这两个偷偷出现的数字，并返回一个大小为2的数组，包含这两个数字（顺序不限），以恢复小镇的和平。
//思路：利用计数数组:
//创建一个计数数组 count，长度为 n，初始化为 0，用来统计每个数字在 nums 列表中出现的次数。
//遍历 nums 数组，对每个出现的数字进行计数。
//找出计数数组中等于 2 的数字，即为重复出现的两个数字。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] GetSneakyNumbers(int[] nums)
        {
            int n = nums.Length - 2; // 原始数组的长度应该是 n
            int[] count = new int[n];
            List<int> result = new List<int>();

            // 统计每个数字的出现次数
            foreach (int num in nums)
            {
                count[num]++;
            }

            // 找到重复出现的数字
            for (int i = 0; i < n; i++)
            {
                if (count[i] == 2)
                {
                    result.Add(i);
                }
                if (result.Count == 2)
                {
                    break;
                }
            }

            return result.ToArray();
        }