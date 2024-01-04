//Leetcode 1889. Minimum Space Wasted From Packaging hard
//题意：题目描述了一个装箱问题。有 n 个包裹需要放入箱子中，每个箱子只能装一个包裹。有 m 个供应商，每个供应商生产不同尺寸的箱子（供应商的箱子数量是无限的）。一个包裹可以放入一个箱子中，条件是包裹的大小小于等于箱子的大小。
//给定的输入包括：
//一个整数数组 packages，其中 packages[i] 表示第 i 个包裹的大小。
//一个二维整数数组 boxes，其中 boxes[j] 是第 j 个供应商生产的箱子尺寸数组。
//目标是选择一个供应商，使用该供应商提供的箱子，使得总浪费空间最小。对于每个箱子中的包裹，浪费空间定义为箱子大小减去包裹大小。总浪费空间是所有箱子中浪费空间的总和。
//例如，如果需要放入大小为[2, 3, 5] 的包裹，供应商提供尺寸为[4, 8] 的箱子，我们可以将大小为 2 和 3 的包裹放入尺寸为 4 的两个箱子中，将大小为 5 的包裹放入尺寸为 8 的箱子中。这将导致浪费空间为(4-2) + (4-3) + (8-5) = 6。
//目标是返回通过选择箱子供应商使得总浪费空间最小的结果，如果无法将所有包裹放入箱子中，则返回 -1。由于答案可能很大，返回结果对 10^9 + 7 取模。
//思路：用二分法+前缀和, 对 packages 进行排序。对每个供应商的箱子数组 boxes[j] 进行排序。
//对于每个箱子大小 boxSize，找到 packages 中小于等于 boxSize 的最大的包裹（可以使用二分搜索）。
//注：找到第一个packages大于boxSize的位置，然后也就是j-i都满足当boxSize，所以cur+=b * (j - i)
//时间复杂度: 对 packages 和每个供应商的箱子数组 boxes[j] 进行排序的时间复杂度均为 O(n log n)，其中 n 是包裹的数量。由于有 m 个供应商，总体时间复杂度为 O(m * n log n)。
//空间复杂度：O(1)
        public int MinWastedSpace(int[] packages, int[][] boxes)
        {
            Array.Sort(packages);
            long inf = (long)1e11, res = inf, mod = (long)1e9 + 7, sumPackages = 0L;
            foreach (int package in packages)
            {
                sumPackages += package;
            }
            foreach (int[] box in boxes)
            {
                Array.Sort(box);
                if (box[box.Length - 1] < packages[packages.Length - 1])
                {
                    continue;
                }
                long cur = 0, i = 0, j;
                foreach (int b in box)
                {
                    j = BinarySearch_MinWastedSpace(packages, b + 1);
                    cur += b * (j - i);
                    i = j;
                }
                res = Math.Min(res, cur);
            }
            return res < inf ? (int)((res - sumPackages) % mod) : -1;
        }
        private int BinarySearch_MinWastedSpace(int[] packages, int b)
        {
            int left = 0, right = packages.Length;
            while (left < right)
            {
                int m = (left + right) / 2;
                if (packages[m] < b)
                {
                    left = m + 1;
                }
                else
                {
                    right = m;
                }
            }
            return left;
        }

        public int MinWastedSpace_超时(int[] packages, int[][] boxes)
        {
            Array.Sort(packages);
            long minWaste = long.MaxValue;

            foreach (var boxSizes in boxes)
            {
                Array.Sort(boxSizes);
                int i = 0, j = 0;
                long waste = 0;

                while (i < packages.Length && j < boxSizes.Length)
                {
                    if (packages[i] <= boxSizes[j])
                    {
                        waste += boxSizes[j] - packages[i];
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                }

                if (i == packages.Length)
                {
                    minWaste = Math.Min(minWaste, waste);
                }
            }

            return minWaste == long.MaxValue ? -1 : (int)(minWaste % 1_000_000_007);
        }