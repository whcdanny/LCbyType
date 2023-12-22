//Leetcode 2300. Successful Pairs of Spells and Potions med
//题意：给定两个正整数数组 spells 和 potions，它们分别表示 n 个法术和 m 个药水的强度，其中 spells[i] 表示第 i 个法术的强度，potions[j] 表示第 j 个药水的强度。
//此外，给定一个整数 success。一个法术和药水的组合被认为是成功的，如果它们的强度的乘积至少为 success。
//要求返回一个长度为 n 的整数数组 pairs，其中 pairs[i] 表示第 i 个法术可以与多少个药水成功组合。        
//思路：二分搜索，先给potions排序，然后根据potions的位置进行二分，如果当前spell*potions[mid]>=success，那么就说明可能是答案，并且更新right，如果没大于，更新left；
//注：当你得出mid时，需要用potions总长度减去mid，因为mid之前都是小于success的，剩下的才是大于我们不需要再算的；
//时间复杂度: O(n log m)，其中 n 是法术数组的长度，m 是药水数组的长度
//空间复杂度：O(1)
        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            Array.Sort(potions);
            int[] res = new int[spells.Length];
            for (int i = 0; i < spells.Length; i++)
            {
                int left = 0, right = potions.Length - 1;
                int leftMost = -1;
                while (left <= right)
                {
                    int m = left + (right - left) / 2;
                    if (((long)spells[i]) * potions[m] >= success)
                    {
                        leftMost = m;
                        right = m - 1;
                    }
                    else left = m + 1;
                }
                res[i] = leftMost == -1 ? 0 : potions.Length - leftMost;
            }

            return res;
        }