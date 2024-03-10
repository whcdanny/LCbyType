//Leetcode 2197. Replace Non-Coprime Numbers in Array hard
//题意：给定一个整数数组 nums。执行以下步骤：
//找到 nums 中任意两个相邻的非互质数NonCoprimes。
//如果找不到这样的数，则停止该过程。
//否则，删除这两个数，并用它们的最小公倍数（LCM）替换它们。
//重复以上步骤，直到找不到两个相邻的非互质数为止。
//返回最终修改后的数组。可以证明，以任意顺序替换相邻的非互质数都会得到相同的结果。
//思路：Stack,LCM最小公倍数,最大公约数GCD, 质数 存入最终答案，
//如果加入的num和stack最上面不是NonCoprimes，pop，然后那么找出LCM，然后存入
//时间复杂度：假设数组 nums 的长度为 n，计算 GCD 和 LCM 的时间复杂度为 O(log(min(a, b)))，入栈操作和出栈操作的时间复杂度为 O(n)，因此总的时间复杂度为 O(n log(min(a, b)))。
//空间复杂度：O(1)
        public IList<int> ReplaceNonCoprimes(int[] nums)
        {            
            Stack<int> s = new Stack<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                while (s.Count > 0 && !IsCoprime_ReplaceNonCoprimes(s.Peek(), val))
                    val = LCM_ReplaceNonCoprimes(val, s.Pop());
                s.Push(val);
            }
            List<int> res = new List<int>();
            while (s.Count > 0) res.Insert(0, s.Pop());
            return res;
        }

        private bool IsCoprime_ReplaceNonCoprimes(int a, int b)
        {
            return GCD_ReplaceNonCoprimes(a, b) == 1;
        }

        private int GCD_ReplaceNonCoprimes(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private int LCM_ReplaceNonCoprimes(int a, int b)
        {
            return a * (b / GCD_ReplaceNonCoprimes(a, b));
        }