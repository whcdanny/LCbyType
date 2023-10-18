//Leetcode 454. 4Sum II   med
//题意：给定四个整数数组 A, B, C, D，要求找出有多少个元组 (i, j, k, l) 使得 A[i] + B[j] + C[k] + D[l] 等于零。
//思路：可以使用哈希表来解决这个问题。 将 A 和 B 数组中所有可能的和存储在一个哈希表中，其中哈希表的键是和，值是该和出现的次数。遍历 C 和 D 数组，对于每对元素，计算它们的和，然后查看在哈希表中是否存在相反数。如果存在相反数，将相反数的出现次数加到结果中。
//时间复杂度:  构建哈希表的时间复杂度是 O(n^2)，遍历 C 和 D 数组的时间复杂度也是 O(n^2)，因此总的时间复杂度是 O(n^2)。
//空间复杂度： 构建哈希表的空间复杂度是 O(n^2)     
        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            Dictionary<int, int> abSet = new Dictionary<int, int>();
            foreach(int n1 in nums1)
            {
                foreach(int n2 in nums2)
                {
                    int sum = n1 + n2;
                    if (abSet.ContainsKey(sum))
                    {
                        abSet[sum]++;
                    }
                    else
                    {
                        abSet[sum] = 1;
                    }                    
                }
            }
            int count = 0;
            foreach(int n3 in nums3)
            {
                foreach(int n4 in nums4)
                {
                    int sum = -(n3 + n4);
                    if (abSet.ContainsKey(sum))
                    {
                        count += abSet[sum];
                    }
                }
            }
            return count;
        }