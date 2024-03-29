//Leetcode 128. Longest Consecutive Sequence med
//题意：给定一个未排序的整数数组，找出最长连续序列的长度。        
//思路：HashSet中，以便快速判断一个元素是否在数组中
//时间复杂度：遍历数组需要 O(n) 的时间，对于每个元素，可能需要向前和向后扩展，最坏情况下需要 O(n) 的时间。因此总的时间复杂度是 O(n^2)。
//空间复杂度：O(n)
        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);
            int longestStreak = 0;

            foreach (int num in set)
            {
                // 如果当前数是序列的起点
                if (!set.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    // 继续检查下一个数是否存在于哈希集合中
                    while (set.Contains(currentNum + 1))
                    {
                        currentNum += 1;
                        currentStreak += 1;
                    }

                    // 更新最长连续序列的长度
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }

            return longestStreak;
        }