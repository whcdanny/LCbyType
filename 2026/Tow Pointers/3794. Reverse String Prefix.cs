//Leetcode 3794. Reverse String Prefix ez
//题意：反转前k个字母在s中
//思路：双针，left是0，right根据k-1
//时间复杂度:  O(n)
//空间复杂度： O(n)
        public string ReversePrefix(string s, int k)
        {
            char[] chars = s.ToCharArray();
            int left = 0;
            int right = k - 1;
            while(right > left)
            {
                char temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;
                right--;
                left++;
            }
            return new string(chars);
        }