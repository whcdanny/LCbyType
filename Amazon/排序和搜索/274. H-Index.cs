//274. H-Index med
//题目：H-Index（H指数） 是用来衡量科研人员学术成果的指标。给定一个数组 citations，其中 citations[i] 表示某研究者的第 i 篇论文被引用的次数，返回该研究者的 H指数。
//根据维基百科上的定义：
//H指数是满足以下条件的最大整数h：该研究者的至少h 篇论文分别被引用了至少h 次，且其余的论文每篇的引用次数不超过h 次。
//思路：表示就是h篇文章用了h次，
//int[]先统计论文出现的次数，把citation >= n 全放入list[n]++;
//从高到低计算累计计数，如果count >= i 就说明找到h 篇论文分别被引用了至少h 次
//时间复杂度:  O(n)
//空间复杂度： O(n)
        public int HIndex(int[] citations)
        {
            int n = citations.Length;
            int[] list = new int[n + 1];

            // 统计每个引用次数的论文数
            foreach (int citation in citations)
            {
                if (citation >= n)
                {
                    list[n]++;
                }
                else
                {
                    list[citation]++;
                }
            }

            // 从高到低计算累计计数
            int count = 0;
            for (int i = n; i >= 0; i--)
            {
                count += list[i];
                if (count >= i)
                {
                    return i;
                }
            }

            return 0;
        }