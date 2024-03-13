//Leetcode 975. Odd Even Jump hard
//题意：给定一个整数数组 arr。从某个起始索引开始，你可以进行一系列跳跃。序列中第 1、3、5 ... 次跳跃被称为奇数次跳跃，第 2、4、6 ... 次跳跃被称为偶数次跳跃。请注意，跳跃是按照次数编号的，而不是索引。
//你可以按以下方式从索引 i 跳到索引 j（其中 i<j）：
//在奇数次跳跃中（即第 1、3、5 ... 次跳跃），你跳到索引 j，满足 arr[i] <= arr[j] 且 arr[j] 是可能的最小值。如果存在多个这样的索引 j，则只能跳到最小的索引 j。
//在偶数次跳跃中（即第 2、4、6 ... 次跳跃），你跳到索引 j，满足 arr[i] >= arr[j] 且 arr[j] 是可能的最大值。如果存在多个这样的索引 j，则只能跳到最小的索引 j。
//可能存在某些索引 i，无法进行合法的跳跃。
//一个起始索引被称为好的，如果从该索引开始，你可以通过进行一些跳跃（可能是 0 或多次）到达数组的末尾（索引 arr.length - 1）。
//返回好的起始索引的数量。
//注：说白了就是先找大于他的，然后第二步小于他的；
//思路：stack + Monotonic Stack, 这里跟之前不一样的是，我们要找当前位置下nextSmaller和nextGreater，这两个list初始都是-1；
//然后从后往前找是否满足条件，如给是high，如果nextGreater不是-1，那么就看lower[nextGreater[i]]是true还是false；
//如给是low，如果nextSmaller不是-1，那么就看lhigher[nextSmaller[i]]是true还是false；
//最后只要higher[i]是true就满足条件；
//时间复杂度: 遍历数组 arr 的时间复杂度为 O(n)，其中 n 是数组 arr 的长度。
//空间复杂度：odd 和 even，以及两个单调栈，它们的空间复杂度均为 O(n)。
        public int OddEvenJumps(int[] arr)
        {
            int n = arr.Length;
            int[] nextGreater = new int[n];
            int[] nextSmaller = new int[n];            
            Array.Fill(nextGreater, -1);
            Array.Fill(nextSmaller, -1);

            Stack<int> stack = new Stack<int>();
            //从大到小的index；
            var sortedIndex = arr.Select((x, i) => new KeyValuePair<int, int>(x, i))
                          .OrderBy(x => x.Key)
                          .ThenBy(x => x.Value)
                          .Select(x => x.Value).ToList();
            foreach (int i in sortedIndex)
            {
                while (stack.Count > 0 && i > stack.Peek())
                    nextGreater[stack.Pop()] = i;
                stack.Push(i);
            }

            stack.Clear();
            //从小到大index；
            sortedIndex = arr.Select((x, i) => new KeyValuePair<int, int>(x, i))
                          .OrderByDescending(x => x.Key)
                          .ThenBy(x => x.Value)
                          .Select(x => x.Value).ToList();
            foreach (int i in sortedIndex)
            {
                while (stack.Count > 0 && i > stack.Peek())
                    nextSmaller[stack.Pop()] = i;
                stack.Push(i);
            }

            bool[] higher = new bool[n];
            bool[] lower = new bool[n];
            higher[n - 1] = lower[n - 1] = true;
            int sum = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                higher[i] = nextGreater[i] == -1 ? false : lower[nextGreater[i]];
                lower[i] = nextSmaller[i] == -1 ? false : higher[nextSmaller[i]];
                if (higher[i])
                    sum++;
            }
            return sum;
        }