//Leetcode 3766. Minimum Operations to Make Binary Palindrome med
//题意：给一共数组nums，然后对每一个num进行binary，然后找出到这个binary能是一个回文的最小的数字之间的差。
//比如 1 -> 1 -> 1 -> 0;  2 -> 10 -> 11 -> 3 -> 1; 4 -> 100 -> 11 -> 3 -> 1;
//思路：双针法 + 二进制运算 + 镜像； 
//先将num -> binary，然后找出可能的候选者，
//5个：全是1（111....111）；100...0001；同位数且前缀减 1 的镜像；同位数且前缀不变的镜像；同位数且前缀加 1 的镜像；
//最后将这5个候选convert回int64，找出最小diff
//时间复杂度: O(log n) 取决于二进制的位数，处理 32 位整数时极快。 二进制转换：O(L)。生成每个候选者时，（Substring）、（Reverse）和拼接。O(L)。
//空间复杂度：O(log n)
        public int[] MinOperations(int[] nums)
        {
            int[] res = new int[nums.Length];
            int index = 0;
            foreach(int num in nums)
            {
                res[index] = nearestBinaryPalindrome(num);
                index++;
            }
            return res;
        }
        public int nearestBinaryPalindrome(int n)//fix
        {
            if (n == 0) return 0;
           
            //convert to binary
            string s = Convert.ToString(n, 2);
            int len = s.Length;
            
            //Cloest 5 candidates
            long[] candidates = new long[5];
            candidates[0] = (long)Math.Pow(2, len - 1) - 1; // 111...111
            candidates[1] = (long)Math.Pow(2, len) + 1;     // 100...001
            
            string prefixStr = s.Substring(0, (len + 1) / 2);//prevent odd and even length
            long prefix = Convert.ToInt64(prefixStr, 2);

            int count = 2;
            //Mirroring 3 cases: 原数字前半部分-1, 0 , +1
            for (long i = -1; i <= 1; i++)
            {
                string p = Convert.ToString(prefix + i, 2);
                string candidateStr;
                
                char[] pArray = p.ToCharArray();
                Array.Reverse(pArray);
                string rev = new string(pArray);

                if (len % 2 == 0)
                    candidateStr = p + rev;
                else
                    candidateStr = p + rev.Substring(1);

                candidates[count++] = Convert.ToInt64(candidateStr, 2);
            }
           
            long minDiff = long.MaxValue;
            
            foreach (long cand in candidates)
            {                
                long diff = Math.Abs(cand - n);
                minDiff = Math.Min(minDiff, diff);                
            }

            return (int)minDiff;
        }