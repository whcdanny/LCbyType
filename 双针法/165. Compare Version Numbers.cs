//Leetcode 165. Compare Version Numbers med
//题意：比较两个版本号 version1 和 version2
//版本号的格式是由点分隔的字符串，每个部分可以包含数字和小数点。
//每个版本号可以包含一个或多个数字，数字之间由小数点分隔。例如，"1.0" 和 "1.1"。
//每个部分的数字可以有前导零，但应该忽略前导零。例如，"01" 和 "1" 在比较时应视为相同。
//版本号可能不同长度，因此在比较时要注意。
//比较规则如下：
//从左到右逐段比较版本号。
//对于每个部分，将其中的数字转换为整数。
//如果 version1 的当前部分数字大于 version2 的当前部分数字，则 version1 大于 version2。
//如果 version1 的当前部分数字小于 version2 的当前部分数字，则 version1 小于 version2。
//如果两个版本号的当前部分数字相同，则继续比较下一段。
//如果所有部分都相同，则两个版本号相等。如果其中一个版本号的部分耗尽了，而另一个版本号仍有剩余部分，则剩余部分都视为零。
//例如：
//"1.01" 和 "1.001" 是相同的版本号，因为它们的数字部分相同。
//"1.0" 和 "1.0.0" 也是相同的版本号。
//这样，题目要求实现一个函数，比较两个版本号，如果 version1 大于 version2，返回 1；如果 version1 小于 version2，返回 -1；如果两个版本号相等，返回 0。
//思路：双指针，两个指针 i 和 j 分别遍历两个版本号字符串。
//每次遇到小数点前的数字时，将数字转换成整数，并进行比较
//时间复杂度：O(max(n, m))，其中 n 和 m 分别是两个版本号字符串的长度。
//空间复杂度：O(1)
        public int CompareVersion(string version1, string version2)
        {
            int i = 0, j = 0;

            while (i < version1.Length || j < version2.Length)
            {
                int num1 = 0, num2 = 0;

                // 获取 version1 中的数字
                while (i < version1.Length && version1[i] != '.')
                {
                    num1 = num1 * 10 + (version1[i] - '0');
                    i++;
                }

                // 获取 version2 中的数字
                while (j < version2.Length && version2[j] != '.')
                {
                    num2 = num2 * 10 + (version2[j] - '0');
                    j++;
                }

                // 比较当前版本号的数字
                if (num1 > num2)
                {
                    return 1;
                }
                else if (num1 < num2)
                {
                    return -1;
                }

                // 跳过小数点
                i++;
                j++;
            }

            return 0; // 两个版本号相等
        }