//Leetcode 2105. Watering Plants II med
//题意：Alice 和 Bob 想要给 n 个植物浇水。植物排列在一行中，从左到右标记为 0 到 n - 1，其中第 i 个植物位于 x = i 的位置。
//每个植物需要一定量的水。Alice 和 Bob 各自有一个初始装满的浇水罐。他们按照以下方式浇水：     
//Alice 从左到右按顺序浇水，从第 0 个植物开始。Bob 从右到左按顺序浇水，从第(n - 1) 个植物开始。他们同时开始浇水。
//无论植物需要多少水，浇水每个植物花费的时间相同。
//如果 Alice/Bob 的浇水罐里有足够的水完全浇灌植物，则他们必须浇水。否则，他们首先要重新装满水罐（瞬间完成），然后再浇水。
//如果 Alice 和 Bob 同时到达同一个植物，则当前水罐里有更多水的人应该浇水。如果他们的水量相同，则 Alice 应该浇水。
//给定一个长度为 n 的整数数组 plants，其中 plants[i] 表示第 i 个植物需要的水量，以及两个整数 capacityA 和 capacityB，表示 Alice 和 Bob 的浇水罐容量。返回他们需要重新装水多少次，以便浇灌所有植物。
//思路：双针，两个指针（分别表示 Alice 和 Bob 的位置），从两端同时开始移动。通过模拟的方式计算每个植物需要的水量，并判断是否需要重新装水。
//时间复杂度: O(n)
//空间复杂度：O(1)
        public int MinimumRefill(int[] plants, int capacityA, int capacityB)
        {
            int refills = 0;
            int left = 0;
            int right = plants.Length - 1;
            int waterA = capacityA;
            int waterB = capacityB;

            while (left < right)
            {
                if (waterA < plants[left])
                {
                    waterA = capacityA;
                    refills++;
                }

                if (waterB < plants[right])
                {
                    waterB = capacityB;
                    refills++;
                }

                waterA -= plants[left];
                waterB -= plants[right];
                ++left;
                --right;
            }

            return (left == right && Math.Max(waterA, waterB) < plants[left]) ? refills + 1 : refills; ;
        }