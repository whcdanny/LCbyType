//167. Two Sum II - Input Array Is Sorted med
//给一个非递减顺序排列的数组，给一个目标值 需要找出哪两个位置的数值相加=目标值
//思路：从left和right开始相加，如果sum大于目标值，那么right--，如果sum小于目标值，那么left++；
public int[] TwoSum(int[] numbers, int target)
            {
                // 一左一右两个指针相向而行
                int left = 0;
                int right = numbers.Length - 1;
                int sum = 0;
                while (left < right)
                {
                    sum = numbers[left] + numbers[right];
                    if (sum == target)
                        // 题目要求的索引是从 1 开始的
                        return new int[] { left + 1, right + 1 };
                    else if (sum < target)
                        left++;// 让 sum 大一点
                    else
                        right--;// 让 sum 小一点
                }
                return new int[] { };
            }