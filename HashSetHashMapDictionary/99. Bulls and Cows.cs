//99. Bulls and Cows med
//根据猜测的数字和目标数字之间的匹配情况,xAyB,x表示Bulls是表示有几个数和位置都对了，Cows表示有几个数猜对了但是位置错了
//思路：用dictionary来存每个数出现的次数再不是Bulls的情况下，secret的数个数++，guess个数--，因为一旦发现guess里有secret的数，那此时发现的次数肯定+，同理guess里用secret数时次数为-，就证明数猜对了位置错了，因为我们先检查了相同数和位置的情况，剩下的就是不同位置相同数的情况；
        public string GetHint(string secret, string guess)
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