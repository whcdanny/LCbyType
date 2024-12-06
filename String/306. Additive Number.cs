//Leetcode 306. Additive Number med
//题目：累加数是一个数字字符串，满足它的数字可以形成一个 累加序列。
//一个合法的 累加序列 至少包含三个数字。
//除了前两个数字外，序列中的每个数字必须等于其前两个数字的和。
//数字序列中的数字不能有前导零（例如，1, 02, 3 或 1, 2, 03 是无效的）。
//任务：给定一个仅包含数字的字符串，判断它是否是一个累加数。
//思路: 分段字符，因为要是连续的相加，所以我们需要找开头两个剩下的一直检查就好
//这里i,j表示选择数字的长度
//那么先要确定num1范围最多从[0,n/2],因为两个等位的数字相加至少等位，10+20=30，        
//num1 = long.Parse(num.Substring(0, i)); 
//num2[1,(n - i - j >= i && n - i - j >= j)]我们剩下的位置至少要满足i或j的长度
//num2 = long.Parse(num.Substring(i, j));
//然后进行比较将sum = num1 + num2;转换成string
//然后remaining.StartsWith(sumStr)，
//然后isValid_IsAdditiveNumber(num2, sum, remaining.Substring(sumStr.Length)
//直到remaining.Length == 0
//时间复杂度：O(n^3)
//空间复杂度：O(n)
        public bool IsAdditiveNumber(string num)
        {            
            int n = num.Length;
            for(int i = 1; i <= n / 2; i++)
            {
                if (num[0] == '0' && i > 1)
                    continue;
                long num1 = long.Parse(num.Substring(0, i));

                for(int j = 1; n - i - j >= i && n - i - j >= j; j++)
                {
                    if (num[i] == '0' && j > 1)
                        continue;
                    long num2 = long.Parse(num.Substring(i, j));
                    if(isValid_IsAdditiveNumber(num1, num2, num.Substring(i + j))){
                        return true;
                    }
                }
            }           
            return false;
        }

        private bool isValid_IsAdditiveNumber(long num1, long num2, string remaining)
        {
            if (remaining.Length == 0)
                return true;
            long sum = num1 + num2;
            string sumStr = sum.ToString();
            if (!remaining.StartsWith(sumStr))
                return false;
            return (isValid_IsAdditiveNumber(num2, sum, remaining.Substring(sumStr.Length)));
        }