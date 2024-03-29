//Leetcode 2965. Find Missing and Repeated Values ez
//题意：给定一个大小为 n * n 的二维整数矩阵 grid，其中包含了范围为 [1, n^2] 的所有整数，每个整数都恰好出现一次，除了两个数：
//一个是重复出现了两次的数字 a，另一个是缺失的数字 b。任务是找出重复的数字 a 和缺失的数字 b。
//思路：hashtable, 用int[]把每个数出现的次数存入，初始都是0；
//然后如果有数大于1，重复，有数0，缺失；        
//时间复杂度：O(n^2)
//空间复杂度：O(n)
        public int[] FindMissingAndRepeatedValues(int[][] grid)
        {
            int n = grid.Length;
            int[] frequence = new int[n * n + 1];

            foreach (var row in grid)
            {
                foreach (var num in row)
                    frequence[num]++;
            }

            int repeat = 0, missing = 0;
            for (int j = 1; j < frequence.Length; j++)
            {
                if (frequence[j] == 0)
                    missing = j;
                if (frequence[j] == 2)
                    repeat = j;
            }

            return new int[] { repeat, missing };            
        }