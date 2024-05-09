//Leetcode 3049. Earliest Second to Mark Indices II hard
//题意：这道题给出了两个长度分别为n和m的数组nums和changeIndices。初始时，nums中的所有索引都未标记。你的任务是标记nums中的所有索引。
//在每一秒钟s，从1到m（包括m），你可以执行以下操作之一：
//选择范围在[1, n] 之间的索引i，并将nums[i] 减1。
//将nums[changeIndices[s]] 设置为任意非负值。
//选择范围在[1, n] 之间的索引i，其中nums[i] 等于0，并标记索引i。
//什么都不做。
//返回一个整数，表示通过选择操作最优地标记所有nums中的索引所需的最早秒数，或者如果不可能，则返回-1。
//思路：二分搜索法 首先，容易看出此题的答案具有单调性。时间越长，就越容易有清零的机会，也就越容易实现目标。所以我们在最外层套用二分搜值的框架，将求“最优解”的问题，转化为判定“可行解”的问题。
//假设给出T秒的时刻，如何判定是否可行呢？我们发现，“清零”操作的性价比是非常高的，
//如果对于某个index有机会做“清零”操作，我们必然这样做（除非nums[idx] 本身就是零）。
//如果对于某个index，它在时间序列里出现了多次，尽早清零是最优的选择，因为如果你晚些时候去做清零操作，可能存在一个风险：后续没有足够的机会取做“标记”操作了。
//其余的时候基本首选就是做“减一”，而唯一的制约因素就是要在最后留有足够“标记”的机会。
//当然并不是无脑的选最后n秒都做“标记”，因为有些“清零”可能在很靠后的时刻才会发生。
//我们维护一个resets，里面存放那些确定要进行清零操作的nums的数值。
//当我们从后往前遍历的时候，判定时刻i是否能够进行“清零”，有以下两个条件：
//1.时刻i本身正是之前已经“计划”进行清零的时刻。
//2.假设i时刻进行清零的话，要保证在剩余的[i:t] 的时间里，进行清零的数量（即resets里面的元素个数）要小于剩余时间的一半，这样才能保证这些被清零的元素有机会被“标记”。
//如果不满足条件，这意味着我们不能增加这个清零名额，但是可以“调换”一个清零名额，将resets里面腾出一个来转给当前的index做清零。
//这是因为也许可以减少“减一”操作的次数。
//假设当前时刻的元素如果做清零的话效果是-5，而resets里面有一个元素做清零其效果是-3，那么显然我们需要将resets里面做清零的元素拿出来留给当前元素。这叫做“反悔贪心”。
//最终从后往前走完一遍之后，我们就知道哪些元素是真正需要被实施“清零”的。
//刨去这些之外，最后的n个时刻显然就是做“标记”操作的。这个安排保证了所有被清零的元素都能够得到“标记”。
//剩下的时刻就是应该做“减一”操作：我们必须要求所有“减一”操作的效果，加上“清零”操作的效果，最终一定是要大于nums里元素的总和。满足这些之后，才能判定目标在时间t内可行。
//时间复杂度：O(m+n)
//空间复杂度：O(m+n)
        int n_EarliestSecondToMarkIndices;
        int m_EarliestSecondToMarkIndices;
        public int EarliestSecondToMarkIndices(int[] nums, int[] changeIndices)
        {
            n_EarliestSecondToMarkIndices = nums.Length;
            m_EarliestSecondToMarkIndices = changeIndices.Length;
            int[] newNums = new int[n_EarliestSecondToMarkIndices+1];
            newNums[0] = 0;
            int index = 1;
            foreach (int num in nums)
                newNums[index++] = num;
            int[] newChangeIndices = new int[m_EarliestSecondToMarkIndices + 1];
            newChangeIndices[0] = 0;
            index = 1;
            foreach (int changeIndice in changeIndices)
                newChangeIndices[index++] = changeIndice;

            int left = 1, right = m_EarliestSecondToMarkIndices;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (isOK_EarliestSecondToMarkIndices(mid, newNums, newChangeIndices))
                    right = mid;
                else
                    left = mid + 1;
            }
            if (!isOK_EarliestSecondToMarkIndices(left, newNums, newChangeIndices))
                return -1;
            else
                return left;
        }

        private bool isOK_EarliestSecondToMarkIndices(int t, int[] nums, int[] changeIndices)
        {
            if (t < n_EarliestSecondToMarkIndices)
                return false;
            int[] first = new int[n_EarliestSecondToMarkIndices+1];
            Array.Fill(first, 0);
            
            for(int i = 1; i <= t; i++)
            {
                //如果当前第一次找到这个数，并且注意这个nums没有被清零；标记位置；
                if (first[changeIndices[i]] == 0 && nums[changeIndices[i]]!=0)
                    first[changeIndices[i]] = i;
                //忽略那些无关紧要的=0；
                else
                    changeIndices[i] = 0;
            }
            long total = 0;
            foreach (int num in nums)
                total += (long)num;
            //存放那些确定要进行清零操作的nums的数值
            List<int> resets = new List<int>(); ;
            for(int i = t; i >= 1; i--)
            {
                int idx = changeIndices[i];
                //无关紧要的，要么是mark，要么是-1的；
                if (idx == 0)
                    continue;
                //剩下的时间里，可以用来mark的时间
                int marks = (t - i + 1) - (resets.Count + 1);
                //完成不了mark，所以添加现在的，移除最小的；
                if (resets.Count + 1 > marks)
                {
                    resets.Add(nums[idx]);
                    resets.Sort();
                    resets.Remove(resets[0]);
                }
                else
                {
                    resets.Add(nums[idx]);
                    resets.Sort();
                }
            }
            long totalClear = 0;
            foreach (int x in resets)
                totalClear += x;
            //总共移除的，和-1的的时刻（猜测的时间-mark的时间-reset的时间）
            return totalClear + (t - n_EarliestSecondToMarkIndices - resets.Count) >= total;
        }