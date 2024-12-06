//Leetcode 398. Random Pick Index med
//题意：给定一个可能包含重复数字的整数数组 nums，要求实现一个类 Solution，
//随机返回数组中指定数字 target 所在的索引。要求每个满足条件的索引被选中的概率是均等的。
//实现 Solution 类包括以下方法：
//Solution(int[] nums)：用数组 nums 初始化对象。
//int pick(int target)：从 nums 中随机选择一个索引 i，其中 nums[i] == target。
//如果有多个满足条件的索引，每个索引被选中的概率必须相等。
//思路：用Dictionary遍历 nums 数组，将每个元素及其位置存入一个 List
//在调用 pick 方法时，直接从Dictionar中找到map[target]
//然后随机rd.Next(indexList.Count);选出一个然后找到相对应的index
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public class Solution
        {
            Dictionary<int, List<int>> map;
            public Solution(int[] nums)
            {
                map = new Dictionary<int, List<int>>();
                for(int i = 0; i < nums.Length; i++)
                {
                    if (!map.ContainsKey(nums[i]))
                    {
                        map[nums[i]] = new List<int>();
                    }
                    map[i].Add(i);
                }
            }

            public int Pick(int target)
            {
                if (!map.ContainsKey(target))
                    return -1;
                List<int> indexList = map[target];
                Random rd = new Random();
                int rdNum = rd.Next(indexList.Count);
                return indexList[rdNum];
            }
        }

        /**
         * Your Solution object will be instantiated and called as such:
         * Solution obj = new Solution(nums);
         * int param_1 = obj.Pick(target);
         */