//Leetcode 3132. Find the Integer Added to Array II med
//题目：给定两个整数数组 nums1 和 nums2。在 nums1 中有两个元素被移除，
//其余的所有元素都增加了一个整数 x（如果是负数则减去 x），
//最终使得 nums1 变成 nums2。两个数组在包含相同元素且这些元素频率相同的情况下才视为相等。
//请返回能够达到这种等价性的最小整数 x。
//思路: 双针法
//先将nums1和nums2排序，
//因为只移除两个元素，且 x 是唯一的偏移量,取前三个是合理的简化方案，因为其他较大的 x 值很可能会导致过多的元素需要调整
//然后用两个point分别再num1和num2，然后根据给出的x，来找是否满足只移除2个元素        
//时间复杂度：O(n log n)
//空间复杂度：O(1)
        public int MinimumAddedInteger(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int minEle = int.MaxValue;
            //尝试这三个 x 值，因为只移除两个元素，且 x 是唯一的偏移量。
            //取前三个是合理的简化方案，因为其他较大的 x 值很可能会导致过多的元素需要调整。
            for (int i = 0; i < 3; i++)
            {
                int x = nums2[0] - nums1[i];
                if (checkMinInteger(nums1, nums2, x))
                {
                    minEle = Math.Min(minEle, x);
                }
            }
            return minEle;
        }

        public bool checkMinInteger(int[] nums1, int[] nums2, int k)
        {
            int count = 0, j = 0;//point in nums2
            //i:point in nums1
            for (int i = 0; i < nums1.Length && j < nums2.Length; i++)
            {
                //元素需要被去除或不影响匹配
                if (nums1[i] + k != nums2[j]) 
                    count++;
                else 
                    j++;
            }
            if (count > 2) 
                return false;
            return true;
        }