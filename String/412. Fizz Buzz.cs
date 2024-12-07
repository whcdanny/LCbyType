//Leetcode 412. Fizz Buzz ez
//题目：给定一个整数n，返回一个字符串数组answer（1索引），其中：
//answer[i] == "FizzBuzz"如果i能被3和整除5。
//answer[i] == "Fizz"如果i可以被 整除3。
//answer[i] == "Buzz"如果i可以被 整除5。
//answer[i] == i（作为字符串）如果以上条件都不成立。
//思路: 从1-n 根据不同情况给出不同答案
//时间复杂度：O(n)
//空间复杂度：O(n)
        public IList<string> FizzBuzz(int n)
        {
            List<string> res = new List<string>();
            for (int i = 0; i < n; i++)
            {
                res.Add(buildFizzBuzz(i));
            }
            return res;
        }

        private string buildFizzBuzz(int num)
        {
            if (num % 3 == 0 && num % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if(num % 3 == 0 && num % 5 != 0)
            {
                return "Fizz";
            }
            else if (num % 3 != 0 && num % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return num.ToString();
            }
        }        