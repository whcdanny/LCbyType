//Leetcode 3046. Split the Array ez
//题意：给定一个长度为偶数的整数数组nums。要求将数组分割成两个部分nums1和nums2，使得：
//nums1和nums2的长度相等，均为nums.length / 2。
//nums1中的元素是不同的。
//nums2中的元素也是不同的。
//如果可以将数组满足上述条件地分割成两个部分，则返回true；否则返回false。
//思路：hashtable, nums进行排序，以便统计每个元素的出现次数。
//使用哈希表来记录每个元素的出现次数，键为元素的值，值为元素的出现次数。
//遍历哈希表，如果存在任何元素的出现次数大于2，则返回false，因为无法满足nums1和nums2中的元素都是不同的条件。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public bool IsPossibleToSplit(int[] nums)
        {
            Array.Sort(nums); // Sort the array to simplify the process

            Dictionary<int, int> freqMap = new Dictionary<int, int>(); // Frequency map

            // Count the frequency of each element
            foreach (int num in nums)
            {
                if (!freqMap.ContainsKey(num))
                {
                    freqMap[num] = 0;
                }
                freqMap[num]++;
            }

            foreach (int key in freqMap.Keys)
            {
                if (freqMap[key] > 2)
                {
                    return false;
                }
            }

            return true;
        }
