//870. Advantage Shuffle med
//给你输入两个长度相等的数组 nums1 和 nums2，请你重新组织 nums1 中元素的位置，使得 nums1 的「优势」最大化。
//思路：用到双指针方法，因为nums2的位置不能变，所以先要把nums2位置和相对于位置的数存入queue并降序排列，也就是最大的开始；
//然后个nums1排序如果 nums1[right] 能胜过 maxval，那就自己上，否则用最小值混一下，养精蓄锐
		 public int[] AdvantageCount(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            //Queue<int[]> maxpq = new Queue<int[]>();
            //Queue<int[]> maxpq = new Queue<int[]>(Comparer<int[]>.Create((pair1, pair2) => pair2[1].CompareTo(pair1[1])));
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

            while (maxpq.Count!=0)
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