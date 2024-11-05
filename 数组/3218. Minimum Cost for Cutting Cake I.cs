//Leetcode 3218. Minimum Cost for Cutting Cake I med
//题目：我们有一个大小为 m×n 的蛋糕，目标是将其切割成 
//1×1 的小块。切割操作的成本由两组数据决定：
//horizontalCut：大小为 
//m−1 的数组，表示在不同水平线切割的成本。
//verticalCut：大小为 
//n−1 的数组，表示在不同垂直线切割的成本。
//每次切割可以选择水平或垂直方向，切割后将蛋糕分为两部分。
//切割成本取决于初始成本，不会因为后续操作而改变。
//目标是找到将蛋糕完全切割成 
//1×1 的小块所需的最小总成本。
//思路: 排序准备：对 horizontalCut 和 verticalCut 数组分别排序，这样每次可以优先选择最小的切割成本。
//贪心选择切割顺序：
//从两个数组中选择当前最小的切割成本，若水平切割较小，则选择水平切割，反之亦然。
//在切割过程中，水平切割会导致垂直方向上的段数增加，反之亦然。
//成本计算：通过跟踪当前的垂直段数和水平段数，我们可以计算每次选择的切割成本，并累积到总成本中。
//选择最大成本的切割来优先处理。选择从大到小的成本处理，可以让我们在切割的早期阶段对剩余未分割区域产生更大影响，避免高成本切割产生过多累积的代价
//时间复杂度：O((m+n)log(m+n))
//空间复杂度：O(1)
        public int MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut)
        {
            Array.Sort(horizontalCut);
            Array.Sort(verticalCut);

            int hLength = horizontalCut.Length;
            int vLength = verticalCut.Length;

            //有多少要被切；
            int hIndex = hLength - 1;
            int vIndex = vLength - 1;

            //当前切完之后所处的块数
            int hSegments = 1; // Initially only one horizontal segment
            int vSegments = 1; // Initially only one vertical segment

            int totalCost = 0;

            while (hIndex >= 0 || vIndex >= 0)
            {
                if (vIndex < 0 || (hIndex >= 0 && horizontalCut[hIndex] >= verticalCut[vIndex]))
                {
                    totalCost += horizontalCut[hIndex] * vSegments;
                    hSegments++;
                    hIndex--;
                }
                else
                {
                    totalCost += verticalCut[vIndex] * hSegments;
                    vSegments++;
                    vIndex--;
                }
            }

            return totalCost;
        }