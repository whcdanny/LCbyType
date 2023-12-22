//Leetcode 2251. Number of Flowers in Full Bloom hard
//题意：给定一个二维整数数组 flowers，其中 flowers[i] = [starti, endi] 表示第 i 朵花将在区间 [starti, endi] 内盛开。同时，给定一个整数数组 people，其中 people[i] 表示第 i 个人到达观赏花朵的时间。
//要求返回一个整数数组 answer，其中 answer[i] 表示第 i 个人到达时处于盛开状态的花朵数量。
//思路：二分搜索，做两个position的list，一个表示开始的，一个表示结束的；然后排序，这样根据people的位置对开始和结束的两个位置找，然后用开始的位置-结束的位置；
//注：这里要注意 用开始的位置-结束的位置，逻辑是当前people的我位置，我们算开始的二分法是知道在这之前有几朵花可能绽放，然后我们算结束的二分法是知道在这之前有几朵花凋零，这样此时我们就可以用总共绽放的减去已经凋零的；
//时间复杂度: O(m log m + n log n)，其中 m 是花朵数组的长度，n 是人员数组的长度
//空间复杂度：O(n)
        public int[] FullBloomFlowers(int[][] flowers, int[] people)
        {
            List<int> starts = new List<int>();
            List<int> ends = new List<int>();

            foreach (var flower in flowers)
            {
                starts.Add(flower[0]);
                ends.Add(flower[1] + 1);
            }

            starts.Sort();
            ends.Sort();
            int[] ans = new int[people.Length];

            for (int index = 0; index < people.Length; index++)
            {
                int person = people[index];
                int i = BinarySearch(starts, person);
                int j = BinarySearch(ends, person);
                ans[index] = i - j;
            }

            return ans;
        }

        public int BinarySearch(List<int> arr, int target)
        {
            int left = 0;
            int right = arr.Count;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (target < arr[mid])
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }