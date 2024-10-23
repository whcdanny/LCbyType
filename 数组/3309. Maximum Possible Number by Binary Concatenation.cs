//Leetcode 3309. Maximum Possible Number by Binary Concatenation med
//题目：给定一个大小为 3 的整数数组 nums，返回可能的最大数字，其二进制表示可以通过将 nums 中所有元素的二进制表示按某种顺序连接而成。
//需要注意的是，任何数字的二进制表示中都不包含前导零。
//思路：二进制拼接：问题要求将三个整数的二进制表示进行拼接，并且按照不同的排列顺序来比较，找出最大的拼接结果。因此需要找到所有可能的排列组合。
//排列组合：由于数组长度为 3，可以通过排列的方式生成所有可能的排列（即 3! = 6 种情况）。
//二进制拼接并比较大小：对于每一种排列，将其二进制表示拼接成一个字符串，然后将该字符串解析为整数，找出其中的最大值。
//时间复杂度：O(1)
//空间复杂度：O(1) 
        public int MaxGoodNumber(int[] nums)
        {
            // 获取 nums 的所有排列
            var permutations = new int[][]
            {
            new int[] { nums[0], nums[1], nums[2] },
            new int[] { nums[0], nums[2], nums[1] },
            new int[] { nums[1], nums[0], nums[2] },
            new int[] { nums[1], nums[2], nums[0] },
            new int[] { nums[2], nums[0], nums[1] },
            new int[] { nums[2], nums[1], nums[0] }
            };

            int maxValue = 0;
            // 遍历每种排列方式
            foreach (var perm in permutations)
            {
                // 拼接二进制表示的字符串
                string binaryConcat = string.Join("", perm.Select(n => Convert.ToString(n, 2)));
                // 将拼接的二进制字符串转换为整数
                int value = Convert.ToInt32(binaryConcat, 2);
                // 记录最大值
                maxValue = Math.Max(maxValue, value);
            }

            return maxValue;
        }