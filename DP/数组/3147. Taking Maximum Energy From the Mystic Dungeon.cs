//Leetcode 3147. Taking Maximum Energy From the Mystic Dungeon med
//题目：在一个神秘的地牢中，有 n 个魔法师站成一排。
//每个魔法师拥有一个属性，会给予你能量。部分魔法师的能量值可能是负数，表示他们会消耗你的能量。
//你被诅咒了，每当从魔法师 i 吸收能量后，你会被立即传送到魔法师(i + k)。这个过程会一直重复，直到传送超出魔法师序列的长度。
//换句话说，你可以选择一个起点开始，然后每次跳跃 k 个位置，直到到达队列末尾，并在整个过程中吸收所有经过的魔法师的能量。
//给定一个数组 energy 和一个整数 k，返回你能够获得的最大能量值。
//思路: 动态规划：
//使用一个数组 dp，其中 dp[i] 表示从第 i 个魔法师开始的最大能量值。
//逆序遍历：因为逆向遍历可以更方便地从后往前累积跳跃带来的最大能量。
//填充 dp：i + k 小于 n，则 dp[i] = energy[i] + dp[i + k]；否则，dp[i] = energy[i]。
//遍历 dp 数组，找到其中的最大值即为答案
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MaximumEnergy(int[] energy, int k)
        {
            int n = energy.Length;
            int[] dp = new int[n];

            // 从后往前填充 dp 数组
            for (int i = n - 1; i >= 0; i--)
            {
                if (i + k < n)
                {
                    dp[i] = energy[i] + dp[i + k];
                }
                else
                {
                    dp[i] = energy[i];
                }
            }

            // 找出 dp 数组中的最大值
            int maxEnergy = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                maxEnergy = Math.Max(maxEnergy, dp[i]);
            }

            return maxEnergy;
        }