//Leetcode 997. Find the Town Judge ez
//题意：在一个小镇里，有 n 个人，标号从 1 到 n。传言其中有一个人是小镇法官。
//如果小镇法官存在，则需要满足以下条件：
//小镇法官不信任任何人。
//除了小镇法官以外的所有人都信任小镇法官。
//必须恰好有一个人满足上述两个条件。
//给定一个数组 trust，其中 trust[i] = [ai, bi] 表示编号为 ai 的人信任编号为 bi 的人。
//返回小镇法官的编号。如果无法确定小镇法官，返回 -1。
//思路：法官在trust[i] = [ai, bi] 不存在与a[i] 所以judge[i] == 0
//所有人都要相信法官所以b[i]总是 ppl[i] == n - 1
//时间复杂度：O(n+m)
//空间复杂度：O(n)
        public int FindJudge(int n, int[][] trust)
        {
            int[] judge = new int[n];
            int[] ppl = new int[n];
            foreach(var p in trust)
            {
                int b1 = p[0];
                int b2 = p[1];
                judge[b1]++;
                ppl[b2]++;
            }
            for(int i = 0; i < n; i++)
            {
                if (judge[i] == 0 && ppl[i] == n - 1)
                    return i;
            }
            return -1;
        }