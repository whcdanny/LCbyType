//Leetcode 2766. Relocate Marbles med
//题意：给定一个初始位置为 nums 的整数数组，表示一些弹珠的初始位置。同时给定两个长度相同的整数数组 moveFrom 和 moveTo。
//在 moveFrom.length 步中，你将改变弹珠的位置。在第 i 步，你将把所有位于 moveFrom[i] 位置的弹珠移动到 moveTo[i] 位置。
//完成所有步骤后，返回占用位置的排序列表。
//思路：hashtable, 因为nums可以有重复，所以用hashset；
//根据moveFrom和moveTo来对每一个相对应的数进行更换；        
//注：最后输出要有顺序，并且不会有重复因为hashset
//时间复杂度：O(∣nums∣∗log(∣nums∣)+∣moveFrom∣)
//空间复杂度：O(∣nums∣)
        public IList<int> RelocateMarbles(int[] nums, int[] moveFrom, int[] moveTo)
        {
            var hash = new HashSet<int>(nums);

            for (var i = 0; i < moveFrom.Length; i++)
            {
                hash.Remove(moveFrom[i]);
                hash.Add(moveTo[i]);
            }
            return hash.OrderBy(x => x).ToList();
        }