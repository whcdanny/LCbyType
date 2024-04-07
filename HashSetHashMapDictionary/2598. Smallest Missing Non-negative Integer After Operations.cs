//Leetcode 2598. Smallest Missing Non-negative Integer After Operations med
//题意：给定一个整数数组 nums 和一个整数值。
//在一次操作中，你可以对 nums 的任意元素添加或减去值。
//例如，如果 nums = [1, 2, 3]，value = 2，则可以选择从 nums[0] 减去值，使得 nums = [-1, 2, 3]。
//数组的最小排除值（MEX）是其中缺失的最小非负整数。
//例如，[-1,2,3] 的 MEX 是 0，而[1, 0, 3] 的 MEX 是 2。
//在应用任意次数的操作后，返回 nums 的最大 MEX。
//思路：hashtable, 对一个元素无论做多少次的加减操作，不变的就是对value的余数。
//只要有元素对value的余数是0，我们就可以构造出0来。只要有元素对value的余数是1，我们就可以构造出1来。可以推出是否能构造出value-1.
//将所有元素以对value的模分类，找到其中的最小频次c以及对应的模r
//c个[0, value - 1] 的完整周期来
//也就是能构造出[0, value * c - 1] 的所有整数。接下来再算上零头，我们可以再构造出接下来r个元素。最终未能构造出的MEX就是value * c+r.        
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int FindSmallestInteger(int[] nums, int value)
        {
            int[] count = new int[value];

            foreach (int x in nums)
            {
                int modValue = ((x % value) + value) % value;
                count[modValue] += 1;
            }
            //完整周期
            int minCount = int.MaxValue;
            //再不完整的周期中，找到那个刚好缺少的位置；
            int k = 0;

            for (int i = 0; i < value; i++)
            {
                if (count[i] < minCount)
                {
                    minCount = count[i];
                    k = i;
                }
            }

            return minCount * value + k;
        }