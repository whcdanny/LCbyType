//Leetcode 3079. Find the Sum of Encrypted Integers ez
//题目：你被给定了一个包含正整数的数组 nums。定义一个函数 encrypt(x)，它将 x 中的每个数字替换为 x 中最大的数字。例如：
//encrypt(523) 将 523 中的所有数字替换为最大的数字 5，结果为 555。
//encrypt(213) 将 213 中的所有数字替换为最大的数字 3，结果为 333。
//你的任务是计算 nums 中所有整数经过 encrypt 函数处理后的总和。
//思路: 把每个位置转换成string然后再每个char找到最大的数字，
//然后再写成新的最大char组成的string然后int.Parse(encryptedString)出数字，然后加到最后res
//时间复杂度：O(n*d)假设最大位数为 D
//空间复杂度：O(d)
        public int SumOfEncryptedInt(int[] nums)
        {
            int res = 0;
            foreach(int num in nums)
            {
                string st = num.ToString();
                char maxC = '0';
                foreach(char c in st)
                {
                    if (c > maxC)
                        maxC = c;
                }
                string encryptedString = new string(maxC, st.Length);
                int encryptedInt = int.Parse(encryptedString);
                res += encryptedInt;
            }
            return res;
        }