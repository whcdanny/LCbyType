//Leetcode 299. Bulls and Cows med
//题意：给定一个秘密数字和一个猜测数字，请你编写一个函数，返回猜测数字和秘密数字的匹配情况，用 "A" 表示数字和位置都匹配，用 "B" 表示数字匹配但位置不匹配。
//思路：用两个dictionary存出现的char和频率，首先，遍历秘密数字和猜测数字，分别统计它们的数字频率，存入两个HashMap中， 在遍历秘密数字和猜测数字，对于每个位置上的数字，如果它们相等，则将bulls数目加一，不相等就相应的char频率++。然后历遍秘密数字的hashmap，如果猜测数字的hashmap含有相同的char，选择最小出现的频率添加到cows。
//时间复杂度：遍历秘密数字和猜测数字需要 O(n) 的时间，其中 n 是数字的长度
//空间复杂度：空间复杂度是 O(10) = O(1)，因为数字的范围是 0 到 9。
        public string GetHint1(string secret, string guess)
        {
            Dictionary<char, int> secretFreq = new Dictionary<char, int>();
            Dictionary<char, int> guessFreq = new Dictionary<char, int>();
            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    if (!secretFreq.ContainsKey(secret[i]))
                    {
                        secretFreq[secret[i]] = 0;
                    }
                    if (!guessFreq.ContainsKey(guess[i]))
                    {
                        guessFreq[guess[i]] = 0;
                    }
                    secretFreq[secret[i]]++;
                    guessFreq[guess[i]]++;
                }
            }

            foreach (char key in secretFreq.Keys)
            {
                if (guessFreq.ContainsKey(key))
                {
                    cows += Math.Min(secretFreq[key], guessFreq[key]);
                }
            }

            return bulls + "A" + cows + "B";
        }
		 //99. Bulls and Cows 
        //根据猜测的数字和目标数字之间的匹配情况,xAyB,x表示Bulls是表示有几个数和位置都对了，Cows表示有几个数猜对了但是位置错了
        //思路：用dictionary来存每个数出现的次数再不是Bulls的情况下，secret的数个数++，guess个数--，因为一旦发现guess里有secret的数，那此时发现的次数肯定+，同理guess里用secret数时次数为-，就证明数猜对了位置错了，因为我们先检查了相同数和位置的情况，剩下的就是不同位置相同数的情况；
        public string GetHint2(string secret, string guess)
        {
            int bulls = 0;
            int cows = 0;
            Dictionary<char, int> count = new Dictionary<char, int>();

            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    if (!count.ContainsKey(secret[i]))
                        count[secret[i]] = 0;
                    if (!count.ContainsKey(guess[i]))
                        count[guess[i]] = 0;

                    if (count[secret[i]] < 0) cows++;
                    if (count[guess[i]] > 0) cows++;

                    count[secret[i]]++;
                    count[guess[i]]--;
                }
            }

            return $"{bulls}A{cows}B";
        }