//128. Longest Consecutive Sequence med
//是一个寻找数组中最长连续序列
//思路：哈希集合来存储数组中的元素，检查下一个数是否存在于哈希集合中，直到找不到下一个数为止，然后找出Max；
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