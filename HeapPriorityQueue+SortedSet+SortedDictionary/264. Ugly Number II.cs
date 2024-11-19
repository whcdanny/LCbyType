//Leetcode 264. Ugly Number II hard
//题意：编写一个程序，找到第 n 个丑数。丑数是只包含质因数 2、3 和 5 的正整数
//思路：一个最小堆 minHeap 和一个哈希集 set 来记录已经放入堆中的丑数。我们使用一个数组 primes 来存储质因数 2、3、5。然后，我们初始化 ugly 为 1，将其放入堆中，并加入哈希集。接着，我们开始循环，每次从堆中取出最小值，将其乘以 2、3、5 后放回堆中。重复这个过程直到得到第 n 个丑数。
//时间复杂度：将第一个丑数 1 放入队列，然后进行 n-1 次循环，每次循环都需要将最小的丑数出队并乘以 2、3、5 分别放回队列，这个操作的时间复杂度是 O(log n)。总的时间复杂度为 O(n* log n)。
//空间复杂度：O(n) 
        public int NthUglyNumber(int n)
        {
            PriorityQueue_NthUglyNumber<long> minHeap = new PriorityQueue_NthUglyNumber<long>();
            HashSet<long> seen = new HashSet<long>();

            int[] primes = new int[] { 2, 3, 5 };
            long current = 1;
            minHeap.Enqueue(current);
            seen.Add(current);

            for (int i = 0; i < n; i++)
            {
                current = minHeap.Dequeue();

                foreach (int prime in primes)
                {
                    long next = current * prime;
                    if (!seen.Contains(next))
                    {
                        minHeap.Enqueue(next);
                        seen.Add(next);
                    }
                }
            }

            return (int)current;
        }

        public class PriorityQueue_NthUglyNumber<T>
        {
            private SortedSet<T> set;

            public int Count
            {
                get { return set.Count; }
            }

            public PriorityQueue_NthUglyNumber()
            {
                set = new SortedSet<T>();
            }

            public void Enqueue(T item)
            {
                set.Add(item);
            }

            public T Dequeue()
            {
                T item = set.Min;
                set.Remove(item);
                return item;
            }

            public T Peek()
            {
                return set.Min;
            }
        }
        //思路：动态规划来解决。我们可以将丑数分为三类：只包含质因数 2 的丑数序列 ugly2，只包含质因数 3 的丑数序列 ugly3，以及只包含质因数 5 的丑数序列 ugly5。然后我们可以从这三个序列中选取下一个最小的丑数，并将其添加到对应的序列中
        //时间复杂度：O(n)，因为我们只需要从三个序列中选取最小值。
        //空间复杂度：O(n)。
        public int NthUglyNumber1(int n)
        {
            int[] ugly = new int[n];
            ugly[0] = 1;

            int p2 = 0, p3 = 0, p5 = 0;

            for (int i = 1; i < n; i++)
            {
                ugly[i] = Math.Min(Math.Min(ugly[p2] * 2, ugly[p3] * 3), ugly[p5] * 5);

                if (ugly[i] == ugly[p2] * 2) p2++;
                if (ugly[i] == ugly[p3] * 3) p3++;
                if (ugly[i] == ugly[p5] * 5) p5++;
            }

            return ugly[n - 1];
        }
        //264. Ugly Number II med
        //是一道找到第 n 个丑数的问题,这里丑数只能质因数是（既是约数，也是质数）2，3，5
        //思路：三个指针 p2、p3 和 p5 来记录三个候选丑数在 uglyNumbers 数组中的位置;
        public int NthUglyNumber2(int n)
        {
            int[] uglyNumbers = new int[n];
            uglyNumbers[0] = 1;
            int p2 = 0, p3 = 0, p5 = 0;
            int nextMultipleOf2 = 2, nextMultipleOf3 = 3, nextMultipleOf5 = 5;

            for (int i = 1; i < n; i++)
            {
                int min = Math.Min(nextMultipleOf2, Math.Min(nextMultipleOf3, nextMultipleOf5));
                uglyNumbers[i] = min;

                if (min == nextMultipleOf2)
                {
                    p2++;
                    nextMultipleOf2 = uglyNumbers[p2] * 2;
                }
                if (min == nextMultipleOf3)
                {
                    p3++;
                    nextMultipleOf3 = uglyNumbers[p3] * 3;
                }
                if (min == nextMultipleOf5)
                {
                    p5++;
                    nextMultipleOf5 = uglyNumbers[p5] * 5;
                }
            }

            return uglyNumbers[n - 1];
        }
        //思路：类似上面
        public int NthUglyNumber3(int n)
        {
            if (n <= 0)
                return 0;

            List<int> list = new List<int>();
            list.Add(1);

            int i = 0;
            int j = 0;
            int k = 0;

            while (list.Count < n)
            {
                int m2 = list[i] * 2;
                int m3 = list[j] * 3;
                int m5 = list[k] * 5;

                int min = Math.Min(m2, Math.Min(m3, m5));
                list.Add(min);
                if (min == m2)
                    i++;

                if (min == m3)
                    j++;

                if (min == m5)
                    k++;
            }

            return list[list.Count - 1];
        }