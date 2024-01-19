//Leetcode 870. Advantage Shuffle med
//题意：给定两个相同长度的整数数组 nums1 和 nums2。nums1 相对于 nums2 的优势定义为在多少个索引 i 上满足 nums1[i] > nums2[i]。
//要求返回 nums1 的任何一个排列，使得其相对于 nums2 的优势最大。
//思路：双指针，先给用一个queue把num2的大小和相对应位置固定，然后倒序；
//然后给nums1正序，然后left和right指向nums1的两端，
//maxval 是 nums2 中的最大值，i 是对应索引; 如果 nums1[right] 能胜过 maxval，那就自己上;否则用最小值混一下，养精蓄锐
//时间复杂度：O(n∗logn)
//空间复杂度：O(1)
        public int[] AdvantageCount(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;            
            Queue<KeyValuePair<int, int>> maxpq = new Queue<KeyValuePair<int, int>>();
            // 将位置 i 和对应的值 nums[i] 存储到队列中
            for (int i = 0; i < nums2.Length; i++)
            {
                maxpq.Enqueue(new KeyValuePair<int, int>(i, nums2[i]));
            }

            // 对队列中的元素按降序排列
            maxpq = new Queue<KeyValuePair<int, int>>(
                maxpq.OrderByDescending(kvp => kvp.Value));

            // 给 nums1 升序排序
            Array.Sort(nums1);

            // nums1[left] 是最小值，nums1[right] 是最大值
            int left = 0, right = n - 1;
            int[] res = new int[n];

            while (maxpq.Count != 0)
            {
                KeyValuePair<int, int> pair = maxpq.Dequeue();
                // maxval 是 nums2 中的最大值，i 是对应索引
                int i = pair.Key, maxval = pair.Value;
                if (maxval < nums1[right])
                {
                    // 如果 nums1[right] 能胜过 maxval，那就自己上
                    res[i] = nums1[right];
                    right--;
                }
                else
                {
                    // 否则用最小值混一下，养精蓄锐
                    res[i] = nums1[left];
                    left++;
                }
            }
            return res;
        }