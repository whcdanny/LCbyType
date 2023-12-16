//Leetcode 2861. Maximum Number of Alloys med
//题意：你是一家制造合金的公司的所有者，使用不同类型的金属。有 n 种不同类型的金属，并且你可以使用 k 台机器来制造合金。每台机器需要一定数量的每种金属来制造一个合金。
//对于第 i 台机器来制造一个合金，它需要 composition[i][j] 个类型 j 的金属单位。最初，你有 stock[i] 个类型 i 的金属，并购买一单位类型 i 的金属需要 cost[i] 个硬币。
//给定整数 n、k、budget、一个从 1 开始索引的二维数组 composition，以及从 1 开始索引的数组 stock 和 cost，你的目标是在预算为 budget 的情况下，最大化公司可以创建的合金数量。
//所有合金必须使用相同的机器来制造。
//返回公司可以创建的最大合金数量。
//思路：二分查找. 对每个机器k开始算，通过二分法将min,max找到，mid就是现在可以制造的产品，计算当前机器对应的不同alloy的个数，然后根据stock更新这个alloy的个数，然后算一个总数；
//然后跟budget做比较，如果大，那么就更新max，如果小就更新min，最后得到的就是最多的产品，然后再求max；
//时间复杂度:  O(logn)
//空间复杂度： O(1)
        public int MaxNumberOfAlloys(int n, int k, int budget, IList<IList<int>> composition, IList<int> stock, IList<int> cost)
        {
            var result = 0;

            for (var i = 0; i < k; i++) // iterate over machines
            {
                long min = 0, max = int.MaxValue - 1; // initialize min and max alloys count 
                while (min < max)
                {
                    var middle = (min + max + 1) / 2; // current number of alloys we try to produce
                    var details = composition[i].Select(x => middle * x).ToArray(); // counting amount of each metal to complete alloy

                    long sum = 0;
                    for (var j = 0; j < n; j++)
                    {
                        details[j] = Math.Max(0, details[j] - stock[j]); // counting amount of each metal needed to pay for
                        sum += (details[j] * cost[j]); // summing up
                    }

                    if (sum <= budget)
                    {
                        min = middle;
                    }
                    else
                    {
                        max = middle - 1;
                    }
                }

                result = (int)Math.Max(result, min); // changing the result
            }

            return result;
        }