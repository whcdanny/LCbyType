//Leetcode 3649. Number of Perfect Pairs med
//题意：给一个数组，找出满足以下条件的（i，j）对儿
//i < j
//a = nums[i], b = nums[j]. 
//min(|a - b|, |a + b|) <= min(|a|, |b|) 
//max(|a - b|, |a + b|) >= max(|a|, |b|)
//思路：双针法+数学逻辑
//根据数学逻辑，B <= 2A 
//所以先把所以num都绝对值，然后排序，
//然后固定A（left）然后找B（right）满足absNums[right] <= 2 * absNums[left]
//B 在[left + 1, right - 1] 范围内
//时间复杂度: O(nlogn) 排序O(nlogn)。双指针O(n)  
//空间复杂度：O(n)
        public long CountPerfectPairs(int[] nums)
        {
            int n = nums.Length;
            long[] absNums = new long[n];
            
            for (int i = 0; i < n; i++)
            {
                absNums[i] = Math.Abs((long)nums[i]);
            }
            
            Array.Sort(absNums);

            long count = 0;
            int right = 0;
            
            for (int left = 0; left < n; left++)
            {
                // 找到最大的 right，使得 absNums[right] <= 2 * absNums[left]
                while (right < n && absNums[right] <= 2 * absNums[left])
                {
                    right++;
                }

                // 此时满足条件的 B 在 [left + 1, right - 1] 范围内
                // 数量为 (right - 1) - left
                count += Math.Max(0, right - 1 - left);
            }

            return count;
        }
        //暴力算法会超时
        public int PerfectPairs1(int[] nums)
        {
            int left = 0;
            int right = 1;
            int res = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i+1; j < nums.Length; j++)
                {
                    int a = nums[i];
                    int b = nums[j];
                    if ((Math.Min(Math.Abs(a - b), Math.Abs(a + b)) <= Math.Min(Math.Abs(a), Math.Abs(b)))
                        && (Math.Max(Math.Abs(a - b), Math.Abs(a + b)) >= Math.Max(Math.Abs(a), Math.Abs(b))))
                        res++;
                }
            }
            return res;
        }