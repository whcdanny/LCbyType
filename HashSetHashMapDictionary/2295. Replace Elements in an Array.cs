//Leetcode 2295. Replace Elements in an Array med
//题意：给定一个包含 n 个不同正整数的数组 nums，并且给定一组操作，每个操作包含两个正整数，表示要替换数组中的一个元素为另一个元素。其中，第一个正整数表示要被替换的元素，第二个正整数表示替换后的新元素。
//每个操作都有以下保证：
//要被替换的元素存在于数组 nums 中。
//替换后的新元素不存在于数组 nums 中。
//要求返回应用所有操作后得到的数组。
//思路：hashtable 把每个数值和相对应的位置存入，
//然后根据operation将相对应的位置的数进行修改，先找到位置，然后更换数，然后从map中移除之前的旧数字；
//时间复杂度：O(m + n)
//空间复杂度：O(m)
        public int[] ArrayChange(int[] nums, int[][] operations)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                map.Add(nums[i], i);
            }

            foreach (int[] op in operations)
            {
                int index = map[op[0]];
                nums[index] = op[1];
                map.Remove(op[0]);
                map.Add(op[1], index);
            }

            return nums;
        }