//Leetcode 1894. Find the Student that Will Replace the Chalk med
//题意：有 n 名学生在一个班级中，编号从 0 到 n - 1。老师将给每个学生分发问题，从学生编号 0 开始，然后是学生编号 1，依此类推，直到老师到达学生编号 n - 1。然后，老师将重新开始这个过程，再次从学生编号 0 开始。
//给定一个整数数组 chalk 和一个整数 k。一开始有 k 块粉笔。当学生编号 i 被分发问题时，他们将使用 chalk[i] 块粉笔来解决问题。但是，如果当前粉笔的数量严格小于 chalk[i]，那么学生编号 i 将被要求替换粉笔。
//要求返回将替换粉笔的学生的索引。
//思路：用二分法+前缀和, 累计前缀和 sum，然后将每个学生需要的粉笔数量 chalk[i] 更新为当前累计的前缀和 sum。 
//如果累计的前缀和 sum 大于等于 k，说明前 i 个学生的总需求超过了可用的粉笔数量 k，此时退出循环。
//计算余下可用的粉笔数量 num，如果 k 大于前 i 个学生的总需求，取余数；否则，直接使用 k。
//用二分搜索找出对应的学生位置；
//时间复杂度: 在第一个循环中，遍历一次 chalk 数组，时间复杂度为 O(n)，其中 n 是学生的数量。在第二个循环中，进行二分搜索，时间复杂度为 O(log i)，其中 i 表示学生的数量。由于第一个循环中已经遍历了前 i 个学生，所以这里的时间复杂度也是 O(log n)。因此，总体时间复杂度为 O(n + log n)。
//空间复杂度：O(1)
        public int ChalkReplacer(int[] chalk, int k)
        {
            var n = chalk.Length;
            if (n == 1) return 0;

            var sum = chalk[0];
            var i = 1;

            for (i = 1; i < n; i++)
            {
                sum += chalk[i];
                chalk[i] = sum;

                // no need to  count sum if bigger than k
                if (sum >= k)
                {
                    break;
                }
            }

            if (k == sum) return 0;
            var num = (k > sum) ? k % sum : k;

            var left = 0;
            var mid = 0;

            //search only in [0, i] and not the entire array
            var right = i;

            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (chalk[mid] == num)
                {
                    break;
                }
                else if (num > chalk[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return chalk[mid] > num ? mid : mid + 1;
        }