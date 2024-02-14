//Leetcode 2163. Minimum Difference in Sums After Removal of Elements hard
//题意：题目给出一个长度为 3n 的整数数组 nums，要求移除数组中恰好包含 n 个元素的任意子序列，剩余的 2n 个元素将被分成两个相等的部分。我们需要计算在移除子序列后，两部分元素之和的差值的最小可能值。
//思路：PriorityQueue 看code    
//Min (first 1/3 length - second 1/3 length) <= Min(first) -Max(second);
//So we use two priority queue to track:
//the min sum(size= 1 / 3 length) of first m elements[0, ...m];
//the max sum(size= 1 / 3 length) after m elements[m, ...n - 1];
//m should be beweet 1/3 length and 2/3 length;
//时间复杂度: O(2^n) 
//空间复杂度：O(n)
        public long MinimumDifference(int[] nums)
        {
            int n = nums.Length;
            int m = n / 3;
            long res = long.MaxValue;
           
            //存最小的一些值 with size = m, from [0, 1, ..., k]
            long[] minList = new long[n];
            
            //存最大的一些值 size = m, from [k, ..., n - 1]
            long[] maxList = new long[n];

            //最大的pq
            PriorityQueue<int, int> max = new PriorityQueue<int, int>();
            long sum = 0;

            //初始前 1/3 n part
            for (int i = 0; i < m; i++)
            {
                sum += nums[i];
                max.Enqueue(nums[i], -nums[i]);
            }

            //第二个部分 1/3 ~ 2/3
            for (int i = m; i <= 2 * m; i++)
            {
                minList[i] = sum;      
                max.Enqueue(nums[i],-nums[i]); 
                sum += nums[i];         // Sum + new one
                sum -= max.Dequeue();   // Sum - max one
            }

            //最小的pq在
            PriorityQueue<int,int> min = new PriorityQueue<int,int>();
            sum = 0;

            //初始倒数  1/3 n part
            for (int i = 0; i < m; i++)
            {
                sum += nums[n - 1 - i];
                min.Enqueue(nums[n - 1 - i], nums[n - 1 - i]);
            }

            //第三部分 2/3 ~ 1
            for (int i = m; i <= 2 * m; i++)
            {
                maxList[n - i] = sum;
                min.Enqueue(nums[n - 1 - i], nums[n - 1 - i]);
                sum += nums[n - 1 - i];// Sum + new one
                sum -= min.Dequeue();  // Sum - min one
            }

            // Compute the final result
            // Find the max value in the second part [i, ..., n - 1]
            // Find the min value in the first part [0, ..., i]
            // Find the result
            for (int i = m; i <= 2 * m; i++)
            {
                res = Math.Min(res, minList[i] - maxList[i]);
            }

            return res;
        }