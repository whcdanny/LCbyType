//Leetcode 2244. Minimum Rounds to Complete All Tasks med
//题意：给定一个表示任务难度级别的整数数组 tasks，其中 tasks[i] 表示第 i 个任务的难度级别。每轮中，你可以完成相同难度级别的 2 个或 3 个任务。
//返回完成所有任务所需的最小轮数，如果无法完成所有任务，则返回 -1。
//思路：hashtable 先算出每个task的个数；
//然后value为1，那么是-1，如果可以被3整除，那么就直接+，如果不能被3整除，那么就+1；       
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MinimumRounds(int[] tasks)
        {
            var numDict = new Dictionary<int, int>();
            for (int i = 0; i < tasks.Length; i++)
            {                
                if (!numDict.ContainsKey(tasks[i])) 
                    numDict.Add(tasks[i], 0);                
                numDict[tasks[i]]++;
            }

            var output = 0;
            foreach (var keyValuePair in numDict)
            {               
                if (keyValuePair.Value == 1) 
                    return -1;                
                else if (keyValuePair.Value % 3 == 0) 
                    output += keyValuePair.Value / 3;               
                else 
                    output += (keyValuePair.Value / 3) + 1;
            }
            return output;
        }