//Leetcode 2386. Find the K-Sum of an Array hard
//题意：给定一个整数数组 nums 和一个正整数 k。你可以选择数组的任何子序列，并将其所有元素求和。
//我们将数组的 K-Sum 定义为可以获得的第 k 大的子序列和（不一定是不同的）。
//返回数组的 K-Sum。
//子序列是从另一个数组中删除一些或没有元素而不改变其余元素顺序的数组。
//注意，空子序列被认为具有和为 0。
//思路：PriorityQueue 
//第一步：转化为求一个正数数组的第k小序列和。
//本题最大sum的序列S就是将数组里所有的正数都取出来，对应的是MaxSum。次大的sum值必然是在这个序列S的基础上减去一个已经存在的正数，或者加上一个还未入队的负数。
//因为减去正数等于减去它的绝对值，加上负数也等于减去它的绝对值
//第二步：构造一个正数数组的从小到大所有的序列和。
//其实index表示我减去的位置，比如[x0, x1, x2, x3]: 当前sum=x0+x1+x2+x3; 
//那么pq里首先存的是 （sum-x0，x0），也就是说不含x0有这一种情况；
//那如果pq里没有x1有几种呢 (sum-x1,x1) (sum-x0-x1, x1) 对吧
//那如果pq里没有x2呢：(sum-x0-x1-x2, x2) (sum-x0-x2, x2) (sum-x1-x2, x2) (sum-x2, x2)
//所以肯定包含所有可能，并且由于是PriorityQueue 所以给出的肯定是当前最大的；
//时间复杂度: O(nlogk)
//空间复杂度：O(k)       
        public long KSum(int[] nums, int k)
        {
            long sum = 0;
            foreach (int n in nums)
                if (n > 0) 
                    sum += n;
            //当前sum是最大的，
            Array.Sort(nums, (a, b) => { return Math.Abs(a) - Math.Abs(b); });
            PriorityQueue<(long, long), long> pq = new PriorityQueue<(long, long), long>();
            pq.Enqueue((sum - Math.Abs(nums[0]), 0), sum - Math.Abs(nums[0] * -1));
            
            while (--k > 0)
            {
                //其中sum必然是某个以nums[i]结尾的子序列之和
                (long curSum, long index) = pq.Dequeue();
                if (index + 1 <= nums.Length - 1)
                {
                    long nextIdx = index + 1; 
                    long nextSum = curSum - Math.Abs(nums[nextIdx]);
                    pq.Enqueue((nextSum, nextIdx), nextSum * -1);
                    pq.Enqueue((nextSum + Math.Abs(nums[index]), nextIdx), (nextSum + Math.Abs(nums[index])) * -1);
                }
                sum = curSum;
            }
            return sum;
        }