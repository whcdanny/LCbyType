//Leetcode 295. Find Median from Data Stream hard
//题意：设计一个数据结构，支持以下两种操作：
//addNum(int num) - 将整数 num 添加到数据结构中。
//findMedian() - 返回当前所有元素的中位数。
//思路：用list，当addNum的时候，用二分搜索，找出应该插入的的位置
//list.Insert(index, num);
//当findMedian，直接看list是否奇数还是偶数，然后输出中位数；
//时间复杂度：Insert O(logN) Median O(1)
//空间复杂度：O(n)
        public class MedianFinder
        {

            List<int> list = new List<int>();
            public MedianFinder()
            {

            }

            public void AddNum(int num)
            {
                var index = InsertIndex(num);
                list.Insert(index, num);
            }

            private int InsertIndex(int num)
            {
                if (list.Count == 0)
                    return 0;

                var l = 0;
                var r = list.Count - 1;
                while (l <= r)
                {
                    var m = l + (r - l) / 2;
                    if (list[m] == num)
                        return m;
                    if (list[m] > num)
                        r = m - 1;
                    else
                        l = m + 1;
                }

                return l;
            }

            public double FindMedian()
            {
                var m = list.Count / 2;
                if (list.Count % 2 == 0)
                {
                    return ((double)list[m - 1] + (double)list[m]) / 2;
                }

                return list[m];
            }
        }

        /**
         * Your MedianFinder object will be instantiated and called as such:
         * MedianFinder obj = new MedianFinder();
         * obj.AddNum(num);
         * double param_2 = obj.FindMedian();
         */