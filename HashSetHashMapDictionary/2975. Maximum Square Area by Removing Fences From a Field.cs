//Leetcode 2975. Maximum Square Area by Removing Fences From a Field med
//题意：给定一个矩形场地，场地中含有一些水平和垂直的栅栏，栅栏用两个数组 hFences 和 vFences 来表示。
//水平栅栏从坐标 (hFences[i], 1) 到 (hFences[i], n)，垂直栅栏从坐标 (1, vFences[i]) 到 (m, vFences[i])。
//要求移除一些栅栏，使得场地中形成一个最大面积的正方形区域。
//思路：hashtable, 先把每个水平和垂直的位置做成一共list，
//然后算出每个水平和垂直的位置差，
//然后找到水平位置差和垂直位置差相同的值，然后相乘，找到max
//时间复杂度：O(mn)
//空间复杂度：O(m + n)
        public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
        {
            Array.Sort(hFences);
            List<int> hList = new List<int>(hFences);
            hList.Insert(0, 1);
            hList.Add(m);
            Array.Sort(vFences);
            List<int> vList = new List<int>(vFences);
            vList.Insert(0, 1);
            vList.Add(n);
            HashSet<int> horizontal = new HashSet<int>();
            HashSet<int> vertical = new HashSet<int>();
            for (int i = 0; i < hList.Count - 1; i++)
            {
                for (int j = i + 1; j < hList.Count; j++)
                {
                    if (!horizontal.Contains(hList[j] - hList[i])) 
                        horizontal.Add(hList[j] - hList[i]);
                }
            }
            for (int i = 0; i < vList.Count - 1; i++)
            {
                for (int j = i + 1; j < vList.Count; j++)
                {
                    if (!vertical.Contains(vList[j] - vList[i])) 
                        vertical.Add(vList[j] - vList[i]);
                }
            }
            long ans = -1;
            foreach (int i in horizontal)
            {
                if (vertical.Contains(i)) 
                    ans = Math.Max(ans, (long)i * (long)i);
            }
            return (int)(ans % 1000000007);
        }