//Leetcode 2499. Minimum Total Cost to Make Arrays Unequal hard
//题意：给定两个长度相等的数组 nums1 和 nums2，你可以执行一种操作：交换 nums1 中任意两个位置的值，操作的代价是两个位置的索引之和。
//找到执行任意次操作的最小总代价，使得在操作后 nums1[i] != nums2[i] 对于所有的 0 <= i <= n - 1。如果不可能实现，则返回 -1。
//思路：hashtable, 
//保证所有的same pairs在“内部调整”后就能满足要求呢？只要其中的majority element不超过same pairs的总数的一半即可。
//(2,2),(2,2),(2,2),(1,1),(3,3),(4,4),我们只要把2和非2元素交换，就可以满足同一个pair里的两个元素不同。
//但是如果有过半数的majority element，例如(2,2),(2,2),(2,2),(2,2),(1,1),(3,3),那么我们就无法找到足够多的非2元素来拆散(2,2).
//对于第二种情况，我们就需要借助于其他pair的帮助。在这个例子中，“内部调整”后我们还有两对(2,2)没有被拆散，这就需要我们找其他distinc pairs来与之交换。
//按下标从小到大去尝试。例如我们考察(a, b)的时候，思考它是否能帮助拆散(2,2)，需要满足的条件有三个：
//a!=b，否则这是一个same pair，已经在“内部调整”时用过了。
//a!=2且b!=2，否则交换之后仍然会有一个(2,2)。
//满足上述两个条件，那么我们就再做一次(a, b)与(2,2)的交换即可。以此类推不断寻找下一个合适的distinct pair，直至将多余的(2,2)消耗掉。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public long MinimumTotalCost(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            Dictionary<int, int> count = new Dictionary<int, int>();
            int total = 0;
            long ret = 0;

            for (int i = 0; i < n; i++)
            {
                if (nums1[i] == nums2[i])
                {
                    if (!count.ContainsKey(nums1[i]))
                    {
                        count[nums1[i]] = 0;
                    }
                    count[nums1[i]]++;
                    total++;
                    ret += i;
                }
            }

            int maxCount = 0;
            foreach (var kvp in count)
            {
                maxCount = Math.Max(maxCount, kvp.Value);
            }

            int maxVal = 0;
            foreach (var kvp in count)
            {
                if (kvp.Value == maxCount)
                {
                    maxVal = kvp.Key;
                    break;
                }
            }

            if (maxCount <= total - maxCount)
            {
                return ret;
            }

            int extra = maxCount - (total - maxCount);
            for (int i = 0; i < n; i++)
            {
                if (extra == 0)
                {
                    break;
                }
                if (nums1[i] == nums2[i])
                {
                    continue;
                }
                if (nums1[i] == maxVal || nums2[i] == maxVal)
                {
                    continue;
                }
                extra--;
                ret += i;
            }

            if (extra == 0)
            {
                return ret;
            }
            else
            {
                return -1;
            }

        }