//Leetcode 2226. Maximum Candies Allocated to K Children med
//题意：给定一个数组 candies，表示一些糖果堆的大小。你可以将每个糖果堆分成任意数量的子堆，但不能合并两个堆。现在，有 k 个孩子，你需要分配糖果堆，使得每个孩子获得的糖果数量相等。每个孩子最多只能取一个糖果堆，而有些糖果堆可能未被使用。
//要求返回每个孩子最多能获得的糖果数量。
//思路：二分搜索，left为1个糖果，right根据 糖果总和/小孩数量k；然后用总糖果数量来二分法，然后得到的数量要进一步去算是否能给到k个孩子；
//注：这里需要算二分法之后的糖果数量是否满足给到k个孩子
//时间复杂度: O(log(sum(candies)))
//空间复杂度：O(1)
        public int MaximumCandies(int[] candies, long k)
        {
            long left = 1;
            long right = 0;

            long sum = 0;
            foreach (var candy in candies)
            {
                sum += candy;
            }

            right = sum / k;
            var answer = 0;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                var count = CalculateCandies(mid, candies);
                //不满足减少最大值；
                if (count < k)
                {
                    right = mid - 1;
                }
                else
                {
                    answer = (int)mid;
                    left = mid + 1;
                }
            }

            return answer;
        }
        //根据当前分配糖果数量，看看总共能分成几堆儿；
        long CalculateCandies(long mid, int[] candies)
        {
            long count = 0;

            foreach (var candy in candies)
            {
                if (candy >= mid)
                {
                    count += candy / mid;
                }
            }

            return count;
        }
