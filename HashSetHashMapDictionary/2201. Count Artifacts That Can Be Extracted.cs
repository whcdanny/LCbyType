//Leetcode 2201. Count Artifacts That Can Be Extracted med
//题意：给定一个 n x n 的二维网格，以及一个二维数组 artifacts，描述了埋藏在网格中的一些矩形文物的位置。
//其中，artifacts[i] = [r1i, c1i, r2i, c2i] 表示第 i 个文物的左上角和右下角的坐标。
//你将挖掘网格中的一些单元格，并清除它们上面的泥土。如果单元格下面有一部分文物，它将被揭示出来。
//如果一个文物的所有部分都被揭示出来，那么你可以提取它。
//给定一个二维数组 dig，表示你将挖掘的单元格，返回你可以提取的文物数量。
//思路：hashtable 对于网格上的每个 (x, y) 点，我们关联包含该点的工件的索引。
//对于每个工件索引，我们还维护其覆盖的总点数。
//然后，对于 dig 数组中的每个元素，我们检查（使用第一个字典）它属于哪个工件（如果有）并从第二个数组中删除计数。
//最后循环工件并检查哪些已挖掘出所有点。
//时间复杂度：O(k+m) k 是挖掘单元格的数量,m 是文物的数量
//空间复杂度：O(m)
        public int DigArtifacts(int n, int[][] artifacts, int[][] dig)
        {
            var pointsToArtifacts = new Dictionary<(int, int), int>();
            var count = new Dictionary<int, int>();

            for (int i = 0; i < artifacts.Length; ++i)
            {
                var r1 = artifacts[i][0];
                var c1 = artifacts[i][1];

                var r2 = artifacts[i][2];
                var c2 = artifacts[i][3];

                var counter = 0;
                for (int x = r1; x <= r2; ++x)
                {
                    for (int y = c1; y <= c2; ++y)
                    {
                        pointsToArtifacts.Add((x, y), i);
                        ++counter;
                    }
                }
                count.Add(i, counter);
            }

            for (int i = 0; i < dig.Length; ++i)
            {
                var x = dig[i][0];
                var y = dig[i][1];

                if (pointsToArtifacts.ContainsKey((x, y)))
                {
                    var index = pointsToArtifacts[(x, y)];
                    count[index] -= 1;
                }
            }

            var result = 0;
            foreach (var (key, value) in count)
            {
                if (value == 0)
                {
                    ++result;
                }
            }

            return result;
        }