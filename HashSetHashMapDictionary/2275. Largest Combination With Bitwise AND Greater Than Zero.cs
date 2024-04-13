//Leetcode 2275. Largest Combination With Bitwise AND Greater Than Zero med
//题意：给定一个正整数数组 candidates，要求计算 candidates 中所有数字的所有组合的按位与（bitwise AND）的结果，并返回结果大于 0 的最大组合的大小。
//思路：hashtable 先算出candidate的总和，
//计算共享相同位的整数。这些整数的按位&将是!= 0
//迭代每一位(i)
//计算共享相同位的元素数量i
//跟踪最大计数(result)        
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int LargestCombination(int[] candidates)
        {
            var result = 0;
            var maxElement = candidates.Max();

            for (var i = 1; i <= maxElement; i <<= 1)
            {
                var count = 0;

                foreach (var candidate in candidates)
                {
                    count += (candidate & i) > 0 ? 1 : 0;
                    result = Math.Max(result, count);
                }
            }

            return result;
        }