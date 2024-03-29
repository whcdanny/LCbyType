//Leetcode 2963. Count the Number of Good Partitions hard
//题意：给定一个包含正整数的数组 nums，要求将数组分割成一个或多个连续子数组，使得每个子数组中的数字各不相同。
//求满足条件的分割方式的总数，结果需要对 10^9 + 7 取模。
//思路：hashtable, 因为要求分组子数组中数字不同，这样要找出每个数字最后出现的位置；
//currentStart 从头开始找位置，previousEnd 根据当前位置 找到最大的出现的位置，Math.Max(previousEnd, lastOccurrence[nums[currentStart]]);
//如果currentStart > previousEnd，说明当前位置之前的数字，不会在当前位置之和出现了，那么就可以分成两个有效的子数组，所以*2；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int NumberOfGoodPartitions(int[] nums)
        {
            const int MOD = 1000000007;
            int totalPartitions = 1;
            int arraySize = nums.Length;
            Dictionary<int, int> lastOccurrence = new Dictionary<int, int>();

            //找到每个数最后一次出现在nums的位置；
            for (int i = 0; i < arraySize; ++i)
            {
                lastOccurrence[nums[i]] = i;
            }

            int currentStart = 0, previousEnd = 0;
            //从左到右迭代，
            while (currentStart < arraySize)
            {
                // If there is a repeating element, double the total number of partitions
                totalPartitions = (currentStart > previousEnd) ? (int)((long)totalPartitions * 2 % MOD) : totalPartitions;

                // Update the rightmost index of the current element
                previousEnd = Math.Max(previousEnd, lastOccurrence[nums[currentStart]]);
                currentStart += 1;
            }

            return totalPartitions;
        }