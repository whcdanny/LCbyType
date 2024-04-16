//Leetcode 2103. Rings and Rods ez
//题意：给定一个长度为 2n 的字符串 rings，表示 n 个环，每个环的颜色和放置的位置。每两个字符构成一个颜色-位置对，其中：
//第一个字符表示环的颜色（'R'：红色，'G'：绿色，'B'：蓝色）。
//第二个字符表示环所放置的杆（'0' 到 '9'）。
//要求：计算有多少根杆上放置了三种颜色的环。       
//思路：hashtable创建一个哈希表，用于存储每根杆上的环的颜色。
//遍历字符串 rings，将每个环的颜色加入到对应杆的集合中。
//遍历哈希表，统计满足条件的杆数。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int CountPoints(string rings)
        {
            Dictionary<char, HashSet<char>> rods = new Dictionary<char, HashSet<char>>();

            // 遍历字符串 rings，将每个环的颜色加入到对应杆的集合中
            for (int i = 0; i < rings.Length; i += 2)
            {
                char color = rings[i];
                char rod = rings[i + 1];
                if (!rods.ContainsKey(rod))
                {
                    rods[rod] = new HashSet<char>();
                }
                rods[rod].Add(color);
            }

            // 统计满足条件的杆数
            int count = 0;
            foreach (var kvp in rods)
            {
                if (kvp.Value.Count == 3)
                {
                    count++;
                }
            }

            return count;
        }