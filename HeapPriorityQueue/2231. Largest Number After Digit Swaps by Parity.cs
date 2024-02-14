//Leetcode 2231. Largest Number After Digit Swaps by Parity ez
//题意：给定一个正整数 num，允许对 num 中的任意两个具有相同奇偶性的数字进行交换，求交换后能得到的最大值。
//思路：PriorityQueue 用两个PriorityQueue来存odd和even，根据num把每一位存在相应的PriorityQueue；
//然后当我们从num的个位开始，先找到是odd还是even，然后从相对应的PriorityQueue提取出最小的元素，组成新的数字；        
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int LargestInteger(int num)
        {
            int n = num;
            var odd = new PriorityQueue<int, int>();
            var even = new PriorityQueue<int, int>();

            while (n > 0)
            {
                if ((n % 10) % 2 == 0)
                    odd.Enqueue(n % 10, n % 10);
                else
                    even.Enqueue(n % 10, n % 10);

                n = n / 10;
            }

            int ans = 0, multiple = 1;
            while (num > 0)
            {
                if ((num % 10) % 2 == 0)
                    ans += multiple * odd.Dequeue();
                else
                    ans += multiple * even.Dequeue();

                multiple = multiple * 10;
                num = num / 10;
            }

            return ans;
        }