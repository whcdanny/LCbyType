//Leetcode 167. Two Sum II - Input Array Is Sorted med
//题意：给定一个已按升序排序的整数数组 numbers，找到两个数使得它们相加之和等于特定目标数 target。
//函数应该返回这两个下标（从1开始计数），其中 index1 必须小于 index2。
//注意：你可以假设每个输入都只有一个解决方案，而且你不能使用相同的元素两次。
//思路：二分搜索：左右两个指针，left 初始为数组开头，right 初始为数组末尾。
//计算 sum，即 numbers[left] + numbers[right]。
//如果 sum 等于 target，返回[left + 1, right + 1]。
//如果 sum 小于 target，将 left 指针向右移动一位。
//如果 sum 大于 target，将 right 指针向左移动一位。
//重复步骤2到步骤5，直到找到目标或 left 大于等于 right。
//时间复杂度：O(log N) - 二分搜索法。
//空间复杂度：O(1)
        public int[] TwoSum(int[] numbers, int target)
        {
            int left = 0, right = numbers.Length - 1;

            while (left < right)
            {
                int sum = numbers[left] + numbers[right];

                if (sum == target)
                {
                    return new int[] { left + 1, right + 1 };
                }
                else if (sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            // 如果没有找到，返回空数组
            return new int[0];
        }