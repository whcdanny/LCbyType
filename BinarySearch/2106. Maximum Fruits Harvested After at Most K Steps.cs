//Leetcode 2106. Maximum Fruits Harvested After at Most K Steps hard
//题意：题目描述了一维坐标轴上有水果分布，用二维数组 fruits 表示，其中 fruits[i] = [positioni, amounti] 表示位置 positioni 处有 amounti 个水果。数组 fruits 已按位置 positioni 升序排列，且每个位置 positioni 均唯一。
//题目给定一个初始位置 startPos 和一个整数 k。初始时，你位于位置 startPos。从任意位置开始，你可以向左或向右走，每走一步在 x 轴上移动一个单位。你最多可以走 k 步。每到达一个位置，你可以收获该位置上的所有水果，并且这些水果将从该位置消失。
//题目要求返回你可以收获的水果的最大总数。
//思路：二分搜索+滑块窗口（sliding window），这里需要看code，逻辑就是这里是一个稳定的滑块；       
//时间复杂度: O(log n)
//空间复杂度：O(1)       
        public int MaxTotalFruits(int[][] fruits, int startPos, int k)
        {
            int n = fruits.Length;
            int[] posistions = new int[n];
            int[] preSum = new int[n];

            for(int i = 0; i < n; i++)
            {
                posistions[i] = fruits[i][0];
                preSum[i] = (i == 0 ? 0 : preSum[i - 1]) + fruits[i][1];
            }

            int res = 0;

            // A      S       B
            // i  x        y  j
            // 2x+y<=k
            //先向右再向左
            int mid = LowerBound(posistions, startPos, 0, n);
            //int j = 0;//j:A
            for (int i = mid; i < n; i++)//i:B
            {
                //B足够大，这样不可能先向右再向左；
                if (posistions[i] - startPos > k)
                    break;
                //要找的位置；根据2x+y<=k, x<=(k-y)/2, A位置 (k - (position[j] - startPos))/2;
                double dis = (k - (posistions[i] - startPos)) / 2;
                int j = LowerBound(posistions, startPos - (int)dis, 0, n);//
                if (j >= 0 && j < n)
                {
                    res = Math.Max(res, preSum[i] - (j == 0 ? 0 : preSum[j - 1]));
                }
                //while (posistions[j]<=startPos && posistions[i] - startPos + 2 * (startPos - posistions[j]) > k)
                //{
                //    j++;
                //    if (posistions[j] <= startPos)
                //    {
                //        res = Math.Max(res, preSum[i] - (j == 0 ? 0 : preSum[j - 1]));
                //    }
                //    else if (posistions[i] - startPos <= k)
                //    {
                //        res = Math.Max(res, preSum[i] - (j == 0 ? 0 : preSum[j - 1]));
                //    }
                //}
            }
            // B      S       A
            // i  y        x  j
            // 2x+y<=k
            //先向左再向右
            mid = UpperBound(posistions, startPos, 0, n)-1;
            //j = n - 1;
            for(int i= mid; i >= 0; i--)
            {
                //B足够大，这样不可能先向左再向右；
                if (startPos - posistions[i] > k)
                    break;
                //要找的位置；根据2x+y<=k, x<=(k-y)/2, A位置 (k - (startPos - position[j]))/2;
                double dis = (k - (startPos - posistions[i])) / 2;
                int j = UpperBound(posistions, startPos + (int)dis, 0, n) - 1;
                if (j >= 0 && j < n)
                {
                    res = Math.Max(res, preSum[j] - (i == 0 ? 0 : preSum[i - 1]));
                }
                //while (posistions[j] >= startPos && startPos - posistions[i] + 2 * (posistions[j] - startPos) > k)
                //{
                //    j--;
                //}
                //if (posistions[j] >= startPos)
                //{
                //    res = Math.Max(res, preSum[j] - (i == 0 ? 0 : preSum[i - 1]));
                //}
                //else if (startPos - posistions[i] <= k)
                //{
                //    res = Math.Max(res, preSum[j] - (i == 0 ? 0 : preSum[i - 1]));
                //}
            }
            return res;
        }
        //lower_bound函数用于查找在有序容器中第一个大于或等于给定值的元素的位置。
        public int LowerBound(int[] list, int value, int startIndex, int endIndex)
        {            
            int low = startIndex, high = endIndex;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                if (list[mid] < value)
                    low = mid + 1;
                else
                    high = mid;
            }

            return low;
        }
        //upper_bound函数用于查找在有序容器中第一个大于给定值的元素的位置。
        public int UpperBound(int[] list, int value, int startIndex, int endIndex)
        {            
            int low = startIndex, high = endIndex;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                if (list[mid] <= value)
                    low = mid + 1;
                else
                    high = mid;
            }

            return low;
        }


        //lower_bound函数用于查找在有序容器中第一个大于或等于给定值的元素的位置。
        static int LowerBound<T>(List<T> list, T value, int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            if (comparer == null)
                comparer = Comparer<T>.Default;

            int low = startIndex, high = endIndex;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                if (comparer.Compare(list[mid], value) < 0)
                    low = mid + 1;
                else
                    high = mid;
            }

            return low;
        }
        //upper_bound函数用于查找在有序容器中第一个大于给定值的元素的位置。
        static int UpperBound<T>(List<T> list, T value, int startIndex, int endIndex, IComparer<T> comparer = null)
        {
            if (comparer == null)
                comparer = Comparer<T>.Default;

            int low = startIndex, high = endIndex;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                if (comparer.Compare(list[mid], value) <= 0)
                    low = mid + 1;
                else
                    high = mid;
            }

            return low;
        }
        //upper_bound函数用于查找在有序容器中第一个大于给定值的元素的位置。
        private int upperBound(int[] list, int val)
        {
            int l = 0, r = list.Length - 1;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (list[m] <= val)
                    l = m + 1;
                else
                    r = m;
            }
            return l;
        }
        //lower_bound函数用于查找在有序容器中第一个大于或等于给定值的元素的位置。
        private int lowerBound(int[] list, int val)
        {
            int l = 0, r = list.Length - 1;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (list[m] < val)
                    l = m + 1;
                else
                    r = m;
            }
            return l;
        }