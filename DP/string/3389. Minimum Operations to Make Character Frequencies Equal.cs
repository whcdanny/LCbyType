//Leetcode 3389. Minimum Operations to Make Character Frequencies Equal Hard
//题目：给定一个字符串 s。
//如果字符串 t 满足 所有字符出现的次数相同，则称其为“好字符串”（good）。
//你可以对字符串 s 执行以下任意次数的操作：
//删除字符：从 s 中删除一个字符。
//插入字符：在 s 中插入一个字符。
//修改字符：将字符串中的某个字符更改为其在字母表中的下一个字母（注意，无法将 z 改为 a）。
//任务：返回将字符串 s 变成“好字符串”所需的最小操作次数。
//思路：动态规划 dp存入（每个字母，此时deleted的个数，和期望所有字母统一一个target个数）和 此时的操作个数
//先找出最大的target值，然后0-target猜测
//递归，这里考虑delet，可能是真删除，也可能会因为第三条原则用于下一个相邻的字母，
//这样分成两类，
//一个是c <= target：
//1假设转换成相邻字母(index + 1, c, target, dp, array) + c;
//2假设增加个数，这里注意的是因为有delete存在，所以找出最小添加个数Math.Min(deleted, target - c);
//(index + 1, 0, target, dp, array) + target - c - increase;
//一个是c<target
//只有删除，(index + 1, c - target, target, dp, array) + c - target;
//时间复杂度:  O(26×maxCount^2)
//空间复杂度： O(26×maxCount^2)
        public int MakeStringGood(string s)
        {
            int[] array = new int[26];
            foreach(var c in s.ToArray()){
                array[c-'a']++;
            }
            Dictionary<(int index, int deleted, int target), int> dp = new Dictionary<(int index, int deleted, int target), int>();

            int maxCount = int.MinValue;

            foreach(int count in array)
            {
                maxCount = Math.Max(maxCount, count);
            }
            int res = int.MaxValue;
            for(int target = 0; target <= maxCount; target++)
            {
                res = Math.Min(res, minMakeStringGood(0, 0, target, dp, array));
            }

            return res;
        }

        private int minMakeStringGood(int index, int deleted, int target, Dictionary<(int index, int deleted, int target), int> dp, int[] array)
        {
            if (index == 26)
                return 0;
            var key = (index, deleted, target);
            if (dp.ContainsKey(key))
                return dp[key];

            int c = array[index];
            int res;
            if (c <= target)
            {
                res = minMakeStringGood(index + 1, c, target, dp, array) + c;
                int increase = Math.Min(deleted, target - c);
                int cand = minMakeStringGood(index + 1, 0, target, dp, array) + target - c - increase;
                res = Math.Min(res, cand);
            }
            else
            {
                res = minMakeStringGood(index + 1, c - target, target, dp, array) + c - target;
            }

            dp[key] = res;
            return res;
        }