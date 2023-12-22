//Leetcode 2358. Maximum Number of Groups Entering a Competition med
//题意：给定一个表示学生成绩的正整数数组 grades，希望将学生以有序的非空分组的方式参加比赛。分组的顺序需要满足以下条件：
//第 i 组学生的成绩之和小于第(i + 1) 组学生的成绩之和（对于所有组，除了最后一组）。
//第 i 组学生的总人数小于第(i + 1) 组学生的总人数（对于所有组，除了最后一组）。
//要求返回可以形成的最大分组数。
//思路：二分搜索，对所有成绩进行排序，然后用等差数列求和的公式来计算S = (n*n+1)/2;
//将 1 名学生分配到第一组，
//将 2 名学生分配到第二组...
//这可以满足ith group<i+1th group 的大小和总和。
//注：所以我们需要找出最大的k结果1 + 2 + ... + k <= n
//时间复杂度: O(log(n))
//空间复杂度：O(1)
        public int MaximumGroups(int[] grades)
        {
            int n = grades.Length;

            long low = 1;
            long high = n;


            while (low <= high)
            {
                long mid = low + (high - low) / 2;
                long sum = ((mid + 1) * mid) / 2;
                if (sum > n)
                {
                    high = mid - 1;
                }
                else if (sum < n)
                {
                    low = mid + 1;
                }
                else
                {
                    return (int)mid;
                }
            }
            return (int)high;
        }