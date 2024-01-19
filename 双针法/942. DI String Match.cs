//Leetcode 942. DI String Match ez
//题意：一个长度为 n 的排列可以用一个字符串 s 表示，其中 
//s[i] == 'I' 表示 perm[i] < perm[i + 1]，
//s[i] == 'D' 表示 perm[i] > perm[i + 1]。给定字符串 s，重构并返回排列 perm。
//思路：双指针，两个指针 low 和 high，分别表示当前排列中最小和最大的数字。
//遍历字符串 s，如果当前字符为 'I'，则取 low 对应的数字，否则取 high 对应的数字。
//遇到 'I' 就向后移动 low，遇到 'D' 就向后移动 high。
//最后 low 和 high 都指向的是剩余的数字，将其添加到结果中。
//时间复杂度：O(n)，其中 n 是字符串 s 的长度
//空间复杂度：O(n)
        public int[] DiStringMatch(string s)
        {
            int n = s.Length;
            int low = 0, high = n;
            int[] result = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                if (s[i] == 'I')
                {
                    result[i] = low++;
                }
                else
                {
                    result[i] = high--;
                }
            }

            result[n] = low; // or high, as they are equal at this point
            return result;
        }