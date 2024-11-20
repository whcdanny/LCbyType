//Leetcode 3075. Maximize Happiness of Selected Children med
//题目：你有一个长度为 n 的数组 happiness，以及一个正整数 k。
//数组表示 n 个小朋友的快乐值，第 i 个小朋友的快乐值为 happiness[i]。
//这些小朋友排成一排，你需要在 k 回合内选择其中的 k 个小朋友。
//每当你选择一个小朋友时，剩下未被选择的小朋友的快乐值会减少 1（如果快乐值是正数）。
//注意：
//快乐值不能小于 0。
//目标是通过巧妙的选择，最大化被选中的 k 个小朋友的快乐值总和。
//你需要返回通过选择 k 个小朋友所能获得的最大快乐值总和。
//思路: 先把happiness从高到低排序，
//然后从最高值开始，然后选择int selected = happiness[i] - i;
//快乐值不能小于 0 所以selected > 0才可以加入到最后res
//时间复杂度：O(nlogn)
//空间复杂度：O(d)
        public long MaximumHappinessSum(int[] happiness, int k)
        {
            Array.Sort(happiness, (a, b) => b - a); // Sort in descending order
            
            long totalHappySum = 0;

            for (int i = 0; i < k && i < happiness.Length; i++)
            {
                int selected = happiness[i] - i;
                if (selected > 0)
                {
                    totalHappySum += selected;                    
                }
            }

            return totalHappySum;
        }