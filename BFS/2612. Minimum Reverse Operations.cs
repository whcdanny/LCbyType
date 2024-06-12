//Leetcode 2612. Minimum Reverse Operations hard
//题意：给定一个整数 n 和一个整数 p（范围在 [0, n - 1] 之间），
//表示一个长度为 n 的数组 arr，其中所有位置的值都为 0，除了位置 p 的值设为 1。
//同时，给定一个整数数组 banned，包含一些禁用的位置。对于 banned 中的每个位置 i，arr[banned[i]] = 0，且 banned[i] != p。
//可以在 arr 上执行多次操作。在每次操作中，可以选择一个大小为 k 的子数组并将其反转。但是，arr 中的值 1 不能移到 banned 中的任何位置。
//换句话说，在每次操作后，arr[banned[i]] 仍然保持为 0。
//返回一个数组 ans，其中对于每个 i 在[0, n - 1] 范围内，ans[i] 表示将 1 移动到位置 i 所需的最小反转操作次数，如果不可能移动则为 -1。
//子数组是数组中连续的非空序列。ans[i] 的值对所有 i 来说是独立的。反转一个数组是将数组中的值以相反的顺序排列。
//思路：广度优先搜索（BFS）遍历树，此题类似于jump game，
//从起点开始，根据滑窗的不同位置，可以将1移动到多个不同的地方。
//然后下一轮，再根据滑窗的不同位置，可以将1继续移动到不同的地方。
//依次类推，可以用BFS求出1到达各个位置所用的最短步数（也就是用了几轮BFS）。
//我们假设1的初始位置是i，滑窗的左右边界是L和R（且R-L+1=k），那么1就可以通过翻转从i到新位置j = L+R-i = 2*L-i-1，这是一个仅关于L的函数。
//考虑滑窗长度固定，且必须包含位置i，所以L的最左边可以到达i-k+1，最右边可以到达i。
//此外，L不能越界，即必须在[0, n - 1] 内，所以L的左边界其实是L0=max(0, i-k+1)，右边界其实是min(i, n-1). 
//于是对应的j的移动范围就是2* L0-i-1到2* L1-i-1之间，并且随着L从小到大移动，j的变动始终是+2.
//BFS的时候，最大的问题就是，我们通过i进行一次revert得到的j会有很多位置（因为滑窗可以运动），其中很多j可能是之前已经遍历过的（也就是已经确定了一个更少的步数就可以到达），
//我们需要挨个检验的话时间复杂度就会很高。
//本题有巧解。对于一次revert，j的候选点的编号要么都是同奇数（要么都是偶数），并且在奇数（或者偶数）意义上是连续的！
//所以我们事先将所有编号是奇数的点作为一个集合odd，将所有编号是偶数的点作为一个集合even，
//那么这次revert相当于在odd（或者even）上删除一段区间range（删除意味着遍历过）。
//只要集合是有序的，那么我们就可以很快定位到range在集合里的位置，将range在集合里面的元素都删除。
//因为每个元素只会在集合里最多被删除一次（以后的range定位都不会涉及已经删除的元素），
//所以我们可以用近乎线性的时间知道每个元素是在什么时候从集合里删除的，这就是可以到达的最小步数。
//对于banned里面的元素，只需要实现从odd和even里排除即可。
//时间复杂度: O(n)
//空间复杂度：O(1)
        public int[] MinOperations1(int n, int p, int[] banned, int k)
        {            
            HashSet<int> bannedSet = new HashSet<int>(banned);
            //奇数，偶数两个点，因为无论滑窗怎么变化，i可以替换的就是偶数反转到奇数，奇数反转到偶数，所以分成两组；
            SortedSet<int>[] sets = new SortedSet<int>[2];
            for (int i = 0; i < 2; i++)
                sets[i] = new SortedSet<int>();
            //存入index不在p和不在banned的位置，并根据其位置的奇偶数来存入不同的list里；
            for (int i = 0; i < n; i++)
            {
                if (i != p && !bannedSet.Contains(i))
                    sets[i % 2].Add(i);
            }
            int[] res = new int[n];
            Array.Fill(res, -1);
            //从p开始，滑动窗口，然后根据奇偶性反转；
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(p);           
            for (int step = 0; queue.Count > 0; step++)
            {
                Queue<int> newqueue = new Queue<int>();
                while (queue.Count > 0)
                {
                    int i = queue.Dequeue();
                    res[i] = step;
                    //[L,R]=>因为间距是k固定了，所以R-L+1=k；R = K+L-1;
                    //如果i位1的位置，j = R-(i-L)=>R+L-i;=> 2L+K-1-i;
                    //因为i在[L,R]区间内最左边是i-k+1，最右边就是i；
                    //并L不能越界就是[0,n-1];
                    //所以对于i的left是由范围，right也有个范围
                    //然后找到相对应的j的left范围和right范围；
                    //然后就找出根据i的j的left和right然后这些数字都可以加入queue；
                    int l = Math.Max(0, i - k + 1);
                    int left = (2 * l + k - 1) - i;//Math.Max(i - k + 1, k - i - 1);
                    int r = Math.Min(n - k, i);
                    int right = (2 * r + k - 1) - i;//Math.Min(i + k - 1, n * 2 - k - i - 1);
                    SortedSet<int> view = new SortedSet<int>(sets[left % 2].GetViewBetween(left, right));
                    foreach (int it in view)
                        newqueue.Enqueue(it);
                    sets[left % 2].ExceptWith(view);
                }
                               
                queue = newqueue;
            }
            return res;
        }