//Leetcode 2216. Minimum Deletions to Make Array Beautiful med
//题意：给定一个整数数组 nums，数组 nums 被称为美丽的，如果满足以下条件：
//nums.length 是偶数。
//对于所有的 i 满足 i % 2 == 0，都有 nums[i] != nums[i + 1]。
//注意：空数组也被视为美丽的。
//你可以从 nums 中删除任意数量的元素。当你删除一个元素时，被删除元素右侧的所有元素将向左移动一个单位以填补创建的间隙，并且被删除元素左侧的所有元素将保持不变。
//返回删除 nums 中元素的最小数量，使其成为美丽数组。
//思路：Stack, 用于存入提出不满足条件的数之和的nums，
//如果stack为空，第一个直接加入，然后如果stack位置是奇数，位置要添加的就是偶数位的nums，所以stack.Peek() == nums[i]那么意思我们要删除的;
//注：最后输出答案的时候要检查stack，是否为偶数，如果不是res++；
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MinDeletion(int[] nums)
        {            
            Stack<int> stack = new Stack<int>();
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(nums[i]);
                    continue;
                }
                if (stack.Count % 2 != 0)
                {
                    if (stack.Peek() == nums[i])
                    {
                        res++;
                        continue;
                    }
                }
                stack.Push(nums[i]);
            }
            return (stack.Count % 2 != 0 ? ++res : res);
        }