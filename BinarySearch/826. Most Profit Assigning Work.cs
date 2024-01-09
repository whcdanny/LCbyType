//Leetcode 826. Most Profit Assigning Work med
//题意：有一组工作，每个工作都有一个利润和一个难度。给定一组工人，每个工人有一定的能力。每个工人只能完成难度不超过他能力的工作，并且每项工作只能由一个工人完成。任务是分配工作，使得总利润最大。
//思路：二分搜索找将工作按难度排序：将工作按照难度从小到大进行排序。
//按工人能力从小到大分配工作：遍历工人，按照他们的能力从小到大分配工作。对于每个工人，从已排序的工作中找到难度不超过他能力的最大利润工作，并将该工作分配给他。使用二分搜索来找到难度不超过工人能力的最大利润工作。
//计算总利润：统计所有分配的工作的总利润。
//注：因为我们求总利润最大，有一种可能难度低但是收益高，也就是说一个工人水平很高可以做很难的工作但是收益很低，所以我们我们在按照难度排序后的工作数组中更新其最大利润为前一个工作的最大利润和当前工作的利润中的较大值；
//时间复杂度:O(NlogN) 
//空间复杂度：O(n)。
        public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            int n = difficulty.Length;
            (int, int)[] jobs = new (int, int)[n];
            for (int i = 0; i < n; i++)
            {
                jobs[i] = (difficulty[i], profit[i]);
            }

            Array.Sort(jobs);
            Array.Sort(worker);
            //因为我们求总利润最大，有一种可能难度低但是收益高，也就是说一个工人水平很高可以做很难的工作但是收益很低，所以我们我们在按照难度排序后的工作数组中更新其最大利润为前一个工作的最大利润和当前工作的利润中的较大值；
            for (int i = 1; i < profit.Length; i++)
            {
                jobs[i].Item2 = Math.Max(jobs[i - 1].Item2, jobs[i].Item2);
            }
            int ans = 0;
            foreach (int ability in worker)
            {
                ans += binarySearch_MaxProfitAssignment(jobs, ability);                
            }
            return ans;
        }

        private int binarySearch_MaxProfitAssignment((int, int)[] jobs, int ability)
        {
            int left = 0, right = jobs.Length- 1;

            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (ability >= jobs[mid].Item1)
                {
                    result = mid;
                    left = mid + 1;
                }
                else right = mid - 1;
            }

            if (result != -1)
            {
                return jobs[result].Item2;
            }

            return 0;
        }