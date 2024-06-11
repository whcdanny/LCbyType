//Leetcode 2926. Maximum Balanced Subsequence Sum hard
//题意：你被给定了一个0索引的整数数组nums。
//一个长度为k的子序列是平衡的，如果满足以下条件：
//对于每一个范围[1, k - 1] 中的j，都有nums[ij] - nums[ij - 1] >= ij - ij-1。
//长度为1的子序列被认为是平衡的。
//返回一个整数，表示数组nums中元素构成的平衡子序列的最大可能和。
//子序列是从原数组中删除一些（可能不删除）元素后形成的新非空数组，且不改变剩余元素的相对位置。
//思路：SortedList + 二分搜索 
//变形一下式子就有nums[i_j] - i_j >= nums[i_(j-1)] - i_(j-1). 
//我们令新数组arr[i] = nums[i]-i，我们就是想要在arr里面找一个递增的subsequence，记做{k}，
//使得这个subsequence对应的 {nums[k]} 的和能够最大。
//用o(N^2)的dp来做。令dp[i] 表示以i为结尾的递增subsequence的最大nums之和。那么就有
//for (int i=0; i<n; i++)
//  for (int j=0; j<i; j++)
//    if (arr[j] < arr[i])
//      dp[i] = max(dp[i], dp[j] + nums[i]);
//降低时间复杂度。我们看到第二个循环的效率不是很高，这个遍历里面满足if条件的位置j是不固定的。
//设想如果i之前的dp已经按照arr的数值放入一个有序容器中，我们就只需要遍历dp的某个前缀即可.
//重新定义dp[x] 表示以数值x为结尾的的递增subsequence的最大nums之和，
//并且dp是按照x从小到大排序的容器。
//for (int i=0; i<n; i++)
//  int x = arr[i];
//  for (int y: sorted(arr[0:i - 1]) & y<x)    
//        dp[x] = max{dp[y]} + nums[i];
//在某一个前缀数组里查询最大值
//dp本质是一个map，是按照key的大小排列的有序容器（其中key就是arr的值）。
//但是我们还可以给它加一个属性：让其value也保持递增。
//这个哲学思想就是，对于dp里存在 dp[a] = A, dp[b] = B，且a<b, A>=B，
//那么对于任何一个新元素arr[i]= x，
//我们如果可以把x接在b后面构造子序列，那么显然不如我们把x接在a后面构成子序列更优。
//这样我们就可以把b从dp里弹出去。
//所以将dp按照key和value都递增的顺序排列后，一个最大的好处出现了。
//对于任何一个新元素arr[i] = x，只需要知道恰好小于等于x的key（假设是y），
//那么就有dp[x] = dp[y] + nums[i]。
//任何key比y小的元素，虽然都可以接上x，但是它们的value并没有dp[y]有优势。
//当我们确定dp[x]的最优值之后，再将x插入dp里面。
//记得此时要向后依次检查比x大的那些key，看它们的value（也就是dp值）是否小于dp[x]，
//是的话就将他们弹出去。
//时间复杂度：对于任何的arr[i] = x，我们在dp里面按照key二分查询恰好小于等于x的key，是log(n)。所以总的时间复杂度是o(NlogN).       
//时间复杂度:  O(logn)
//空间复杂度： O(n)
        public long MaxBalancedSubsequenceSum(int[] nums)//超时
        {
            int n = nums.Length;
            int[] arr = new int[n];
            //nums[i_j] - i_j >= nums[i_(j-1)] - i_(j-1).
            //根据每一个i找出num[i]-i;
            for (int i = 0; i < n; i++)
                arr[i] = nums[i] - i;

            SortedList<int, long> dp = new SortedList<int, long>();
            long ret = long.MinValue;

            for (int i = 0; i < n; i++)
            {
                int x = arr[i];
                long maxVal = nums[i];

                //找到第一个小于arr[i]的key的位置；
                //根据位置更新dp
                int index = binarySearch_MaxBalancedSubsequenceSum(dp, x);
                if (index == -1)
                {
                    //如果没有找到说明在
                    dp[x] = nums[i];
                }
                else
                {                    
                    //有可能前一个是负数，而nums[i]是正数，所以用max
                    dp[x] = Math.Max((long)nums[i], dp.ElementAt(index).Value + nums[i]);
                }                

                ret = Math.Max(ret, dp[x]);

                //在key比x大的并且val比dp[x]小的数；
                var toRemove = new List<int>();
                //for(int j = x + 1; i < dp.Count; i++)
                //{
                //    if (dp.ElementAt(j).Key <= x)
                //        continue;
                //    if (dp.ElementAt(j).Value <= dp[x])
                //    {
                //        toRemove.Add(dp.ElementAt(j).Key);
                //    }
                //}
                foreach (var kvp in dp)
                {
                    if (kvp.Key <= x)
                        continue;
                    if (kvp.Value <= dp[x])
                    {
                        toRemove.Add(kvp.Key);
                    }

                }
                foreach (var key in toRemove)
                {
                    dp.Remove(key);
                }
            }

            return ret;
        }

        private int binarySearch_MaxBalancedSubsequenceSum(SortedList<int, long> dp, int x)
        {
            List<int> keys = new List<int>(dp.Keys);
            int low = 0;
            int high = keys.Count - 1;
            int res = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (keys[mid] > x)
                {                    
                    high = mid - 1;
                }
                else
                {
                    res = mid;
                    low = mid + 1;
                }
            }
            return res;
        }