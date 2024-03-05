//Leetcode 2866. Beautiful Towers II med
//题意：给定一个长度为n的整数数组maxHeights，你需要在坐标轴上建造n座塔。第i座塔建在坐标i处，高度为heights[i]。
//如果满足以下条件，则一个塔的配置是美丽的：
//1 <= heights[i] <= maxHeights[i]
//heights是一个山脉数组。
//数组heights是山脉数组，如果存在一个索引i，使得：
//对于所有0<j <= i，heights[j - 1] <= heights[j]
//对于所有i <= k<n - 1，heights[k + 1] <= heights[k]
//要求返回一个美丽塔配置的最大可能高度总和。
//思路：Stack; 单调栈，用两个stack存入每个位置的当前的所以高度和，
//新元素比值前大，在之前的高度和+新加入的高度，
//如果新元素比之前有些值小，那么找到小或等于当前新元素的值，
//然后算出当前位置，也就是比新加入的值大的都移除，然后这部分移除的面积高度改成新加入的值；
//然后此时的和为比当前加入的值小的那部分高度，和移除后新添加的值和长度是移除的位置到新加入的位置；
//这样的方法从左往右算一遍，和从右往左算一遍；
//时间复杂度：O(n)，其中n为heights数组的长度，因为需要遍历整个heights数组。
//空间复杂度：O(n)，最坏情况下，栈的大小为heights数组的长度 
        public long MaximumSumOfHeights(IList<int> maxHeights)
        {
            var n = maxHeights.Count;
            var left = new long[n];
            var right = new long[n];

            var stack = new Stack<int>();

            for (var i = 0; i < n; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(i);
                    left[i] = (long)maxHeights[i];
                    continue;
                }

                while (stack.Count > 0 && maxHeights[i] < maxHeights[stack.Peek()]) 
                    stack.Pop();
                var idx = -1;
                if (stack.Count > 0) 
                    idx = stack.Peek();

                left[i] = (long)maxHeights[i] * (long)(i - idx);
                left[i] += idx >= 0 ? left[idx] : 0;
                stack.Push(i);
            }

            while (stack.Count > 0) 
                stack.Pop();

            for (var i = n - 1; i >= 0; i--)
            {
                if (stack.Count == 0)
                {
                    stack.Push(i);
                    right[i] = (long)maxHeights[i];
                    continue;
                }

                while (stack.Count > 0 && maxHeights[i] < maxHeights[stack.Peek()]) 
                    stack.Pop();
                var idx = n;
                if (stack.Count > 0) 
                    idx = stack.Peek();

                right[i] = (long)maxHeights[i] * (long)(idx - i);
                right[i] += idx < n ? right[idx] : 0;
                stack.Push(i);

            }
            //以i为选择的，来找最大值；
            long max = 0;
            for (var i = 0; i < n; i++)
            {
                max = Math.Max(max, left[i] - (long)maxHeights[i] + right[i]);
            }

            return (long)max;
        }