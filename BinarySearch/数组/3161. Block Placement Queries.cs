//Leetcode 3161. Block Placement Queries hard
//题目：题目给定一个无限的数轴，从原点 0 向正 x 轴延伸。存在以下两种查询类型：
//类型 1 ([1, x]): 在距离原点为 x 的位置建立一个障碍物，且保证 x 位置之前没有障碍物。
//类型 2 ([2, x, sz]): 检查是否可以在[0, x] 的范围内放置一个大小为 sz 的块。块需要完全位于[0, x] 区间内，并且不能与任何障碍物相交，但可以接触障碍物。
//也就是说sz是长度 再0-x这里面选一个长度为sz的块，这个块不能与障碍物相交
//对于类型 2 的查询，如果可以放置块，则返回 true；否则返回 false。
//思路: 二分搜索
//用SortedList来存key是障碍物的具体位置，value表示当前它影响的空闲区间的最大长度（用这个距离来跟sz作比较）
//然后类型1，就要放入障碍物，然后更新前面和后面的障碍物之间的最大空闲区间
//然后类型2，用二分法找出离x最近的障碍物，然后比较sz是否能放在障碍物左侧，或者现在最大空闲区间是否满足sz；
//时间复杂度：O(Q log N + Q N)
//空间复杂度：O(N+Q)
        public IList<bool> GetResults(int[][] queries)
        {
            List<bool> result = new List<bool>();
            //key是障碍物的具体位置，value表示当前它影响的空闲区间的最大长度
            SortedList<int, int> blocks = new SortedList<int, int>();
            foreach (int[] q in queries)
            {
                //根据新的障碍物与其相邻障碍物的关系，更新所有相关的空闲区间的最大长度
                if (q[0] == 1)
                {
                    blocks.Add(q[1], q[1]);
                    int i = blocks.IndexOfKey(q[1]);
                    //检查其前一个障碍物与当前障碍物之间的最大空闲区间
                    if (i > 0)
                    {
                        var prevkey = blocks.Keys[i - 1];
                        var prevvalue = blocks.Values[i - 1];                        
                        blocks[blocks.Keys[i]] = Math.Max(prevvalue, q[1] - prevkey);
                    }
                    //然后向后遍历，更新当前障碍物与后续障碍物之间的最大空闲区间。如果更新的结果与前一个障碍物值相同，则停止更新。
                    for (int j = i + 1; j < blocks.Count; j++)
                    {
                        //update all node values                       
                        int prevkey = blocks.Keys[j - 1];
                        int prevvalue = blocks.Values[j - 1];
                        int currkey = blocks.Keys[j];
                        int currvalue = blocks.Values[j];
                        if (currvalue != Math.Max(prevvalue, currkey - prevkey))
                            blocks[currkey] = Math.Max(prevvalue, currkey - prevkey);                        
                        else 
                            break;
                    }
                }
                else if (q[0] == 2)
                {
                    if (q[2] > q[1])
                    {
                        result.Add(false);
                        continue;
                    }
                    if (blocks.Count == 0)
                    {
                        result.Add(true);
                        continue;
                    }
                    //二分查找来查找与位置 q[1] 最近的位置的障碍物位置
                    int i = BinarySearch_GetResults(blocks, q[1]);
                    if (i == -1)
                    {
                        result.Add(true);
                        continue;
                    }
                    int key = blocks.Keys[i];
                    int val = blocks.Values[i];
                    //当前区间的起始位置到障碍物位置之间有足够的空间来容纳大小为 q[2] 的块。这意味着块能够放置在障碍物左侧
                    //是否有足够的空闲区间来容纳块
                    if (q[2] <= q[1] - key || q[2] <= val) 
                        result.Add(true);
                    else 
                        result.Add(false);
                }
            }
            return result;
        }

        public int BinarySearch_GetResults(SortedList<int, int> blocks, int val)
        {
            int left = 0, right = blocks.Count - 1, p = -1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (blocks.Keys[mid] == val) 
                    return mid;
                if (blocks.Keys[mid] < val)
                {
                    p = mid;
                    left = mid + 1;
                }
                else 
                    right = mid - 1;
            }
            return p;
        }