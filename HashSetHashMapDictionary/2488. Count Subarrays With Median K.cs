//Leetcode 2488. Count Subarrays With Median K hard
//题意：给定一个大小为 n 的数组 nums，包含从 1 到 n 的不同整数，以及一个正整数 k。返回 nums 中具有中位数等于 k 的非空子数组的数量。
//思路：hashtable, 
//选择数字“k”左侧的索引，并检查子数组可以扩展到“k”右侧的多少个索引。我们还需要包括完全位于“k”左侧和右侧的子数组。
//我们需要保持大于和小于“k”的数字之间的平衡。
//如果我们知道左边的余额是“x”，那么我们可以将子数组向右扩展到那些给我们总体余额 0 或 1 的索引。
//换句话说，如果右边的余额是“-x” ' 或 '1-x'，那么总体余额将为 0 或 1。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int CountSubarrays(int[] nums, int k)
        {
            Dictionary<int, int> record = new Dictionary<int, int>();
            int n = nums.Length;
            //找的k在nums中的位置；
            int pos = Array.FindIndex(nums, (a) => a == k);           
            // Balance 表示多或少k的个数，如果是0，1是有效的；
            int balance = 0;           
            int count = 1;
            //k的位置之后
            for (int i = pos + 1; i < n; i++)
            {
                if (nums[i] < k) 
                    balance--;
                else 
                    balance++;
                
                if (balance == 0 || balance == 1) 
                    count++;
                if (!record.ContainsKey(balance)) 
                    record.Add(balance, 0);
                record[balance]++;
            }

            balance = 0;
            //k位置之前；
            for (int i = pos - 1; i >= 0; i--)
            {
                if (nums[i] < k) 
                    balance--;
                else 
                    balance++;
                
                if (balance == 0 || balance == 1) 
                     count++;
                
                count += record.GetValueOrDefault(-balance) + record.GetValueOrDefault(1 - balance);
            }

            return count;
        }