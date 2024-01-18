//Leetcode 1577. Number of Ways Where Square of Number Is Equal to Product of Two Numbers med
//题意：给定两个整数数组 nums1 和 nums2，返回在以下规则下形成的三元组的数量（类型 1 和类型 2）：
//类型 1：三元组(i, j, k) 满足 nums1[i]^2 == nums2[j] * nums2[k]，其中 0 <= i<nums1.length，0 <= j<k<nums2.length。
//类型 2：三元组 (i, j, k) 满足 nums2[i]^2 == nums1[j] * nums1[k]，其中 0 <= i<nums2.length，0 <= j<k<nums1.length。
//思路：双指针,两个数组 nums1 和 nums2，对于每个数组中的元素，使用两个指针 left 和 right 在另一个数组中查找满足条件的元素。
//注：当我们找到left和right，满足条件的时候，因为有可能有重复 所以要判断个数 并且避免重复计算，这里先sortnum2
//如果arr2[left] == arr2[right] 那么就算left-right距离然后自然数之和，因为left有-left-1个选择除了自己，left+1就有right-left-1-1个选择除了自己 依此类推
//如果arr2[left] != arr2[right] 这样要算有多少个等于arr2[left] 和 arr2[right] 然后相当于每个arr[left]*arr[right]个数 所以是countLeft * countRight; 在算个数的时候注意left++和right--        
//时间复杂度：对于每个数组 nums1 和 nums2，排序数组的时间复杂度为 O(n log n)，遍历数组的时间复杂度为 O(n)，因此总时间复杂度为 O(n log n + n) = O(n log n)。
//空间复杂度：O(1)
        public int NumTriplets(int[] nums1, int[] nums2)
        {
            return CountTriplets(nums1, nums2) + CountTriplets(nums2, nums1);
        }
        private int CountTriplets(int[] arr1, int[] arr2)
        {
            int count = 0;
            Array.Sort(arr2);

            for (int i = 0; i < arr1.Length; i++)
            {
                long target = (long)arr1[i] * arr1[i];
                int left = 0, right = arr2.Length - 1;

                while (left < right)
                {
                    long product = (long)arr2[left] * arr2[right];

                    if (product == target)
                    {
                        if (arr2[left] == arr2[right])
                        {
                            // If left and right are same, choose 2 from duplicates
                            count += (right - left + 1) * (right - left) / 2;
                            break;
                        }
                        else
                        {
                            // If left and right are different, choose 1 from left and 1 from right
                            int countLeft = 1, countRight = 1;

                            while (left + 1 < right && arr2[left] == arr2[left + 1])
                            {
                                left++;
                                countLeft++;
                            }

                            while (right - 1 > left && arr2[right] == arr2[right - 1])
                            {
                                right--;
                                countRight++;
                            }

                            count += countLeft * countRight;
                            left++;
                            right--;
                        }
                    }
                    else if (product < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return count;
        }