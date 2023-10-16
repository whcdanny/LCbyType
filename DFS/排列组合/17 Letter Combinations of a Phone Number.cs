//Leetcode 17 Letter Combinations of a Phone Number med
//题意：给定一个数字字符串，返回所有可能的字母组合
//思路：深度优先搜索（DFS）: 每个数字与对应的字母映射关系存储在一个字典中。然后，从数字字符串的第一个数字开始，依次遍历该数字对应的所有字母。在遍历的过程中，递归调用，将当前数字的每个字母依次添加到当前组合中，然后继续处理下一个数字
//时间复杂度:  数字字符串的长度为 n, O(4^n)
//空间复杂度： O(n)
        Dictionary<char, string> phoneMap = new Dictionary<char, string>(){
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };

        public IList<string> LetterCombinations(string digits)
        {
            List<string> combinations = new List<string>();
            if (digits.Length == 0)
            {
                return combinations;
            }
            LetterCombinations_DFS(digits, 0, "", combinations);
            return combinations;
        }

        private void LetterCombinations_DFS(string digits, int index, string combination, List<string> combinations)
        {
            if (index == digits.Length)
            {
                combinations.Add(combination);
                return;
            }

            char digit = digits[index];
            string letters = phoneMap[digit];
            foreach (char letter in letters)
            {
                LetterCombinations_DFS(digits, index + 1, combination + letter, combinations);
            }
        }