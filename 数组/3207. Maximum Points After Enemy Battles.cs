//Leetcode 3207. Maximum Points After Enemy Battles med
//题目：给定一个整数数组 enemyEnergies，表示敌人拥有的能量值，以及一个整数 currentEnergy 表示初始能量。
//你初始得分为 0，且所有敌人都处于未标记状态。你可以通过以下两种操作获得分数：
//获得分数：选择一个未标记的敌人 i，且满足 currentEnergy >= enemyEnergies[i]。你可以获得 1 分，并减少 enemyEnergies[i] 的能量值。
//恢复能量：如果当前分数至少为 1，可以选择一个未标记的敌人 i，通过消耗 1 分恢复 enemyEnergies[i] 的能量值。
//最终目标是通过合理的操作顺序，获得尽可能高的分数。
//思路: 先给enemenergies排序，然后如果 currentEnergy 小于敌人能量最小值 enemyEnergies[0]，说明无法击败任何敌人、
//从击败第一个人开始，剩下的能量都是添加到currentEnergy，然后看能击败最小能量的敌人多少次
//因为可以重复去添加能量直到所有敌人都mark，所以只要重复去击败最小能量的敌人就是最高分
//时间复杂度：O(n)
//空间复杂度：O(1)
        public long MaximumPoints(int[] enemyEnergies, int currentEnergy)
        {
            int len = enemyEnergies.Length;
            long points = 0L;
            if (len == 1)
                return currentEnergy / enemyEnergies[0];
            //将 enemyEnergies 按照从小到大排序，以确保可以优先击败能量较低的敌人
            Array.Sort(enemyEnergies);
            //如果 currentEnergy 小于敌人能量最小值 enemyEnergies[0]，说明无法击败任何敌人
            if (enemyEnergies[0] > currentEnergy)
                return points;

            long sum = currentEnergy - enemyEnergies[0];
            points += 1;
            //在初始击败一个敌人后，累积其他敌人能量，用于计算接下来的击败次数
            for (int i = 1; i < len; i++)
            {
                sum += enemyEnergies[i];
            }
            //计算在最小敌人能量值的基础上，利用累积的能量能够击败多少次最小能量敌人
            points += (sum / enemyEnergies[0]);
            return points;
        }