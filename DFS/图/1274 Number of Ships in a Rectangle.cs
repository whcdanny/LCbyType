//Leetcode 1274 Number of Ships in a Rectangle med
//题意：给定一个矩形，其中包含多艘船。每艘船由一个矩形表示，这些矩形可能会相互重叠。船的位置由左上角和右下角的坐标确定。要求实现一个 countShips 函数，它接受一个矩形和一个左上角和右下角的坐标，返回在这个矩形中的船的数量。
//思路：深度优先搜索（DFS）: 将矩形划分成四个小矩形，分别对应左上、右上、左下和右下四个象限。对于每个小矩形，判断其中是否包含船，如果包含，递归地对该小矩形进行划分和搜索。
//时间复杂度:  矩形的边长为 n, 递归的次数为 log(n)。在每一次递归中，需要判断是否包含船，时间复杂度为 O(1)，因此总的时间复杂度为 O(log(n))。
//空间复杂度： 递归调用的深度可能达到 log(n)，因此空间复杂度为 O(log(n))
        public class Sea
        {
            private HashSet<string> ships;

            public Sea(HashSet<string> ships)
            {
                this.ships = ships;
            }

            public bool HasShips(int[] topRight, int[] bottomLeft)
            {
                int x1 = bottomLeft[0];
                int y1 = bottomLeft[1];
                int x2 = topRight[0];
                int y2 = topRight[1];

                for (int x = x1; x <= x2; x++)
                {
                    for (int y = y1; y <= y2; y++)
                    {
                        string position = x + "," + y;
                        if (ships.Contains(position))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public int CountShips(Sea sea, int[] topRight, int[] bottomLeft)
        {
            if (!sea.HasShips(topRight, bottomLeft)) return 0;

            if (topRight[0] == bottomLeft[0] && topRight[1] == bottomLeft[1]) return 1;

            int midX = (topRight[0] + bottomLeft[0]) / 2;
            int midY = (topRight[1] + bottomLeft[1]) / 2;

            int count = 0;
            count += CountShips(sea, new int[] { midX, midY }, bottomLeft);
            count += CountShips(sea, new int[] { topRight[0], midY }, new int[] { midX + 1, bottomLeft[1] });
            count += CountShips(sea, new int[] { midX, topRight[1] }, new int[] { bottomLeft[0], midY + 1 });
            count += CountShips(sea, topRight, new int[] { midX + 1, midY + 1 });

            return count;
        }