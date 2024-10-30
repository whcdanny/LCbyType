//Leetcode 3259. Maximum Energy Boost From Two Drinks med
//题目：给定两个长度相同的整数数组 energyDrinkA 和 energyDrinkB，分别表示能量饮料 A 和 B 在每小时提供的能量提升。
//我们希望通过每小时饮用一种饮料来最大化能量提升。但是，如果从一种饮料切换到另一种饮料，则需要花费 1 小时来净化系统（这一小时不会获得任何能量提升）。
//要求：在未来的 n 小时内，获得的最大能量提升值。
//思路: 动态规划来解决这个问题。
//设 dpA[i] 表示在第 i 小时喝饮料 A 时可以获得的最大能量值，dpB[i] 表示在第 i 小时喝饮料 B 时可以获得的最大能量值。
//初始状态：
//dpA[0] = energyDrinkA[0]：如果第 0 小时选择喝饮料 A，则获得的能量为 energyDrinkA[0]。
//dpB[0] = energyDrinkB[0]：如果第 0 小时选择喝饮料 B，则获得的能量为 energyDrinkB[0]。
//状态转移方程：
//对于第 i 小时：
//如果第 i 小时喝饮料 A，可以从以下两种情况转移过来：
//从上小时继续喝 A：dpA[i] = dpA[i - 1] + energyDrinkA[i]
//上小时喝的是 B（需要等待净化一小时）：dpA[i] = Math.Max(dpA[i], dpB[i - 1])
//如果第 i 小时喝饮料 B，同理：
//从上小时继续喝 B：dpB[i] = dpB[i - 1] + energyDrinkB[i]
//上小时喝的是 A：dpB[i] = Math.Max(dpB[i], dpA[i - 1])
//返回结果：最后一小时的最大能量值即为 Math.Max(dpA[n - 1], dpB[n - 1])。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public long MaxEnergyBoost(int[] energyDrinkA, int[] energyDrinkB)
        {
            int n = energyDrinkA.Length;
            long[] dpA = new long[n];
            long[] dpB = new long[n];

            dpA[0] = energyDrinkA[0];
            dpB[0] = energyDrinkB[0];

            for (int i = 1; i < n; i++)
            {
                dpA[i] = Math.Max(dpA[i - 1] + (long)energyDrinkA[i], dpB[i - 1]);
                dpB[i] = Math.Max(dpB[i - 1] + (long)energyDrinkB[i], dpA[i - 1]);
            }

            return Math.Max(dpA[n - 1], dpB[n - 1]);
        }