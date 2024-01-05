//Leetcode 1712. Ways to Split Array Into Three Subarrays med
//题意：对于一个非负整数数组 nums，定义好的切分满足以下条件：
//数组被切分为三个非空连续子数组，分别命名为 left、mid、right，从左到右。
//left 的元素之和小于等于 mid 的元素之和，mid 的元素之和小于等于 right 的元素之和。
//现在给定一个数组 nums，要求计算满足条件的切分的数量，由于可能很大，返回对 109 + 7 取模的结果。
//思路：用二分法：计算前缀和数组 nums，以便在 O(1) 时间内得到任意子数组的和。 
//先确认一共区间 长度i，第二个区间找到>=第一个区间j下限是这个，上限是不能让第三个区间<第二个区间和 k为上限；此时当固定i之后有k-j+1这么多的可能性；
//时间复杂度: O(N log N)，其中 N 是数组的长度
//空间复杂度：O(n)

        public int WaysToSplit(int[] nums)
        {
            var res = 0;
            var mod = 1000000007;
            var n = nums.Length;

            for (var i = 1; i < n; i++)
            {
                nums[i] += nums[i - 1];
            }
            //固定i，然后找第一个和第二个分界线；
            for (var i = 0; i < n - 2; i++)
            {
                var start = -1;
                var end = -1;

                var low = i + 1;
                var high = n - 2;

                while (low <= high)
                {
                    var j = low + (high - low) / 2;

                    if (nums[j] - nums[i] >= nums[i])
                    {
                        start = j;
                        high = j - 1;
                    }
                    else
                    {
                        low = j + 1;
                    }
                }

                if (start == -1) continue;
                high = n - 2;

                while (low <= high)
                {
                    var k = low + (high - low) / 2;

                    if (nums[k] - nums[i] > nums[n - 1] - nums[k])
                    {
                        high = k - 1;
                    }
                    else
                    {
                        end = k;
                        low = k + 1;
                    }
                }

                if (end == -1) continue;
                //固定i之后有这么多的可能性；
                res = (res + (end - start + 1)) % mod;
            }

            return res;
        }