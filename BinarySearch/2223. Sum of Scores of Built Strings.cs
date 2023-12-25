//Leetcode 2223. Sum of Scores of Built Strings hard
//题意：题目要求构建一个长度为 n 的字符串 s，每次将新字符添加到字符串的最前面。字符串从 1 到 n 标记，其中长度为 i 的字符串标记为 si。
//例如，对于 s = "abaca"，s1 == "a"，s2 == "ca"，s3 == "aca"，等等。si 的得分是 si 和 sn（注意 s == sn）之间最长公共前缀的长度。
//给定最终的字符串 s，要求返回所有 si 的得分之和。
//思路：二分搜索 + rolling hash; 相当于先将每个string 变为 int，然后用字符串长度来二分搜索，如果以i为起始点，长度为mid是否满足从0开始的一样的；
//注：这里string 变为 int ex:b = 1; bc = 1 *26 + 2; bcd = (1 *26 + 2)*26 +3; 
//当二分搜索比较的时候用 bcdbcz, 如果我要bcz，那么相当于 hash[5]-hash[2]*26^3 => hash[i+len-1] - hash[i-1]*26^(len) 这里len就是我们二分法算出的mid；
//时间复杂度: O(nlogn)
//空间复杂度：O(n)
        public long SumScores(string s)
        {
            long[] hashes = new long[100001];
            long[] power = new long[100001];
            int n = s.Length;
            long hash = 0;
            //rolling hash
            //ex:b = 1; bc = 1 *26 + 2; bcd = (1 *26 + 2)*26 +3;
            //前一位*26+当前(s[i] - 'a')；
            for (int i = 0; i < n; i++)
            {
                hash = hash * 26 + (s[i] - 'a');
                hashes[i] = hash;
            }
            //算每个位置的相当于26^0, 26^1, ...26^n;
            power[0] = 1;
            for (int i = 1; i < n; i++)
            {
                power[i] = power[i - 1] * 26;
            }

            long res = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                //以i和0不一样的，下一个
                if (s[i] != s[0]) continue;
                //设置边界；
                int left = 1, right = n - i;
                while (left < right)
                {
                    int mid = right - (right - left) / 2;
                    //以i为起始点，长度为mid是否满足从0开始的一样的；
                    //如果不相同，就太长了改right；
                    if (getHash(s, i, mid, hashes, power) != hashes[mid - 1])
                        right = mid - 1;
                    //如果相同，那可能更新left，因为可能有更小的；
                    else
                        left = mid;
                }
                res += left;
            }

            return res;
        }
        //所有前缀的hash减去当前位位置
        private long getHash(string s, int i, int len, long[] hashes, long[] power)
        {
            return hashes[i + len - 1] - (i == 0 ? 0 : hashes[i - 1] * power[len]);
        }
