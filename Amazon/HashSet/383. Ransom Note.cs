//Leetcode 383. Ransom Note ez
//题意：给定两个字符串ransomNote和magazine，true如果可以使用和ransomNote中的字母构造，则返回，否则返回。
//magazinefalse中的每个字母magazine只能使用一次ransomNote。
//思路：把magazine每个字母的出现个数统计list，然后历遍ransomNote，
//把对应的个数list[ransomNote[i] - 'a']--;，如果有不存在list，那么就是false
//时间复杂度:  O(m+n) 
//空间复杂度： O(1)
        public bool CanConstruct(string ransomNote, string magazine)
        {            
            char[] list = new char[26];
            foreach (char c in magazine)
            {
                list[c - 'a']++;
            }
            for(int i = 0; i < ransomNote.Length; i++)
            {
                if (list[ransomNote[i] - 'a'] > 0)
                {
                    list[ransomNote[i] - 'a']--;
                }
                else
                {
                    return false;
                }
            }
            return true;

        }