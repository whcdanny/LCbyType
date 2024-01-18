//Leetcode 1537. Get the Maximum Score hard
//题意：给定两个有序数组 nums1 和 nums2，数组中的元素均为不同的整数。
//定义一个有效路径如下：
//选择数组 nums1 或 nums2 中的一个进行遍历（从索引0开始）。
//从左到右遍历当前数组。
//如果正在读取的值在 nums1 和 nums2 中均存在，可以改变路径到另一个数组（只考虑一个重复的值）。
//分数定义为在有效路径中唯一值的和。
//返回所有可能有效路径中的最大分数。由于答案可能太大，返回它对 10^9 + 7 取模的结果。
//思路：两个数组中相同的元素。我们可以使用两个指针，分别从 nums1 和 nums2 开始，比较当前位置的元素。如果两个元素相等，就找到了一个相同的元素，计算截至到这个位置的最大分数。然后，将指针移到下一个不相等的元素。
//在计算最大分数时，我们需要考虑两个数组之间的间隙。当指针移动到相同的元素时，我们可以选择从哪个数组开始，然后计算从这个位置向两边扩展的最大分数。
//注：用最小的数字，这样能保证最后i和j到达相同num的位置 这样就可以查Math.Max(sum1, sum2)
//时间复杂度：O(max(N, M))，其中 N 和 M 分别是两个数组的长度。
//空间复杂度：O(1)

        public int MaxSum(int[] nums1, int[] nums2)
        {
            long result = 0;
            long sum1 = 0, sum2 = 0;
            int i = 0, j = 0;
            int mod = 1000000007;

            while (i < nums1.Length || j < nums2.Length)
            {
                if (i < nums1.Length && (j == nums2.Length || nums1[i] < nums2[j]))
                {
                    sum1 += nums1[i];
                    i++;
                }
                else if (j < nums2.Length && (i == nums1.Length || nums1[i] > nums2[j]))
                {
                    sum2 += nums2[j];
                    j++;
                }
                else
                {
                    result += Math.Max(sum1, sum2) + nums1[i];
                    sum1 = 0;
                    sum2 = 0;
                    i++;
                    j++;
                }
            }

            result += Math.Max(sum1, sum2);
            return (int)(result % mod);
        }