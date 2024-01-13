//Leetcode 2903. Find Indices With Index and Value Difference I ez
//题意：给定一个长度为 n 的整数数组 nums，以及两个整数 indexDifference 和 valueDifference。要求找到两个索引 i 和 j（0 到 n-1 范围内），满足以下条件：
//abs(i - j) >= indexDifference
//abs(nums[i] - nums[j]) >= valueDifference
//如果存在满足条件的 i 和 j，则返回数组 answer = [i, j]，否则返回数组 answer = [-1, -1]。如果有多种满足条件的 i 和 j，可以返回其中任意一组。
//思路：左右针，两层嵌套循环，遍历所有可能的索引对 i 和 j。 nums[j] 的范围是在 [min, max] 之间,
//注：先通过 min 和 max 的记录，缩小 nums[j] 的可能范围，然后在内层的两个循环中，根据这个范围找到满足条件的 j。这样可以在一定程度上优化遍历的范围，提高效率。
//循环从数组的末尾开始，逐步向前遍历，通过维护 min 和 max，使得每次内层循环的范围都在逐渐收缩，从而达到优化的目的。
//时间复杂度: O(n)，其中 n 为字符串长度。遍历字符串一次，每次操作花费常数时间。
//空间复杂度：O(1)
        public int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
        {
            var min = nums[nums.Length - 1];
            var max = nums[nums.Length - 1];
            for (int i = nums.Length - 1; i >= indexDifference; i--)
            {
                min = Math.Min(min, nums[i]);
                max = Math.Max(max, nums[i]);
                if (Math.Abs(nums[i - indexDifference] - min) >= valueDifference)
                {
                    for (int j = i; j < nums.Length; j++)
                    {
                        if (Math.Abs(nums[i - indexDifference] - nums[j]) >= valueDifference)
                        {
                            return new[] { i - indexDifference, j };
                        }
                    }
                }
                if (Math.Abs(nums[i - indexDifference] - max) >= valueDifference)
                {
                    for (int j = i; j < nums.Length; j++)
                    {
                        if (Math.Abs(nums[i - indexDifference] - nums[j]) >= valueDifference)
                        {
                            return new[] { i - indexDifference, j };
                        }
                    }
                }
            }
            return new[] { -1, -1 };
        }

        public int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
        {
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + indexDifference; j < n; j++)
                {
                    if (Math.Abs(i - j) >= indexDifference && Math.Abs(nums[i] - nums[j]) >= valueDifference)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { -1, -1 };
        }