//Leetcode 1616. Split Two Strings to Make Palindrome med
//题意：给定两个长度相同的字符串 a 和 b。选择一个索引并在相同的索引处将两个字符串拆分，将 a 拆分为两个字符串：aprefix 和 asuffix，其中 a = aprefix + asuffix，将 b 拆分为两个字符串：bprefix 和 bsuffix，其中 b = bprefix + bsuffix。
//检查 aprefix + bsuffix 或 bprefix + asuffix 是否构成回文串。
//在将字符串 s 拆分为 sprefix 和 ssuffix 时，允许 ssuffix 或 sprefix 中的一个为空。例如，如果 s = "abc"，则 "" + "abc"，"a" + "bc"，"ab" + "c" 和 "abc" + "" 都是有效的拆分。
//如果能够构成回文串，则返回 true，否则返回 false。
//思路：双指针,因为a，b长度相同，所以a,b或者b,a；
//然后二分，一个指向a开头，一个指向b尾部，然后判断是否有相同的字母，然后检查a或者b本身还是不是对称，因为我们可以选一个空配上a本身或者b本身；
//时间复杂度：O(n)
//空间复杂度：O(1)
        public bool CheckPalindromeFormation(string a, string b)
        {
            return validate(a, b) || validate(b, a);
        }

        bool validate(string a, string b)
        {
            int left = 0, right = a.Length - 1;
            while (left < right)
            {
                if (a[left] != b[right])
                    break;
                left++;
                right--;
            }

            return isPalindrome(a, left, right) || isPalindrome(b, left, right);
        }

        bool isPalindrome(string a, int left, int right)
        {
            while (left < right)
            {
                if (a[left] != a[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }