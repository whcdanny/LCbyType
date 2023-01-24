//283. Move Zeroes ez
//将所给的数组中的“0”全部移到数组最后面
//思路：相当于找出所以不是0的数然后再将剩下空余位置全部填充为0
//slow现存所以非0的数，这时slow的总长肯定比所给的数组总长小，那么剩下的全部set0
			public void MoveZeroes(int[] nums)
            {
                // 去除 nums 中的所有 0，返回不含 0 的数组长度
                int p = RemoveElement(nums, 0);
                // 将 nums[p..] 的元素赋值为 0
                for (; p < nums.Length; p++)
                {
                    nums[p] = 0;
                }
            }
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