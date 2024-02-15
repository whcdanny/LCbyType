//Leetcode 2102. Sequentially Ordinal Rank Tracker hard
//题意：你正在构建一个系统来跟踪景点的排名，该系统最初为空。它支持以下操作：
//逐个添加景点。
//查询系统已添加的所有景点中第 i 优秀的位置，其中 i 是查询方法被调用的次数（包括当前查询）。
//实现 SORTracker 类：
//SORTracker()：初始化跟踪系统。
//void add(string name, int score)：向系统中添加一个景点，包括名称和分数。
//string get()：查询并返回第 i 优秀的位置，其中 i 是该方法被调用的次数（包括当前调用）。
//思路：PriorityQueue 可以使用一个优先队列来维护景点的排名。每当添加一个新的景点时，我们将其放入优先队列中，然后在查询时从优先队列中弹出第 i 个景点即可。
//时间复杂度: O(log n)
//空间复杂度：O(n)
        public class SORTracker //超时
        {
            private class Location
            {
                public string Name;
                public int Score;

                public Location(string name, int score)
                {
                    Name = name;
                    Score = score;
                }
            }

            private SortedSet<Location> locations;
            private int queryCount;

            public SORTracker()
            {
                locations = new SortedSet<Location>(Comparer<Location>.Create((x, y) =>
                {
                    if (x.Score != y.Score)
                        return y.Score.CompareTo(x.Score);
                    return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
                }));
                queryCount = 0;
            }

            public void Add(string name, int score)
            {
                locations.Add(new Location(name, score));
            }

            public string Get()
            {
                queryCount++;
                int count = 1;
                foreach (var location in locations)
                {
                    if (count == queryCount)
                        return location.Name;
                    count++;
                }
                return null; // Handle invalid query
            }
        }