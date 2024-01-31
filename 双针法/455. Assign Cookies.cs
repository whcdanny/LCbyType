//Leetcode 455. Assign Cookies ez
//题意：描述了一个分发饼干的问题。假设你是一个很棒的家长，想要给你的孩子一些饼干。但是，你应该给每个孩子至多一块饼干。
//每个孩子 i 有一个贪婪因子 g[i]，这是孩子对饼干的最小满足程度；每块饼干 j 有一个大小 s[j]。如果 s[j] >= g[i]，我们可以将饼干 j 分配给孩子 i，孩子 i 就会满足。
//你的目标是最大化你满足的孩子数量，并输出这个最大数量。
//思路：双指针，对孩子的贪婪因子数组 g 和饼干的大小数组 s 进行排序，以便于后续比较。
//使用两个指针 i 和 j 分别表示当前处理的孩子和饼干。
//在循环中，如果当前饼干满足当前孩子的贪婪因子条件，将 contentChildren 的数量增加，并将 i 指针向后移动一个位置。
//不论是否满足，都将 j 指针向后移动一个位置。
//循环直到遍历完孩子或饼干数组。
//时间复杂度：O(nlogn)。排序的时间复杂度为 O(nlogn)，遍历数组的时间复杂度为 O(n)
//空间复杂度：O(1)
        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);

            int contentChildren = 0;
            int i = 0; // Pointer for children
            int j = 0; // Pointer for cookies

            while (i < g.Length && j < s.Length)
            {
                if (s[j] >= g[i])
                {
                    contentChildren++;
                    i++;
                }
                j++;
            }

            return contentChildren;
        }