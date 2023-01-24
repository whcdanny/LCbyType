//26. Remove Duplicates from Sorted Array ez
//移除重复元素，并给出总长度
//思路：使用快慢真，让slow总是存储新的val，最后算出总数；
public int RemoveDuplicates(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return 0;
                }
                int slow = 0, fast = 0;
                while (fast < nums.Length)
                {
                    if (nums[fast] != nums[slow])
                    {
                        slow++;
                        // 维护 nums[0..slow] 无重复
                        nums[slow] = nums[fast];
                    }
                    fast++;
                }
                // 数组长度为索引 + 1
                return slow + 1;
            }