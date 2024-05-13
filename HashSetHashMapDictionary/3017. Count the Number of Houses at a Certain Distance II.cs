//Leetcode 3017. Count the Number of Houses at a Certain Distance II hard
//题意：在一个城市里，有编号从1到n的房子，它们通过n条街道相连。
//对于所有1 <= i <= n - 1，房子编号为i的房子与编号为i + 1的房子之间有一条街道。
//另外，还有一条街道连接着编号为x和编号为y的两个房子。
//对于每个k，其中1 <= k <= n，你需要找出一对房子（house1，house2），使得从house1到house2需要行驶的最小街道数为k。
//返回一个长度为n的1索引数组result，其中result[k] 表示一对房子的总数，使得从一个房子到另一个房子所需的最小街道数为k。
//思路：贪婪算法：我们画一个示意图，将图划分为ABC三个区域，其中[x,y]部分为C。
//A-A-A-C(x)-C------C-C(y)-B-B-B
//      |______________|
//任意两个房子之间的最短距离，可以落入如下六个分类之中, AA,BB,AC,BC,AB,CC.
//AA：对于长度为a个房子的简单串联，里面有多少对距离为t的配对呢？我们记做helper0(a)
//对于一个合法配对，将第一个房子记做i，则另一个房子记做i+t，那么要求
//i>=1
//i+t<=a
//得到i的范围是[1, a - t]. 故对于距离t，我们可以增加a-t个配对（暂时不计首尾互换的重复路径）
//BB，计算方法同AA。
//AC：这部分是由一个长度为a的长链，加上一个长度为d的圆环。里面有多少对距离为t的配对呢？
//显然，对于处于圆环上的点，为了与A实现最短距离，我们会根据它们离圆环入口x的位置，平均拆分成两半。
//这样就行程了三叉的形状：一条单链长度是a+1，然后接着两条支链，长度分别是d/2和(d-1)/2.
//对于在单链上的任意一点i，与长度为p的支链上的任意一点（不包括x点）能组成合法配对的条件是
//1<=i<=a
//a+2<=i+t<=a+1+p        
//得到i的范围是[max(1, a + 2 - t), min(a, a + p + 1 - t)]. 由此可以计算出有多少个配对。
//同理，可以计算单链上的任意一点，与长度为c的另一条支链上的任意一点（不包括x点）能组成的合法配对。
//此外，我们需要单独出计算单链上的任意一点i，到x点能组成的合法配对。
//单独计算这个是为了避免在处理两条支链时重复计算。
//i>=1
//i+t==a+1
//即需要满足t<=a时，可以增加一个配对。
//BC，计算方法同AC
//AB，计算方法类似AA。假设A的部分长度是a，B的部分长度是b，中间间隔了2（因为x和y相连）。里面有多少对距离为t的配对呢？我们记做helper2(a)
//对于在A上的任意一点i，与B上的任意一点能组成合法配对的条件是
//i>=1
//i<=a
//i+t>=a+3
//i+t<=a+2+b
//得到i的范围是[max(1, a + 3 - t), min(a, a + b + 2 - t)]. 由此可以计算出有多少个配对。
//CC，此部分是一个长度为d的圆环，问里面有多少个长度为t的配对？
//对于圆环上任意一点i，顺时针走t步到达i+t的位置。这两个位置要形成一个有效配对，此时要保证它们的逆时针路径要小于t。即
//t<d-t
//对于满足这个要求的t，那么圆环上的任意一点都是可以合法配对的起点，故可以增加d个配对。
//比如说d= 4，那么当t= 1时的四个配对是[1, 2], [2,3], [3,4], [4,1].
//此时有一个特别需要注意的地方，当2* t==d时，虽然也可以增加d个配对，但是这d个配对里，已经包含了首尾颠倒的重复路径。
//比如说d= 4，那么当t= 2时的四个配对是[1, 3], [2,4], [3,1], [4,2]，可以其中包含了重复的路径。
//而我们之前所有情况的讨论，所计算的配对都是单向的（编号小的在前，编号大的在后），都是需要乘以2的。
//唯独这个情况下，我们不能再乘以2.
//将以上六种情况的计数全部加起来就是最终答案。
//时间复杂度: O(n)
//空间复杂度：O(n)
        int n_CountOfPairs = 0;
        long[] count_CountOfPairs = new long[100005];
        public long[] CountOfPairs(int n, int x, int y)
        {
            if (x > y)
                return CountOfPairs(n, y, x);
            n_CountOfPairs = n;
            List<long> res = new List<long>();

            if (Math.Abs(x - y) <= 1)
            {
                for(int t = 1; t <= n; t++)
                {
                    res.Add((n - t) * 2);
                }
                return res.ToArray();
            }
            //A-A-A-C(x)-C------C-C(y)-B-B-B
            //      | ______________ |
            f1(x - 1);
            f1(n - y);
            f2(x - 1, n - y);
            int mid = y - x + 1;
            f3(x - 1, (mid - 1) / 2, (mid - 1) - (mid - 1) / 2);
            f3(n - y, (mid - 1) / 2, (mid - 1) - (mid - 1) / 2);
            
            for(int t = 1; t <= n; t++)
            {
                count_CountOfPairs[t] *= 2;
            }
            f4(mid);
            for(int t = 1; t <= n; t++)
            {
                res.Add(count_CountOfPairs[t]);
            }

            return res.ToArray();
        }
        void f1(long a)
        {
            for (int t = 1; t <= n_CountOfPairs; t++)
            {
                long lower = 1;
                long upper = a - t;
                count_CountOfPairs[t] += Math.Max(0, upper - lower + 1);
            }
        }

        void f2(long a, long b)
        {
            for (int t = 1; t <= n_CountOfPairs; t++)
            {
                long lower = Math.Max(1, a + 3 - t);
                long upper = Math.Min(a, a + 2 + b - t);
                count_CountOfPairs[t] += Math.Max(0, upper - lower + 1);
            }
        }

        void f3(long a, long p, long q)
        {
            for (int t = 1; t <= n_CountOfPairs; t++)
            {
                long lower = Math.Max(1, a + 2 - t);
                long upper = Math.Min(a, a + 1 + p - t);
                count_CountOfPairs[t] += Math.Max(0, upper - lower + 1);
            }

            for (int t = 1; t <= n_CountOfPairs; t++)
            {
                long lower = Math.Max(1, a + 2 - t);
                long upper = Math.Min(a, a + 1 + q - t);
                count_CountOfPairs[t] += Math.Max(0, upper - lower + 1);
            }

            for (int t = 1; t <= n_CountOfPairs; t++)
            {
                if (a >= t)
                    count_CountOfPairs[t] += 1;
            }
        }

        void f4(long d)
        {
            for (int t = 1; t <= n_CountOfPairs; t++)
            {
                if (t < d - t)
                    count_CountOfPairs[t] += d * 2;
                else if (t == d - t)
                    count_CountOfPairs[t] += d;
            }
        }