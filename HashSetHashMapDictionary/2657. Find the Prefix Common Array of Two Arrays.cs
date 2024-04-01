//Leetcode 2657. Find the Prefix Common Array of Two Arrays med
//题意：给定两个长度为 n 的整数排列 A 和 B。
//A 和 B 的前缀公共数组是一个数组 C，使得 C[i] 等于在数组 A 和 B 中在索引 i 处之前或者包括索引 i 处的数字的数量。
//返回 A 和 B 的前缀公共数组。
//思路：hashtable, 用两个hashset分别存A,B的出现的不重复数字，
//当添加新的数字的时候，先看set2是否有新添加的A数字
//如果添加的数字不一样，那么就检查set1是否有新添加B的数字；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] FindThePrefixCommonArray(int[] A, int[] B)
        {
            var commonCount = 0;
            var hashset1 = new HashSet<int>();
            var hashset2 = new HashSet<int>();
            var res = new int[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                hashset1.Add(A[i]);
                hashset2.Add(B[i]);

                if (hashset2.Contains(A[i]))
                    commonCount++;
                if (A[i] != B[i] && hashset1.Contains(B[i]))
                    commonCount++;

                res[i] = commonCount;
            }

            return res;
        }
