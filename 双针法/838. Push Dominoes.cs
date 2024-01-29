//Leetcode 838. Push Dominoes med
//题意：有 n 个多米诺骨牌在一条直线上，每个多米诺骨牌初始时垂直放置。一开始，我们同时将一些多米诺骨牌向左或向右推动。
//每秒钟，向左倒下的多米诺骨牌会推动左边相邻的多米诺骨牌。同样，向右倒下的多米诺骨牌会推动右边相邻的多米诺骨牌。
//当一个垂直的多米诺骨牌同时受到来自左边和右边的多米诺骨牌的推动时，由于力的平衡，它会保持静止。
//对于这个问题，我们假设一个倒下的多米诺骨牌对于一个已经倒下或者正在倒下的多米诺骨牌不会产生额外的力。    
//给定一个表示初始状态的字符串 dominoes：
//dominoes[i] = 'L'，表示第 i 个多米诺骨牌被推到左边。
//dominoes[i] = 'R'，表示第 i 个多米诺骨牌被推到右边。
//dominoes[i] = '.'，表示第 i 个多米诺骨牌没有被推动。
//要求返回一个表示最终状态的字符串。
//思路：双指针，分别模拟从左到右和从右到左的推倒过程。
//第一次遍历模拟从左到右的推倒，记录每个位置受到的力。
//第二次遍历模拟从右到左的推倒，记录每个位置受到的力。
//最后根据两次推倒的力，构建最终的状态。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public string PushDominoes(string dominoes)
        {
            char[] dominoArray = dominoes.ToCharArray();
            int n = dominoArray.Length;
            int[] forces = new int[n];

            // Left to right pass
            int force = 0;
            for (int i = 0; i < n; i++)
            {
                if (dominoArray[i] == 'R')
                {
                    force = n;
                }
                else if (dominoArray[i] == 'L')
                {
                    force = 0;
                }
                else
                {
                    force = Math.Max(force - 1, 0);
                }
                forces[i] += force;
            }

            // Right to left pass
            force = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (dominoArray[i] == 'L')
                {
                    force = n;
                }
                else if (dominoArray[i] == 'R')
                {
                    force = 0;
                }
                else
                {
                    force = Math.Max(force - 1, 0);
                }
                forces[i] -= force;
            }

            // Build the final state based on the forces
            for (int i = 0; i < n; i++)
            {
                if (forces[i] > 0)
                {
                    dominoArray[i] = 'R';
                }
                else if (forces[i] < 0)
                {
                    dominoArray[i] = 'L';
                }
            }

            return new string(dominoArray);
        }