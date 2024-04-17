//Leetcode 2025. Maximum Number of Ways to Partition an Array hard
//题意：给定一个长度为 n 的整数数组 nums。对数组进行划分的方式取决于满足以下两个条件的枢轴索引的数量：
//1 <= pivot<n
//nums[0] + nums[1] + ... + nums[pivot - 1] == nums[pivot] + nums[pivot + 1] + ... + nums[n - 1]
//同时，给定一个整数 k。你可以选择将 nums 中的一个元素的值更改为 k，或者保持数组不变。
//要求：在改变至多一个元素的情况下，返回满足上述两个条件的最大可能的数组划分数量。
//思路：hashtable 就是查看哪些presum等于sum/2，用Hash统计一下即可。
//如果我们对nums[i] 做了变动，那么就有new_sum = sum + d其中d = k-nums[i]. 
//此时我们想要看的是更新后的new_presum里有多少等于new_sum/2。
//但是如果把所有的new_presum都计算一遍，需要o(N)的操作，很不合算。此时我们发现，在i之前的那些presum其实是没有变化的，
//即new_presum = presum。也就是说，如果有合法的切分点位于i之前，那么我们只需要在之前的presum里查看一下即可。
//如果有合法的切分点位于i之后，我们还是得查看new_presum 此时我们转念一下，在这种情况下，切分点后面的sufsum数列其实没有改变。
//如果有sufsum等于new_sum/2，那么同样意味着整个数组可以等分为两半。
//算法很简单：预先计算presum和sufsum。
//遍历改动的位置nums[i]，在i之前查看有多少presum等于new_sum/2，
//再在i之后查看有多少sufsum等于new_sum/2. 这两部分方案数之和就是这次改动能够成立的partition方法。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int WaysToPartition(int[] nums, int k)
        {
            int n = nums.Length;
            long sum = 0;
            foreach (int num in nums)
            {
                sum += (long)num;
            }
            long[] res = new long[n];

            long[] pre = new long[n];
            pre[0] = nums[0];
            for (int i = 1; i < n; i++)
                pre[i] = pre[i - 1] + nums[i];
            Dictionary<long, long> count = new Dictionary<long, long>();//presum -> freq
            for (int i = 0; i < n; i++)
            {
                long newSum = (long)(sum + k - nums[i]);
                if (newSum % 2 == 0)
                    res[i] += count.GetValueOrDefault(newSum / 2);
                count[pre[i]] = count.GetValueOrDefault(pre[i]) + 1;
            }

            long[] suf = new long[n];
            suf[n - 1] = nums[n - 1];
            for (int i = n - 2; i >= 0; i--)
                suf[i] = suf[i + 1] + nums[i];
            count.Clear();
            for (int i = n - 1; i >= 0; i--)
            {
                long newSum = (long)(sum + k - nums[i]);
                if (newSum % 2 == 0)
                    res[i] += count.GetValueOrDefault(newSum / 2);
                count[suf[i]] = count.GetValueOrDefault(suf[i]) + 1;
            }

            //不改变数组，找一下答案；
            long ret = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (pre[i] == sum - pre[i])
                    ret++;
            }

            for (int i = 0; i < n; i++)
                ret = Math.Max(ret, res[i]);

            return (int)ret;
        }