//Leetcode 424. Longest Repeating Character Replacement med
//题意：给定一个字符串 s、一个整数 k，找到一个最长的子串，其中可以通过替换其中的字符来使得任意相同字符的数量都可以变成 k。
//思路：双指针+滑窗。
//窗口定义：窗口的长度是 right - left + 1。
//maxCount我们只保证当前滑窗中出现最多的那个字符
//想让窗口内所有字符都变成出现次数最多的那个字符，那么我们需要替换的次数就是：窗口总长度 - maxCount。
//判断：只要 窗口长度 - maxCount <= k，这个窗口就是可以通过k次修改变成纯相同字符的。
//当不满足条件时，我们将 left 右移。因为我们只关心能否找到比当前 res 更大的值，而只有当 maxCount 变得更大时，res 才可能更新。
//时间复杂度:  n 是字符串的长, O(n)
//空间复杂度： O(26) = O(1)
        public int CharacterReplacement(string s, int k)//fix
        {
            int[] counts = new int[26]; 
            int left = 0;
            int maxCount = 0; 
            int res = 0;

            for (int right = 0; right < s.Length; right++)
            {                
                maxCount = Math.Max(maxCount, ++counts[s[right] - 'A']);
               
                while (right - left + 1 - maxCount > k)
                {
                    counts[s[left] - 'A']--;
                    left++;                    
                }

                res = Math.Max(res, right - left + 1);
            }

            return res;            
        }