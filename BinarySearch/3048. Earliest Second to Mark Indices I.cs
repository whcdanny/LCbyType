//Leetcode 3048. Earliest Second to Mark Indices I med
//题意：这道题给出了两个长度分别为n和m的数组nums和changeIndices。初始时，nums中的所有索引都未标记。你的任务是标记nums中的所有索引。
//在每一秒钟s，从1到m（包括m），你可以执行以下操作之一：
//选择范围在[1, n] 之间的索引i，并将nums[i] 减1。
//如果nums[changeIndices[s]] 等于0，则标记索引changeIndices[s]。
//什么都不做。
//返回一个整数，表示通过选择操作最优地标记所有nums中的索引所需的最早秒数，或者如果不可能，则返回-1。
//思路：二分搜索法 存在单调性，肯定时间越多的话，越有机会将所有元素都清零并标记。由此我们考虑尝试二分搜值。二分法的优点是，不用直接求“最优解”，而是转化为判定“可行解”，难度上会小很多。
//在给定时间s的情况下，问能否将所有元素都清零并标记。
//对于一个给定的index而言，我们必须在对其“标记”前完成清零，因此我们肯定会将“标记”操作尽量延后，方便腾出更多时间做减一的操作。
//显然，我们会贪心地将index最后一次出现的时刻做“标记”操作；
//而如果index出现了不止一次多次，那么除了在最后一次的时刻做“标记”外，其余的时刻都会留作做“减一”操作（但不一定针对nums[idx]）。
//为了顺利能够在最后一次index出现的时候做标记，我们需要保证之前积累的“减一”操作足够多，能够大于等于nums[idx] 即可。
//于是我们只要顺着index出现的顺序，模拟上述的操作：要么积累“减一”操作count（如果不是最后一个出现），要么进行“标记”操作（如果是最后一次操作）。
//对于后者，能进行“标记”操作的前提是已经对那个index的数进行多次减一至零，故要求count>=nums[idx].
//如果能够顺利地走完changeIndices[1:s]、并且将所有的nums都完成“标记”的话，就说明s秒能够实现目标。
//时间复杂度：O(NLognLogn)
//空间复杂度：O(m+n)
		int n_EarliestSecondToMarkIndices;
        int m_EarliestSecondToMarkIndices;
        public int EarliestSecondToMarkIndices(int[] nums, int[] changeIndices)
        {
            n_EarliestSecondToMarkIndices = nums.Length;
            m_EarliestSecondToMarkIndices = changeIndices.Length;
            int[] newNums = new int[n_EarliestSecondToMarkIndices + 1];
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
                if (isOK_EarliestSecondToMarkIndices1(mid, newNums, newChangeIndices))
                    right = mid;
                else
                    left = mid + 1;
            }
            if (!isOK_EarliestSecondToMarkIndices1(left, newNums, newChangeIndices))
                return -1;
            else
                return left;
        }
        private bool isOK_EarliestSecondToMarkIndices1(int t, int[] nums, int[] changeIndices)
        {
            
            int[] last = new int[n_EarliestSecondToMarkIndices + 1];            
            //找到t时间内最后出现的位置；
            for (int i = 1; i <= t; i++)
            {
                last[changeIndices[i]] = i;
            }
            //保证每个index被清零；
            //因为有可能在t时间内，有的index没有出现；
            for(int i = 1; i <= n_EarliestSecondToMarkIndices; i++)
            {
                if (last[i] == 0)
                    return false;
            }
            //统计-1的操作的次数；
            int count = 0;
            for(int i = 1; i <= t; i++)
            {
                //找到当前位置
                int index = changeIndices[i];
                //是否最后出现
                if (i != last[index])
                {
                    //保留作为-1操作；
                    count++;
                }
                else
                {
                    //最后一次出现，并标记mark；                    
                    count -= nums[index];
                    //如果小于零说明不能完成mark操作；
                    if (count < 0)
                        return false;
                }
            }
            return true;
        }