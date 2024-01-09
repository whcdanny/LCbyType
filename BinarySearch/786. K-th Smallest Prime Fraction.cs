//Leetcode 786. K-th Smallest Prime Fraction med
//题意：给定一个按递增顺序排序的数组 A，以及一个整数 K，找出数组中第 K 小的素数分数。一个素数分数是两个不同的正整数的比值，其中分子和分母都是小于或等于数组 A 的元素。
//思路：二分搜索要: 
//二分搜索范围：使用二分搜索的思想，将素数分数的范围限定在[0, 1] 之间，通过调整 low 和 high 来进行二分搜索。
//二分搜索循环：使用一个无限循环，每次都计算中间值 mid，并在内层循环中统计满足条件的素数分数的数量。内层循环中使用双指针（i 和 j）来遍历数组，通过二分搜索找到满足条件的 j 值。
//在循环中维护一个计数器 count，记录小于等于 mid 的素数分数的数量。同时记录满足条件的最大素数分数的分子和分母，即 ansNum 和 ansDen。
//判断条件：如果 count 等于 k，说明找到了第 k 小的素数分数，返回结果。如果 count 大于 k，说明目标在左侧，更新 high 为 mid。如果 count 小于 k，说明目标在右侧，更新 low 为 mid。
//时间复杂度: O(log(high - low) * logN)，其中 N 是数组 arr 的长度
//空间复杂度：O(1)
        public int[] KthSmallestPrimeFraction(int[] arr, int k)
        {            
            double low = 0;
            double high = 1;
            while (true)
            {
                int ansNum = 0;
                int ansDen = 1;
                double mid = low + (high - low) / 2;
                int i = 0;
                int j = arr.Length - 1;
                int count = 0;

                while (i < arr.Length - 1 && j > 0)
                {                   
                    while (j > 0 && arr[i] > mid * arr[arr.Length - j])
                    {
                        j--;
                    }

                    count += j;
                    
                    if (j > 0 && arr[i] * ansDen >= ansNum * arr[arr.Length - j])
                    {
                        ansNum = arr[i];
                        ansDen = arr[arr.Length - j];
                    }

                    i++;
                }

                if (count == k)
                {
                    return new int[] { ansNum, ansDen };
                }
                else if (count > k)
                {
                    high = mid;
                }
                else
                {
                    low = mid;
                }
            }
        }