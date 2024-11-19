//Leetcode 1354. Construct Target Array With Multiple Sums hard
//题意：给定一个长度为 n 的目标数组 target，判断是否可以通过一系列操作将一个初始数组 arr 转变为 target。
//具体来说，初始数组 arr 包含 n 个元素，每个元素都为 1。操作规则如下：
//计算当前数组 arr 中所有元素的和 x。
//选择一个索引 i，其中 0 <= i<n，并将 arr[i] 的值设置为 x。
//可以重复以上步骤任意次。
//如果可以通过一系列操作将初始数组 arr 转变为目标数组 target，则返回 true，否则返回 false。
//思路：PriorityQueue, 逆向思维，因为我们每次都要给最大值，
//所以最后一组的时候：x+x+x+a; 此时a为target中的最大值；a = x+x+x+b;
//找到倒数第二组：x+x+x+b; 我们需要通过一定方法得到b；所以others就是x+x+x
//注：由于a可能很大，所以正常逻辑是b=a-others 但是由于a可能很大，导致后面很多操作都是a还是最大
//所以b=a%others; 然后更新sum=b+others；
//时间复杂度: O(nlogn)
//空间复杂度：O(n)
        public bool IsPossible(int[] target)
        {           
            PriorityQueue<long, long> pq = new PriorityQueue<long, long>();
            long sum = 0L;
            foreach(int x in target)
            {
                sum += x;
                pq.Enqueue(x, -x);
            }
            while (pq.Peek() != 1)
            {
                //先找位置的数；
                long a = pq.Peek();
                pq.Dequeue();
                long others = sum - a;
                if (others == 0)
                    return false;
                if (a <= others)
                    return false;
                //这个位置之前的值；·
                long b = a % others;
                if (b == 0)
                    b = others;
                sum = others + b;
                pq.Enqueue(b, -b);
            }
            return true;
        }