//Leetcode 275. H-Index II med
//题意：给定一个按照升序排列的论文引用数组 citations，写出一个函数来计算这篇论文的 h 指数。
//h 指数的定义：如果一个学者有 h 篇论文，每篇论文被引用了至少 h 次，且其余的论文被引用次数不超过 h 次，则这个学者的 h 指数为 h。
//思路：二分搜索：我们比较 citations[mid] 和 n - mid。如果 citations[mid] >= n - mid，说明当前位置 mid 满足 h 指数的条件，我们缩小右边界。
//如果 citations[mid] < n - mid，说明当前位置 mid 不满足 h 指数的条件，我们缩小左边界。最终我们找到的是第一个满足条件的位置。
//时间复杂度：O(log N) 
//空间复杂度：O(1)
        public int HIndex(int[] citations)
        {
            int n = citations.Length;
            int left = 0, right = n - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (citations[mid] == n - mid)
                {
                    return n - mid;
                }
                else if (citations[mid] < n - mid)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return n - left;
        }