//Leetcode 2071. Maximum Number of Tasks You Can Assign hard
//题意：有 n 个任务和 m 个工人。每个任务有一个强度需求，存储在一个从 0 开始的整数数组 tasks 中，第 i 个任务需要 tasks[i] 的强度才能完成。每个工人的强度存储在一个从 0 开始的整数数组 workers 中，第 j 个工人的强度为 workers[j]。每个工人只能分配给一个任务，并且必须具有大于或等于任务强度要求的强度（即，workers[j] >= tasks[i]）。
//此外，还有一些神奇的药丸，可以增加工人的强度 strength。你可以决定哪些工人可以得到这些神奇的药丸，但是每个工人最多只能得到一颗药丸。
//给定整数数组 tasks 和 workers 以及整数 pills 和 strength，返回可以完成的最大任务数量。
//思路：二分搜索,先将tasks和wokers排序，然后用二分法猜测一个可以完成的task，然后判断
//注：判断思路就是：mid 表示最难的任务 必须完成；最有能力的woker 或者 woker+吃药丸；如果可以就证明可以left改高，不行就right改低；
//时间复杂度: O(log n)
//空间复杂度：O(1)       
        public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
        {
            Array.Sort(tasks);
            Array.Sort(workers);
            int left = 0;
            int right = tasks.Length;
            while (left < right)
            {
                int mid = right - (right - left) / 2;
                if (canDo_MaxTaskAssign(tasks, workers, pills, strength, mid))
                {
                    left = mid;
                }
                else
                {
                    right = mid-1;
                }
            }
            return left;
        }
        //mid 表示最难的任务 必须完成；最有能力的woker 或者 woker+吃药丸；
        //倒是第二难的任务：最有能力的woker 或者 woker+吃药丸
        private bool canDo_MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength, int k)
        {
            if (k > workers.Length)
                return false;
            if (k > tasks.Length)
                return false;

            //SortedSet<int> sortSet = new SortedSet<int>();
            List<int> list = new List<int>();
            foreach(int worker in workers)
            {
                list.Add(worker);
            }
            for(int i = k - 1; i >= 0; i--)
            {
                if(list.Last()>= tasks[i])
                {
                    list.RemoveAt(list.Count - 1);
                }
                else
                {
                    if (pills == 0)
                        return false;
                    int index = lowerBound_MaxTaskAssign(list, tasks[i] - strength);
                    if (index > list.Count)
                        return false;
                    if (list[index] + strength < tasks[i])
                        return false;
                    list.RemoveAt(index);
                    pills--;
                }
            }
            return true;
        }

        //lower_bound函数用于查找在有序容器中第一个大于或等于给定值的元素的位置。
        private int lowerBound_MaxTaskAssign(List<int> list, int val)
        {
            int l = 0, r = list.Count - 1;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (list[m] < val)
                    l = m + 1;
                else
                    r = m;
            }
            return l;
        }