//Leetcode 2491. Divide Players Into Teams of Equal Skill med
//题意：给定一个正整数数组 skill，长度为偶数 n，其中 skill[i] 表示第 i 个玩家的技能。将玩家分成 n / 2 支球队，每支球队有 2 个玩家，使得每支球队的总技能相等。
//球队的化学值等于该球队上球员技能的乘积。
//返回所有球队的化学值之和，如果无法将玩家分成总技能相等的球队，则返回 -1。
//思路：左右针，对数组进行排序，然后不断地将当前最弱的玩家与当前最强的玩家进行匹配。如果您无法将他们匹配以使他们的技能总和等于目标总和，则返回 -1
//定义了一个长的 targSum，它是第一个最弱的玩家 (skill[0]) 和第一个最强的玩家 (skill[长度 - 1]）。
//询问 Skill[l] + Skill[r] 之和是否等于 targSum。如果不是，则返回-1。如果是，则将 currTotal 增加 Skill[l] * Skill[r] 并l++,r--。
//时间复杂度: O(n∗log(n))
//空间复杂度：O(1)
        public long DividePlayers(int[] skill)
        {
            Array.Sort(skill);
            int left = 1, right = skill.Length - 2;
            long targSum = skill[0] + skill[skill.Length-1];
            long currTotal = skill[0] * skill[skill.Length - 1];


            while (left < right)
            {
                if ((long)skill[left] + skill[right] != targSum) return -1;
                else currTotal += skill[left++] * skill[right--];
            }
            return currTotal;

        }