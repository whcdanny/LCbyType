//Leetcode 2680. Maximum OR med
//题意：你有一个长度为 n 的整数数组 nums 和一个整数 k。在一次操作中，你可以选择数组中的一个元素并将其乘以 2。
//在最多进行 k 次操作之后，返回 nums[0] | nums[1] | ... | nums[n - 1] 的最大可能值。这里，a | b 表示 a 和 b 的按位或操作。
//思路：显然最贪心的策略是，我们将最高位的bit 1推地越远越好，最终的答案一定最大。
//所以直观上，我们应该把k次机会都给最大的元素，才能更高效地提升最高位的1。
//但是从例子中可以发现，如果有多个元素都含有相同最高位的1，不见得推最大元素是最优解。
//那么没关系，我们每个元素都试一下抬高k位的效果，取最大值即可。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public long MaximumOr(int[] nums, int k)
        {
            int[] count = new int[32];

            // 统计每个位上的1的数量
            foreach (var num in nums)
            {
                for (int j = 0; j < 32; j++)
                {
                    //num再j位是不是1
                    if ((num >> j & 1) == 1)
                    {
                        count[j]++;
                    }
                }
            }
            //对于每个元素，我们计算它被乘以 2 的多种可能性，并更新临时 OR 值 ans。将所有可能性与其他元素的 OR 结果结合起来，并更新 ret。
            long res = 0;
            foreach (var num in nums)
            {
                int[] temp = (int[])count.Clone();
                //先移除num从count里面，剩下的就是其他数字；
                for (int j = 0; j < 32; j++)
                {
                    //num再j位是不是1
                    if ((num >> j & 1) == 1)
                    {
                        temp[j]--;
                    }
                }

                long ans = 0;
                for (int j = 0; j < 32; j++)
                {
                    if (temp[j] > 0)
                    {
                        //1L << j 表示将1左移 j 位，这相当于在第 j 位上设置1。比如，1L << 0 是 1，1L << 1 是 2，1L << 2 是 4，以此类推。
                        //ans += (1L << j) 的意思是，将当前位的1加入到 ans 中，这样就可以构建出当前状态下的 OR 值。
                        ans += (1L << j);
                    }
                }
                //num推高k位；
                ans |= ((long)num << k);
                res = Math.Max(res, ans);
            }

            return res;
        }