//Leetcode 496. Next Greater Element I ez
//题意：给定两个不同的 0 索引整数数组 nums1 和 nums2，其中 nums1 是 nums2 的子集。
//对于 nums1 中的每个元素 nums1[i]，找到在 nums2 中与之相等的元素 nums2[j] 的索引 j，
//并确定 nums2[j] 在 nums2 中的下一个更大元素。如果没有下一个更大的元素，则对于这个查询的答案是 -1。
//思路：Stack+ monotomic stack 遍历 nums2，使用单调递减栈来找到每个元素的下一个更大元素。将元素的索引入栈。
//如果当前元素比栈顶元素大，则说明栈顶元素的下一个更大元素就是当前元素。将栈顶元素弹出，并记录其下一个更大元素为当前元素。
//将 nums2 中所有元素的下一个更大元素都记录在哈希表中。
//遍历 nums1，根据哈希表中的记录找到每个元素的下一个更大元素。
//时间复杂度：O(n + m)，其中 n 和 m 分别是数组 nums1 和 nums2 的长度
//空间复杂度：O(n) 
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> nextGreater = new Dictionary<int, int>();
            Stack<int> stack = new Stack<int>();

            // 遍历 nums2，找到每个元素的下一个更大元素
            foreach (int num in nums2)
            {
                while (stack.Count > 0 && stack.Peek() < num)
                {
                    nextGreater[stack.Pop()] = num;
                }
                stack.Push(num);
            }

            // 在哈希表中查找 nums1 中每个元素的下一个更大元素
            int[] result = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                result[i] = nextGreater.ContainsKey(nums1[i]) ? nextGreater[nums1[i]] : -1;
            }

            return result;
        }