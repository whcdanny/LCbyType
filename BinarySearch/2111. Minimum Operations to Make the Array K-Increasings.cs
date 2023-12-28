//Leetcode 2111. Minimum Operations to Make the Array K-Increasings hard
//题意：题目给定一个由 n 个正整数组成的数组 arr 和一个正整数 k。数组 arr 被称为 K-increasing，如果对于每个索引 i，都满足 arr[i-k] <= arr[i]，其中 k <= i <= n-1。
//换句话说，对于每个 i，数组中索引 i 和 i-k 之间的元素必须满足升序关系。
//题目要求通过操作，将数组 arr 转化为 K-increasing 数组，返回所需的最小操作数。计算机。电池不可充电。
//要求返回最长的同时运行时间。
//思路：二分搜索+LIS(Longest Increasing Subsequence), 这里意思相当于对k个间隔每次有一个list，然后存入相对应的nums，然后找到LIS(最长子数)，这样就知道有几个位置不需要改，也就是说总长度n-这个数是要改的；
//注：这里算LIS 是用到二分法的upperBound，相当于一个 23463，这种数，那2，3，4，6，当读到第二个3的时候，变成 2，3，3，6，maxValue；这样我们就可以确定整个输入的数中，最长的递增子树长度为4，所以我们只需要改一个位置就可以把当前整个数组变成都是递增；
//时间复杂度: O(k * logn)
//空间复杂度：O(1)       
        public int KIncreasing(int[] arr, int k)
        {
            int n = arr.Length;
            int res = 0;
            for(int i = 0; i < k; i++)
            {
                List<int> nums = new List<int>();
                for(int j = i; j < n; j+=k)
                {
                    nums.Add(arr[j]);
                }
                res += nums.Count - LIS_KIncreasing(nums);
            }
            return res;
        }

        public int LIS_KIncreasing(List<int> nums)
        {
            int n = nums.Count;
            int[] list = new int[n];
            Array.Fill(list, int.MaxValue);
            for(int i = 0; i < n; i++)
            {
                int iter = upperBound_KIncreasing(list, nums[i]);
                list[iter] = nums[i];
            }
            for(int i = n - 1; i >= 0; i--)
            {
                if (list[i] != int.MaxValue)
                    return i + 1;
            }
            return 0;
        }
        private int upperBound_KIncreasing(int[] list, int val)
        {
            int l = 0, r = list.Length - 1;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (list[m] <= val)
                    l = m + 1;
                else
                    r = m;
            }
            return l;
        }