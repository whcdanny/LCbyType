//264. Ugly Number II med
//是一道找到第 n 个丑数的问题,这里丑数只能质因数是（既是约数，也是质数）2，3，5
//思路：三个指针 p2、p3 和 p5 来记录三个候选丑数在 uglyNumbers 数组中的位置;
        public int NthUglyNumber(int n)
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
        public int NthUglyNumber1(int n)
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