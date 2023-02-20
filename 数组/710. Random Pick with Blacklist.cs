//710. Random Pick with Blacklist hard
//给一个n，来创建一个[0,n-1]的数组，blacklist这个数组是不能在出现在pick里面；
//思路：用dictionary存储在blacklist里的数字和相对应的合法数字；因为我们将size缩小，因为有黑名单数字；
//0，1，2，3，4 [1，4] 实际输出的只有[0,1,2]->[0,3,2] 
		public class Solution_Random_Pick_with_Blacklist
        {
            public int size = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            Random random = new Random();
            public Solution_Random_Pick_with_Blacklist(int n, int[] blacklist)
            {
                size = n - blacklist.Length;
                foreach(int item in blacklist)
                {
                    map.Add(item, -1);
                }
                int last = n - 1;
                foreach(int item in blacklist)
                {
                    if (item >= size)
                        continue;
                    while (map.ContainsKey(last))
                    {
                        last--;
                    }
                    map[item] = last;
                    last--;
                }
            }

            public int Pick()
            {
                int index = random.Next(size);
                //return map.GetValueOrDefault(index, index);
                if (map.ContainsKey(index))
                    return map[index];
                return index;
            }
        }

        /**
         * Your Solution object will be instantiated and called as such:
         * Solution obj = new Solution(n, blacklist);
         * int param_1 = obj.Pick();
         */