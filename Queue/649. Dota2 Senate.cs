//649. Dota2 Senate med
//题意：在 Dota2 的世界中，有两个派系：Radiant 和 Dire。
//Dota2 议会由来自两个派系的议员组成。现在议会要对游戏的改动进行投票。
//投票采用回合制，每位议员可以在每轮中执行以下两种权利之一：
//禁止某议员的权利：某议员可以让另一议员在当前和所有后续回合中失去投票权。
//宣布胜利：如果某议员发现所有仍有投票权的议员都来自同一派系，则可以宣布胜利并决定游戏的改动。
//给定一个字符串 senate，表示每位议员的派系归属。字符 'R' 和 'D' 分别代表 Radiant 和 Dire。
//投票按照字符串的顺序进行，每轮从头到尾进行。所有失去投票权的议员将在后续投票中被跳过。
//假设每位议员都足够聪明，并会采取对其派系最有利的策略。
//预测最后哪个派系将宣布胜利，返回结果为 "Radiant" 或 "Dire"。 
//思路：模拟整个投票过程：
//使用两个队列分别存储 R 和 D 的索引位置。
//每轮投票中，当前在 R 和 D 的第一个议员比较其索引大小：
//索引较小的议员可以投票禁止另一方的权利，同时将自己加入下一轮。
//索引较大的议员失去权利，不再参与后续投票。
//利用循环队列：
//索引较小的一方进入下一轮时，其索引需要加上 n（总人数），表示它将在下一轮的末尾出现。
//结束条件：
//当某一队列为空时，另一队列即为获胜方。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public string PredictPartyVictory(string senate)
        {
            int n = senate.Length;
            Queue<int> radiantQueue = new Queue<int>();
            Queue<int> direQueue = new Queue<int>();

            // 将议员按其派系加入对应队列
            for (int i = 0; i < n; i++)
            {
                if (senate[i] == 'R')
                    radiantQueue.Enqueue(i);
                else
                    direQueue.Enqueue(i);
            }

            // 模拟投票过程
            while (radiantQueue.Count > 0 && direQueue.Count > 0)
            {
                int radiantIndex = radiantQueue.Dequeue();
                int direIndex = direQueue.Dequeue();

                if (radiantIndex < direIndex)
                {
                    // Radiant 禁止 Dire，Radiant 加入下一轮
                    radiantQueue.Enqueue(radiantIndex + n);
                }
                else
                {
                    // Dire 禁止 Radiant，Dire 加入下一轮
                    direQueue.Enqueue(direIndex + n);
                }
            }

            // 判断胜利方
            return radiantQueue.Count > 0 ? "Radiant" : "Dire";
        }