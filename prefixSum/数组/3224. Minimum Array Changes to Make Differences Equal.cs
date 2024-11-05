//Leetcode 3224. Minimum Array Changes to Make Differences Equal med
//题目：给定一个长度为偶数的整数数组 nums 和一个整数 k。
//你可以对数组进行一些更改，每次更改可以将数组中的任意元素替换为 0 到 k 范围内的任意整数。
//目标是进行一些更改（可能不进行任何更改），使得最终数组满足以下条件：
//存在一个整数 X，使得对于所有 0 <= i<n，都有 |nums[i] - nums[n - i - 1]| = X。
//要求返回满足条件所需的最小更改次数。
//思路: preSum，先allX记录下所有|nums[i] - nums[n - i - 1]| = X差值；
//然后diffFr记录diff出现的个数，
//然后maxDiffFr最重要的就是找出最大差值的个数，然后这个做preSum，表示记录了最大差值不超过 i 的对数
//通过maxDiffFr[x - 1]找出2次的更新，再找1次的值(n / 2) - two，最后是exact
//Math.Min(ans, (two * 2) + (one - exact)); // two对需要2次操作，one对最多1次操作
//时间复杂度：O(n)
//空间复杂度：O(k+1)
        public int MinChanges(int[] nums, int k)
        {
            HashSet<int> allX = new HashSet<int>();
            int n = nums.Length, ans = n;
            int[] diffFr = new int[k + 1]; // 记录差值恰好等于diff的对数
            int[] maxDiffFr = new int[k + 1]; // 记录最大差值为maxDiff的对数

            // 遍历每对对称位置的元素，计算差值和最大可能差值
            for (int i = 0, j = n - 1; i < j; i++, j--)
            {
                int diff = Math.Abs(nums[i] - nums[j]);
                int maxDiff = Math.Max(Math.Max(nums[i], nums[j]), k - Math.Min(nums[i], nums[j]));

                // 将差值添加到哈希集allX中，并记录在对应频率数组中
                allX.Add(diff);
                diffFr[diff]++;
                maxDiffFr[maxDiff]++;
            }

            // 构建前缀和数组，累计到每个位置的最大差值频率
            for (int i = 1; i <= k; i++)
            {
                maxDiffFr[i] += maxDiffFr[i - 1];
            }

            // 遍历所有差值x
            foreach (int x in allX)
            {
                int two = x > 0 ? maxDiffFr[x - 1] : 0; // 需要2次操作的对数
                int one = (n / 2) - two; // 至多需要1次操作的对数
                int exact = diffFr[x]; // 差值正好为x的对数

                // 计算当前x下的最小更改次数
                ans = Math.Min(ans, (two * 2) + (one - exact)); // two对需要2次操作，one对最多1次操作
            }

            return ans;
        }