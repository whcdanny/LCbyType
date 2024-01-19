//Leetcode 923. 3Sum With Multiplicity med
//题意：给定一个整数数组 arr 和一个目标整数 target，要求找出数组中所有满足条件的三元组 (i, j, k)，其中 i < j < k 且 arr[i] + arr[j] + arr[k] 等于目标值 target。由于答案可能很大，要对结果取模 10^9 + 7。
//思路：双指针，三个指针 i, left, right 分别表示三元组中的第一个、第二个和第三个元素。
//固定 i，然后使用双指针 left 和 right 来寻找满足条件的三元组。
//在双指针移动的过程中，使用两个 while 循环来处理重复的元素，以避免重复计算
//注：在最开始要排序，并且要算出每个数字出现的频率 这样就好算i,j,k重复出现的总数
//时间复杂度： 排序的时间复杂度为 O(nlogn)，然后使用双指针法遍历数组，总体时间复杂度为 O(n^2)。
//空间复杂度：O(1)
        public int ThreeSumMulti(int[] arr, int target)
        {
            var freqmap = new Dictionary<int, long>();
            var mod = 1_000_000_007;

            Array.Sort(arr);
            foreach (var el in arr)
            {
                if (freqmap.ContainsKey(el))
                {
                    freqmap[el] += 1;
                }
                else
                {
                    freqmap.Add(el, 1);
                }
            }
            long sum = 0;
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var l = i + 1;
                var r = arr.Length - 1;

                while (l < r)
                {
                    var t = target - (arr[i] + arr[l]);
                    if (t == arr[r])
                    {
                        var n1 = freqmap[arr[i]];
                        var n2 = freqmap[arr[l]];
                        var n3 = freqmap[arr[r]];

                        if (arr[i] == arr[l] && arr[i] == arr[r])
                        {
                            // 3 freq
                            sum += (long)(n1 * (n1 - 1) * (n1 - 2)) / 6;

                        }
                        else if (arr[i] == arr[l])
                        {
                            // two freq
                            sum += (long)(n1 * (n1 - 1) * n3) / 2;

                        }
                        else if (arr[l] == arr[r])
                        {
                            sum += (long)(n2 * (n2 - 1) * n1) / 2;
                        }
                        else
                        {
                            // one freq
                            sum += n1 * n2 * n3;
                        }
                        while (r > l && arr[r] == arr[r - 1])
                        {
                            r -= 1;
                        }

                        r--;

                    }
                    else if (t > arr[r])
                    {
                        while (l < r && arr[l] == arr[l + 1])
                            l += 1;

                        l++;
                    }
                    else
                    {
                        while (r > l && arr[r] == arr[r - 1])
                            r -= 1;

                        r--;
                    }

                }
                while (i < arr.Length - 1 && arr[i] == arr[i + 1])
                    i += 1;

                sum = sum % mod;

            }
            return (int)sum;
        }