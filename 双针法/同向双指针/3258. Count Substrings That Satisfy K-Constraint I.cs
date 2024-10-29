//Leetcode 3258. Count Substrings That Satisfy K-Constraint I ez
//题目：给你一个二进制字符串 s 和一个整数 k。一个二进制字符串满足 k-约束，需满足以下任一条件：
//字符串中 0 的数量最多为 k。
//字符串中 1 的数量最多为 k。
//返回满足 k-约束的子字符串数量。
//思路: 双指针，获取所有的子字符串，外层循环用来固定左边界，内层循环用来确定右边界
//判断 0 的数量和 1 的数量是否都不超过 k
//时间复杂度：O(n^2)
//空间复杂度：O(1)
        public int CountKConstraintSubstrings(string s, int k)
        {
            int n = s.Length;
            int result = 0;

            for (int left = 0; left < n; left++)
            {
                int count0 = 0, count1 = 0;
                for (int right = left; right < n; right++)
                {
                    // 更新当前子字符串中的0和1的数量
                    if (s[right] == '0') count0++;
                    else count1++;

                    // 判断是否满足k约束
                    if (count0 <= k || count1 <= k)
                    {
                        result++;
                    }
                    else
                    {
                        // 如果不满足约束，提前终止该子串的探索
                        break;
                    }
                }
            }

            return result;
        }