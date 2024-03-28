//Leetcode 3044. Most Frequent Prime med
//题意：给定一个m x n的二维矩阵mat，矩阵中的每个元素都是一个非负整数。从每个单元格开始，可以按照以下方式创建数字：
//从每个单元格出发，可以沿着东、东南、南、西南、西、西北、北、东北八个方向移动。
//选择一个方向，并将沿着该方向移动的数字连接起来，形成一个数字。
//注意，在每一步移动中都会生成一个数字，例如，如果沿着路径的数字分别是1、9、1，则在移动过程中会生成三个数字：1、19、191。
//要求返回由遍历矩阵所生成的所有数字中最频繁的大于10的质数，如果不存在这样的质数，则返回-1。如果有多个频率最高的质数，则返回其中最大的一个。
//注意：在移动过程中改变方向是无效的。
//思路：hashtable, Dictionary存入每个出现prime的个数，注意这里必须是十位以上的prime；
//然后根据八个方向，然后统计出最大的出现频率的数；        
//时间复杂度：遍历矩阵O(m * n)，个方向生成数字O(8 * max(m, n))，统计数字频率O(k)，其中k为所有数字的数量，由于k不会超过m * n * 8，所以总的时间复杂度为O(m * n * max(m, n))。
//空间复杂度：O(k)
        public int MostFrequentPrime(int[][] mat)
        {            
            Dictionary<int, int> freqMap = new Dictionary<int, int>();

            int m = mat.Length;
            int n = mat[0].Length;

            // Traverse the matrix and generate all numbers
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    GenerateNumbers(mat, freqMap, i, j, m, n);
                }
            }

            int maxFreqPrime = -1;
            int maxFreq = 0;

            // Find the most frequent prime number
            foreach (var pair in freqMap)
            {
                int num = pair.Key;
                int freq = pair.Value;
                if (freq > maxFreq)
                {
                    maxFreqPrime = num;
                    maxFreq = freq;
                }
                else if (freq == maxFreq && num > maxFreqPrime)
                {
                    maxFreqPrime = num;
                }
            }

            return maxFreqPrime;
        }
        private void GenerateNumbers(int[][] mat, Dictionary<int, int> freqMap, int x, int y, int m, int n)
        {
            int[] dx = { 0, 1, 1, 1, 0, -1, -1, -1 };
            int[] dy = { 1, 1, 0, -1, -1, -1, 0, 1 };

            int num = 0;
            for (int i = 0; i < 8; i++)
            {
                int nx = x, ny = y;
                while (nx >= 0 && nx < m && ny >= 0 && ny < n)
                {
                    num = num * 10 + mat[nx][ny];
                    if (isprime(num))
                    {
                        if (!freqMap.ContainsKey(num))
                        {
                            freqMap[num] = 0;
                        }
                        freqMap[num]++;
                    }
                    nx += dx[i];
                    ny += dy[i];
                }
                num = 0; // Reset num for next direction
            }
        }
        
        public bool isprime(int num)
        {
            if (num < 10)
                return false;

            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }