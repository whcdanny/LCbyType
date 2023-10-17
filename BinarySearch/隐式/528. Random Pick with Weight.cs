//Leetcode 528. Random Pick with Weight med
//题意：要求设计一个数据结构，支持以下两种操作：RandomPickWithWeight(int[] w)：给定一个正整数数组 w，其中 w[i] 表示第 i 个元素的权重。根据权重随机返回一个元素的索引。Reset()：将数据结构重置为初始状态。
//思路：二分法: 是给一个数组w，数组里面的数组表示它的比重，PickIndex是从给入的数组中随机抽取并显示抽取数字的位置；所以随机出现i的概率是：w[i] / sum(w).相当于给的数组[1，3，2，1]可以转换成前缀之和[0，1，4，6，7] 可以理解成随机的数字在[0-7]之间如果出现[0,1]是给入数组位置1，[1，4]之间是给入数组位置2；这样就用到了前缀数组和二分搜索里的左侧边界
//时间复杂度: n 是权重数组的长度, O(logn)
//空间复杂度： O(n)    
        public class Solution
        {
            // 前缀和数组
            private int[] preSum;
            private Random rand = new Random();
            public Solution(int[] w)
            {
                int n = w.Length;
                // 构建前缀和数组，偏移一位留给 preSum[0]
                preSum = new int[n + 1];
                preSum[0] = 0;
                // preSum[i] = sum(w[0..i-1])
                for (int i = 1; i <= n; i++)
                {
                    preSum[i] = preSum[i - 1] + w[i - 1];
                }
            }

            public int PickIndex()
            {
                int n = preSum.Length;
                // C# 的 Next(n) 方法在 [0, n) 中生成一个随机整数
                // 再加一就是在闭区间 [1, preSum[n - 1]] 中随机选择一个数字
                int target = rand.Next(preSum[n - 1]) + 1;
                // 获取 target 在前缀和数组 preSum 中的索引
                // 别忘了前缀和数组 preSum 和原始数组 w 有一位索引偏移
                return left_bound(preSum, target) - 1;
            }
            public int left_bound(int[] nums, int target)
            {
                if (nums.Length == 0) return -1;
                int left = 0, right = nums.Length;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] == target)
                    {
                        right = mid;
                    }
                    else if (nums[mid] < target)
                    {
                        left = mid + 1;
                    }
                    else if (nums[mid] > target)
                    {
                        right = mid;
                    }
                }
                return left;
            }
        }

        /**
         * Your Solution object will be instantiated and called as such:
         * Solution obj = new Solution(w);
         * int param_1 = obj.PickIndex();
         */