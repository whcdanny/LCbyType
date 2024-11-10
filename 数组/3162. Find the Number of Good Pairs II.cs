//Leetcode 3162. Find the Number of Good Pairs II med
//题目：你有两个整数数组 nums1 和 nums2，它们的长度分别是 n 和 m。你还得到一个正整数 k。
//定义一对(i, j) 为“好对”当且仅当 nums1[i] 能被 nums2[j] * k 整除（即 nums1[i] % (nums2[j] * k) == 0），其中 0 <= i <= n - 1 且 0 <= j <= m - 1。
//要求返回“好对”的总数。
//思路: //x/(y*k) = i -》x/i=y*k，i就是能整除的因数
//所以用Dictionary先找出所有能整除x的i和其个数，然后看i是否=y*k然后res+上个数；
//时间复杂度：O(n * √N + m)，其中 n 是 nums1 的长度，m 是 nums2 的长度
//空间复杂度：O(n * √N)
        public long NumberOfPairs1(int[] nums1, int[] nums2, int k)
        {
            //x/(y*k) = i
            //x/i=y*k
            //i就是能整除的因数
            Dictionary<int, int> map = new Dictionary<int, int>();

            // 构建 nums1 的因数字典，记录每个因数的出现次数
            foreach (int num in nums1)
            {                
                for (int i = 1; i * i <= num; i++)
                {
                    if (i * i == num)
                    {
                        if (map.ContainsKey(i)) map[i]++;
                        else map[i] = 1;
                    }
                    //如果i可以整除nums
                    else if (num % i == 0)
                    {
                        if (map.ContainsKey(i)) map[i]++;
                        else map[i] = 1;
                        //相对应商也可以整除num
                        int complementFactor = num / i;
                        if (map.ContainsKey(complementFactor)) map[complementFactor]++;
                        else map[complementFactor] = 1;
                    }
                }
            }

            long result = 0;

            // 遍历 nums2，查找符合条件的好对数量
            foreach (int num in nums2)
            {
                int targetFactor = num * k;
                if (map.ContainsKey(targetFactor)) result += map[targetFactor];
            }

            return result;
        }