//Leetcode 1813. Sentence Similarity III med
//题意：判断两个句子是否相似。两个句子相似的定义是：通过在其中一个句子中插入任意句子（可以为空），使得两个句子变得相等。
//例如，对于句子1 = "Hello my name is Jane" 和句子2 = "Hello Jane"，我们可以在句子2中插入 "my name is" 使得两个句子相等。因此，这两个句子是相似的。
//思路：双指针法，分别从句子1和句子2的两端开始，找到两个句子的共同前缀和共同后缀。在后缀的时候只要找到一个不相同的并且没有历遍完 那就是不存在相似；
//时间复杂度：O(max(len1, len2))
//空间复杂度：O(1)
        public bool AreSentencesSimilar(string sentence1, string sentence2)
        {
            string[] s1 = sentence1.Split(" ");
            string[] s2 = sentence2.Split(" ");
            int i = 0, j = 0;
            while (i < s1.Length && j < s2.Length)
            {
                if (!s1[i].Equals(s2[j])) break;
                i++;
                j++;
            }
            if (i == s1.Length || j == s2.Length) return true;
            int len1 = s1.Length - 1, len2 = s2.Length - 1;
            while (len1 >= i && len2 >= j)
            {
                if (!s1[len1].Equals(s2[len2])) return false;
                len1--;
                len2--;
            }
            return len1 < i || len2 < j;

        }