//Leetcode 3275. K-th Nearest Obstacle Queries med
//题目：给定一个整数 power，以及两个长度为 n 的整数数组 damage 和 health，分别表示 n 个敌人对 Bob 每秒造成的伤害和他们的生命值。
//Bob 有 n 个敌人，在每一秒，活着的敌人会对 Bob 造成 damage[i] 点的伤害（如果 health[i] > 0）。然后，Bob 选择一个还活着的敌人并对其造成 power 点的伤害。
//求在所有敌人都被消灭之前，Bob 所受到的最小总伤害。
//思路: 创建一个 List<Enemy> 用于存储所有敌人，每个敌人具有以下属性：
//Damage：该敌人对 Bob 每秒造成的伤害。
//Health：该敌人的剩余生命值。
//Priority：用于确定攻击顺序的优先级，计算方式为(damage / hitsNeeded)，其中 hitsNeeded 是击败该敌人所需的攻击次数。
//HitsNeeded：计算 Bob 击败该敌人所需的最小攻击次数，Math.Ceiling(health / power) 向上取整表示完整攻击次数。
//totalDamage 变量表示当前所有敌人对 Bob 造成的总伤害，初始化为所有敌人 damage 的和。
//result 变量用于存储最小总伤害值的累积和。      
//看code
//时间复杂度：O(n log n)，其中 n 是敌人的数量
//空间复杂度：O(n)
        public long MinDamage(int power, int[] damage, int[] health)
        {
            var enemies = new List<Enemy>();
            long totalDamage = 0;
            long result = 0;
            for (int i = 0; i < damage.Length; i++)
            {
                enemies.Add(new Enemy()
                {
                    Damage = damage[i],
                    Health = health[i],
                    Priority = (double)damage[i] / ((long)Math.Ceiling((double)health[i] / power)),
                    HitsNeeded = (int)Math.Ceiling((double)health[i] / power)
                });

                totalDamage += damage[i];
            }
            //根据优先级降序排列敌人，优先处理对 Bob 造成单位时间内最大总伤害的敌人。
            enemies = enemies.OrderByDescending(x => x.Priority).ToList();

            foreach (var enemy in enemies)
            {
                result += totalDamage * enemy.HitsNeeded;//HitsNeeded 秒内所有存活敌人对 Bob 造成的总伤害。
                totalDamage -= enemy.Damage;//在处理完该敌人后，减少 totalDamage 中该敌人对 Bob 的伤害值
            }

            return result;
        }
        public class Enemy
        {
            public long Damage;
            public long Health;
            public double Priority;
            public long HitsNeeded;
        }