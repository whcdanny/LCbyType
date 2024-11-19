//Leetcode 88. Merge Sorted Arrays ez
//题意：给定两个已排序的整数数组 nums1 和 nums2，将 nums2 合并到 nums1 中，使得 nums1 成为一个已排序的数组。假设 nums1 有足够的空间（大小大于等于 m + n）来容纳 nums2 中的元素。
//思路：创建一个最小堆 minHeap，将 nums1 和 nums2 中的所有元素放入堆中。依次从堆中取出最小的元素，放入 nums1 中。
//时间复杂度：将 nums1 和 nums2 中的所有元素放入堆中的时间复杂度是 O(m + n * log(m + n))。依次从堆中取出元素并放入 nums1 中的时间复杂度是 O(m + n)。总的时间复杂度是 O(m + n + n* log(m + n))，近似于 O(n* log(m + n))。
//空间复杂度：O(m + n)
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            PriorityQueue<int> minHeap = new PriorityQueue<int>((a, b) => a - b);

            foreach (int num in nums1.Take(m))
                minHeap.Enqueue(num);

            foreach (int num in nums2)
                minHeap.Enqueue(num);

            for (int i = 0; i < m + n; i++)
            {
                nums1[i] = minHeap.Dequeue();
            }
        }
        //88. Merge Sorted Array 
        //题目要求将两个已排序的整数数组 nums1 和 nums2 合并为一个排序的数组，并将结果存储在 nums1 中
        //思路：三个指针分别指向 nums1 的末尾、nums2 的末尾和合并后的数组的末尾；
        public void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1; // nums1 的末尾指针
            int p2 = n - 1; // nums2 的末尾指针
            int p = m + n - 1; // 合并后的数组的末尾指针

            while (p1 >= 0 && p2 >= 0)
            {
                if (nums1[p1] >= nums2[p2])
                {
                    nums1[p] = nums1[p1];
                    p1--;
                }
                else
                {
                    nums1[p] = nums2[p2];
                    p2--;
                }
                p--;
            }

            while (p2 >= 0)
            {
                nums1[p] = nums2[p2];
                p2--;
                p--;
            }
        }
        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (j >= 0)
            {
                if (i >= 0)
                {
                    nums1[k--] = nums1[i] > nums2[j] ? nums1[i--] : nums2[j--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }
        }