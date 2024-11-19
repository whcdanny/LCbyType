//Leetcode 1985. Find the Kth Largest Integer in the Array med
//题意：要求给定一个字符串数组 nums 和一个整数 k，其中 nums 中的每个字符串表示一个没有前导零的整数。
//要求返回 nums 中第 k 大的整数所对应的字符串。
//需要注意的是，重复的数字应该被视为不同的数字。例如，如果 nums 是["1", "2", "2"]，那么 "2" 是第一个最大的整数，"2" 是第二大的整数，"1" 是第三大的整数。
//思路：PriorityQueue 把最大的k个输出；
//时间复杂度: O(nlogn)
//空间复杂度：O(1)            
        public string KthLargestNumber(string[] nums, int k)
        {
            var pq = new PriorityQueue<string, long /*BigInteger*/>();
            foreach (string num in nums)
            {
                pq.Enqueue(num, long /*BigInteger*/.Parse(num));
                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }
            return pq.Peek();
        }
        //思路：，我们将字符串数组 nums 中的元素按照它们表示的整数大小进行排序。由于字符串表示的整数可能具有不同的位数，我们需要使用自定义的比较器来确保排序的正确性。
        //排序后，我们可以直接返回 nums 中第 k 大的整数所对应的字符串
        //时间复杂度: O(nlogn)
        //空间复杂度：O(1)     
        public string KthLargestNumber1(string[] nums, int k)
        {
            Array.Sort(nums, new StringComparer());
            return nums[nums.Length - k];
        }
        private class StringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x.Length != y.Length)
                {
                    return x.Length - y.Length;
                }
                return string.Compare(x, y);
            }
        }