//646. Maximum Length of Pair Chain med
//题目：给定一个由和组成的对n数组。pairspairs[i] = [lefti, righti]lefti < righti
//如果，则一对跟在一对p2 = [c, d] 后面。可以以此方式形成一对链。p1 = [a, b] b<c
//返回可以形成的最长链的长度。
//您不需要用完所有给定的间隔。您可以按任意顺序选择对。
//思路：排序数组，根据pairs[i][1]来排序，这样可以保证最小结束位置在最前面
//然后历遍，当当前的pairs[i][0] > cur 说明有效数组，
//然后更新cur = pairs[i][1]； res++        
//时间复杂度:  O(nlogn)
//空间复杂度： O(n)
        public int FindLongestChain(int[][] pairs)
        {            
            Array.Sort(pairs, (a, b) => a[1] == b[1] ? a[0]-b[0] : a[1]-b[1]);
            int n = pairs.Length;
            int cur = pairs[0][1];
            int res = 1;
            for(int i = 1; i < n; i++)
            {
                if (pairs[i][0] > cur)
                {
                    cur = pairs[i][1];
                    res++;
                }
            }
            
            return res;
        }