//Leetcode 3281. Maximize Score of Numbers in Ranges med
//题目：给定一个整数数组 start 和一个整数 d，表示 n 个区间 [start[i], start[i] + d]。
//你需要选择 n 个整数，其中第 i 个整数必须在第 i 个区间中。选择的这些整数的得分定义为任意两个被选整数之间的最小绝对差值。
//思路: 二分搜索，
//逻辑是先把start排序，然后最大的值+d，然后用二分搜索，答案肯定在0-最大的值
//如果当前值+二分的猜测值如果大于下一个值+d，这个猜测值不行，
//如这个[猜测值]可以，那么就看[下一个start值]是否超过[当前值+猜测值]
//如果大于[当前值]就是[下一个start值], 如果不是那就是[当前值+猜测值]
//时间复杂度：O(n log n + n log(maxVal)) O(n log n)，其中 n 是数组的长度。O(log(maxVal))，maxVal 是可能的最大最小绝对差.checkMaxDiff 函数的时间复杂度：O(n)
//空间复杂度：O(1)
        public int MaxPossibleScore(int[] start, int d)
        {
            Array.Sort(start);
            int left = 0, right = start[start.Length - 1] + d;
            while (left < right)
            {
                int mid = left + (right - left + 1) / 2;
                if (CheckMaxDiff(start, d, mid))
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;
        }
        
        private bool CheckMaxDiff(int[] vals, int d, int diff)
        {
            long last = vals[0];
            for (int i = 1; i < vals.Length; i++)
            {
                if (last + (long)diff > vals[i] + d)
                    return false;
                if (vals[i] > last + (long)diff)
                    last = vals[i];
                else
                    last = last + diff;
            }
            return true;
        }