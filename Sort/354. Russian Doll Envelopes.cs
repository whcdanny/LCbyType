//354. Russian Doll Envelopes hard
//题目：给你一个二维整数数组 envelopes，其中 envelopes[i] = [wi, hi] 表示第 i 个信封的宽度和高度。
//如果一个信封可以装入另一个信封，条件是：
//这个信封的宽度和高度都小于另一个信封的宽度和高度。
//返回可以嵌套的最大信封数量（即俄罗斯套娃信封的最大数量）。
//思路：排序 + 二分搜索 + 寻找最长递增子序列（LIS）：
//首先对信封按照宽度 w 进行升序排序；
//如果宽度相同，则按照高度 h 降序排序。
//这样，宽度相同的信封不会被错误嵌套。
//寻找最长递增子序列（LIS）：
//通过 minValue 数组维护高度的递增子序列；
//使用二分查找插入或更新序列的位置，从而保证序列的递增性。
//遍历信封的高度：
//如果当前信封的高度 value 大于当前子序列末尾值 minValue[pos]，说明可以扩展序列长度：
//增加 pos，并将 value 添加到 minValue。
//如果当前高度不能扩展序列长度（value 小于或等于 minValue[pos]），
//在当前序列中找到第一个大于或等于 value 的位置 l，然后替换为 value。
//时间复杂度:  O(n log n)
//空间复杂度： O(n)
        public int MaxEnvelopes(int[][] envelopes)
        {
            Array.Sort(envelopes, (v1, v2) => v1[0] == v2[0] ? v2[1] - v1[1] : v1[0] - v2[0]);
            int n = envelopes.Length;
            var minValue = new int[n];
            minValue[0] = envelopes[0][1];
            //pos 表示递增子序列的最后一个有效位置索引
            int pos = 0;
            for(int i = 1; i < n; i++)
            {
                int value = envelopes[i][1];
                if (minValue[pos] < value)
                {
                    pos++;
                    minValue[pos] = value;
                    continue;
                }
                int left = 0;
                int right = pos;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (minValue[mid] >= value)
                        right = mid;
                    else
                        left = mid + 1;
                }
                minValue[left] = value;
            }
            return pos + 1;
        }