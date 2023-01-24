//27. Remove Element ez
//从数组中移除指定的元素
//思路：用快慢针 如果快针找到指定元素就不让slow针添加
 public int RemoveElement(int[] nums, int val)
            {
                int fast = 0, slow = 0;
                while (fast < nums.Length)
                {
                    if (nums[fast] != val)
                    {
                        nums[slow] = nums[fast];
                        slow++;
                    }
                    fast++;
                }
                return slow;
            }