//Leetcode 2453. Destroy Sequential Targets med
//题意：给定一个由正整数组成的数组 nums 和一个整数 space，表示数轴上的目标。还给定一个整数 space。
//你有一台可以摧毁目标的机器。给机器一个 nums[i] 可以摧毁所有值可以表示为 nums[i] + c* space 的目标，其中 c 是任意非负整数。你想要摧毁 nums 中的最大数量的目标。
//返回你可以给机器提供的 nums[i] 的最小值，以摧毁最大数量的目标。
//思路：hashtable 为了确保销毁最大数量的值，必须在最大的“相同余数”组中找到最小的数字。        
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int DestroyTargets(int[] nums, int space)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            int maxF = 0, minTarg = Int32.MaxValue;
            //迭代 nums 并用剩余的 n% 空间填充字典并跟踪最大频率
            foreach (var n in nums)
            {
                int key = n % space;
                if (freq.ContainsKey(key)) 
                    freq[key]++;
                else 
                    freq.Add(key, 1);
                maxF = Math.Max(freq[key], maxF);
            }
            //再次迭代 nums 并存储属于具有最大频率的任何剩余组的一部分的最小数字（某些组可能具有相同的频率）。
            foreach (var n in nums)
            {
                if (freq[n % space] == maxF) 
                    minTarg = Math.Min(n, minTarg);
            }
            return minTarg;
        }