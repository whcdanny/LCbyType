//Leetcode 2611. Mice and Cheese med
//题意：有两只老鼠和n种不同的奶酪，每种奶酪应该被一只老鼠吃掉。每个奶酪点的索引i（从0开始）有两个奖励值：
//如果第一只老鼠吃掉它，奖励是reward1[i]。
//如果第二只老鼠吃掉它，奖励是reward2[i]。
//给定正整数数组reward1，正整数数组reward2，和非负整数k，要求返回在第一只老鼠吃掉恰好k种奶酪的情况下，老鼠们能够获得的最大奖励点数。
//思路：PriorityQueue    
//用PriorityQueue 存入reward1[i] - reward2[i]差，相当于差值越小，表示第二个老鼠吃的话奖励越多，
//所以这里是 maximumPoints -= minHeapDifferenceInRewards.Dequeue();
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MiceAndCheese(int[] reward1, int[] reward2, int k)
        {
            int maximumPoints = 0;
            int totalTypesOfCheese = reward1.Length;
            PriorityQueue<int, int> minHeapDifferenceInRewards = new PriorityQueue<int, int>();

            for (int i = 0; i < totalTypesOfCheese; ++i)
            {
                maximumPoints += reward1[i];
                minHeapDifferenceInRewards.Enqueue(reward1[i] - reward2[i], reward1[i] - reward2[i]);
                if (minHeapDifferenceInRewards.Count > k)
                {
                    maximumPoints -= minHeapDifferenceInRewards.Dequeue();
                }
            }

            return maximumPoints;
        }
//思路：排序的，把reward1[i] - reward2[i]从最大到k的差 加入到reward2总和
//因为总共要吃所有的cheese，那么只要第一只老鼠吃掉差值最大的k个，也就是说其余的都是第二个老鼠奖励多的；
//时间复杂度：O(n∗log(n))
//空间复杂度：O(n)
        public int MiceAndCheese1(int[] reward1, int[] reward2, int k)
        {
            int maximumPoints = 0;
            int totalTypesOfCheese = reward1.Length;
            int[] differenceInRewards = new int[totalTypesOfCheese];

            for (int i = 0; i < totalTypesOfCheese; ++i)
            {
                differenceInRewards[i] = reward1[i] - reward2[i];
                maximumPoints += reward2[i];
            }
            Array.Sort(differenceInRewards);

            for (int i = totalTypesOfCheese - 1; i > totalTypesOfCheese - k - 1; --i)
            {
                maximumPoints += differenceInRewards[i];
            }

            return maximumPoints;
        }