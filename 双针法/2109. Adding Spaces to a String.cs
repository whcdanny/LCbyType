//Leetcode 2109. Adding Spaces to a String med
//题意：给定一个字符串 s 和一个整数数组 spaces，数组 spaces 描述了在原始字符串中需要添加空格的位置。每个空格应该插入到给定索引的字符之前。
//例如，给定 s = "EnjoyYourCoffee" 和 spaces = [5, 9]，我们在 'Y' 和 'C' 的前面插入空格，它们分别在索引 5 和 9 处。因此，我们得到 "Enjoy Your Coffee"。
//返回在添加空格后的修改后的字符串。       
//思路：双针，从i是从s和j是从spaces位置开始，如果i的位置==spaces[j]，说明需要添加空格，然后依此添加；       
//时间复杂度: O(n) n 为字符串 s 的长度
//空间复杂度：O(n + m)，其中 m 为数组 spaces 的长度
        public string AddSpaces(string s, int[] spaces)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0, j = 0; i < s.Length; i++)
            {
                if (j < spaces.Length && spaces[j] == i)
                {
                    sb.Append(" ");
                    j++;
                }

                sb.Append(s[i]);
            }

            return sb.ToString();
        }
