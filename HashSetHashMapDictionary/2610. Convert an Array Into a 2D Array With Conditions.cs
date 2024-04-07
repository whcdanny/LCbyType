//Leetcode 2610. Convert an Array Into a 2D Array With Conditions med
//题意：给定一个整数数组 nums，需要创建一个二维数组，满足以下条件：
//二维数组只包含数组 nums 的元素。
//二维数组中的每一行都包含不同的整数。
//二维数组的行数应尽可能少。
//返回结果数组。如果存在多个答案，则返回其中的任何一个即可。
//思路：hashtable, 用每个数出现频率来觉得行数，
//如果当前的数的频率小于最大的出现频率， 那么就可以添加到当前频率的行里，
//如果大于，那么就需要创建新的行，让把当前数字添加进去；        
//时间复杂度：O(n)
//空间复杂度：O(n)
        public IList<IList<int>> FindMatrix(int[] nums)
        {            
            int[] freq = new int[nums.Length + 1];
            IList<IList<int>> result = new List<IList<int>>();
            //行数有关;
            int maxFreq = 0;
            foreach (int num in nums)
            {                
                int currentFreq = freq[num]++;                
                if (currentFreq >= maxFreq)
                {
                    maxFreq = currentFreq + 1;
                    result.Add(new List<int> { num });
                }
                else
                {
                    result[currentFreq].Add(num);
                }
            }
            return result;
        }