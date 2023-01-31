//77. Combinations med
//给定两个整数 n 和 k，返回范围 [1, n] 中所有可能的 k 个数的组合。
//思路1： 给定一个k子集，然后往里面添加数，并k-1，直到k=0存入这个子集；
//然后往下一个直到走到n；
	public IList<IList<int>> Combine(int n, int k) {
         List<IList<int>> res = new List<IList<int>>();

        int[] subRes = new int[k];

        Recruion(res, k, n, subRes, 1);

        return res;
    }
     private void Recruion(List<IList<int>> res, int k, int n, int[] subRes, int start)
    {
        if (k == 0)
        {
            res.Add(subRes.ToList());
            return;
        }
        for(int i = start; i<=n; i++)
        {
            subRes[subRes.Length - k] = i;
            Recruion(res, k - 1, n, subRes, i + 1);
        }
    }
	
//回溯算法： 给一个没用大小的子集，然后往里放入1到n，直到这个子集大小=k存入这个子集；
//然后把上一次放入的数字移除；
	public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> res = new List<IList<int>>();
            List<int> subRes = new List<int>();
            CombineRecruion(res, subRes, 1, n, k);
            return res;
        }
        private void CombineRecruion(List<IList<int>> res, List<int> subRes, int start, int n, int k)
        {
            //base case
            if(k == subRes.Count())
            {
                // 遍历到了第 k 层，收集当前节点的值
                res.Add(new List<int>(subRes));
                return;
            }
            // 回溯算法标准框架
            for (int i = start; i <= n; i++)
            {
                // 选择
                subRes.Add(i);
                // 通过 start 参数控制树枝的遍历，避免产生重复的子集
                CombineRecruion(res, subRes, i + 1, n, k);
                // 撤销选择
                subRes.RemoveAt(subRes.Count - 1);
            }
        }