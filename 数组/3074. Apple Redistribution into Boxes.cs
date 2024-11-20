//Leetcode 3074. Apple Redistribution into Boxes ez
//题目：给定两个数组：
//apple，大小为 n，表示 n 个苹果包，每个包中的苹果数量为 apple[i]。
//capacity，大小为 m，表示 m 个箱子，每个箱子的容量为 capacity[i]。
//你需要将所有苹果重新分配到这些箱子中，且同一个苹果包中的苹果可以分散到不同的箱子中。
//要求返回需要选用的最少箱子数量，以满足所有苹果都能装入箱子。
//思路: 先算apple总个数
//然后capacity倒序排序，然后从大到小取出每一个capacity
//然后currentCapacity >= totalApples，如果满足说明所有苹果都放入了输出结果，如果没有都放入就是-1；
//时间复杂度：O(n + m log m)
//空间复杂度：O(1)
        public int MinimumBoxes(int[] apple, int[] capacity)
        {
            // 计算苹果的总数
            long totalApples = apple.Sum();

            // 对箱子的容量进行降序排序
            Array.Sort(capacity, (a, b) => b - a);            

            // 贪心选择箱子
            int usedBoxes = 0;
            long currentCapacity = 0;

            foreach (int boxCapacity in capacity)
            {
                usedBoxes++;
                currentCapacity += boxCapacity;

                if (currentCapacity >= totalApples)
                    return usedBoxes;
            }

            // 理论上不会到这里，假设题目默认有解
            return -1;
        }