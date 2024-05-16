//Leetcode 3013. Divide an Array Into Subarrays With Minimum Cost II hard
//题意：给定数组 nums 划分为 k 个不相交的连续子数组，满足以下条件：
//子数组的起始索引之间的最大差值不超过 dist。
//每个子数组的成本为其起始元素的值。
//要求计算这种划分方式下的子数组成本的最小可能总和。
//思路：滑窗 本题的本质就是从nums[1]开始，寻找一个长度为dist+1的滑窗，使得里面top k smallest的元素和最小。
//对于求top k smallest，有常规的套路，就是用两个multiset。将滑窗内的top k smallest放入Set1，其余元素放入Set2.
//当滑窗移动时，需要加入进入的新元素k。我们需要考察是否能进入Set1（与尾元素比较）。如果能，那么需要将Set1的尾元素取出，放入Set2.否则，将k放入Set2。
//同理，当滑窗移动时，我们需要移除离开滑窗的旧元素k。我们考察k是否是Set1的元素。如果是，那么我们需要将Set1的k取出，同时将Set2的首元素加入进Set1里。
//以上操作不断更新Set1的时候（加入元素和弹出元素），同时维护一个Set1元素的和变量sum，找到全局最小值即可。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public long MinimumCost_超时(int[] nums, int k, int dist)
        {
            int n = nums.Length;

            List<int> set1 = new List<int>();
            List<int> set2 = new List<int>();

            long sum = 0;
            long ret = long.MaxValue;

            k--;

            for (int i = 1; i < n; i++)
            {
                //没足够k，所以直接添加；
                if (set1.Count < k)
                {
                    set1.Add(nums[i]);
                    sum += nums[i];
                    //set1.Sort();
                }
                //set1满了，比较set1最后一共元素，如果大，                
                else if (set1.LastOrDefault() <= nums[i])
                {
                    set2.Add(nums[i]);
                    //set2.Sort();
                }
                else
                {
                    set2.Add(set1.LastOrDefault());
                    //set2.Sort();
                    sum -= set1.LastOrDefault();
                    set1.RemoveAt(set1.Count - 1);
                    set1.Add(nums[i]);
                    //set1.Sort();
                    sum += nums[i];
                }
                if (set1.Count > 0)
                    set1.Sort();
                if (set2.Count > 0)
                    set2.Sort();
                //减元素
                if (i >= dist + 1)
                {
                    //更新res；
                    ret = Math.Min(ret, sum);

                    int t = nums[i - dist];
                    if (set2.Contains(t))
                    {
                        set2.RemoveAt(set2.IndexOf(t));
                    }
                    else
                    {
                        set1.RemoveAt(set1.IndexOf(t));
                        sum -= t;
                        if (set2.Count > 0)
                        {
                            set1.Add(set2.FirstOrDefault());
                            sum += set2.FirstOrDefault();
                            set2.RemoveAt(0);
                        }
                    }
                }
                if (set1.Count > 0)
                    set1.Sort();
                if (set2.Count > 0)
                    set2.Sort();
            }

            return ret + nums[0];
        }