//Leetcode 3093. Longest Common Suffix Queries hard
//题目：你被给定了两个字符串数组 wordsContainer 和 wordsQuery：
//对于每个 wordsQuery[i]，需要在 wordsContainer 中找到一个字符串：
//它与 wordsQuery[i] 拥有最长的公共后缀。
//如果有多个字符串的公共后缀长度相同，则选择长度最小的字符串。
//如果长度也相同，则选择在 wordsContainer 中最早出现的字符串。
//返回一个整数数组 ans，其中 ans[i] 是 wordsContainer 中满足条件的字符串的索引。
//思路: TireNode,
//存入index表示在wordsContainer中的位置，
//然后再有child，存的是对应字母char和其所有的连接的下一个字母根据wordsContainer中每个word
//AddWord：
//将wordsContainer中每个word倒序char，然后放入到TireNode，这样相同字母就往下如果有不同建立新的TireNode
//如果index不是-1，那么就是这个是一个word的结束，并且在wordsContainer中的位置
//Search
//每个wordsQuery中也先倒序，然后现根据wordsQuery的word查找在Trie中最后相对应出现的char，
//然后看index，如果不是-1，那就说明已经找到对应在wordsContainer位置
//如果是1，那就根据这个TrieNode的child然后直到找到index!=-1
//然后更新minlength和index
//时间复杂度：O(n×L+m×K)
//空间复杂度：O(n×L)
        public int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
        {
            var trie = new TrieStringIndices();
            var result = new int[wordsQuery.Length];
            var set = new HashSet<string>();

            for (var i = 0; i < wordsContainer.Length; i++)
            {
                var word = wordsContainer[i];
                if (set.Contains(word)) 
                    continue;
                var charArray = word.ToCharArray();
                Array.Reverse(charArray);
                //倒序
                var reverseWord = new string(charArray);

                trie.AddWord(reverseWord, i);
                set.Add(word);
            }

            for (var i = 0; i < wordsQuery.Length; i++)
            {
                var word = wordsQuery[i];
                var arrayWord = word.ToCharArray();
                Array.Reverse(arrayWord);
                var reverseWord = new string(arrayWord);
                //倒序搜索
                result[i] = trie.Search(reverseWord, wordsContainer);
            }

            return result;
        }
        public class TrieNodeStringIndices
        {
            //记录当前路径对应的字符串索引
            public int Index { get; set; } = -1;
            //存储子节点， 
            public Dictionary<char, TrieNodeStringIndices> Children { get; } = new Dictionary<char, TrieNodeStringIndices>();
        }

        public class TrieStringIndices
        {
            private readonly TrieNodeStringIndices _root = new TrieNodeStringIndices();

            public void AddWord(string word, int index)
            {
                var node = _root;

                foreach (char c in word)
                {
                    if (!node.Children.ContainsKey(c))
                        node.Children[c] = new TrieNodeStringIndices();

                    node = node.Children[c];
                }
                //表示这是一个词结束，并且在wordsContainer的位置
                node.Index = index;
            }

            public int Search(string word, string[] wordsContainer)
            {
                var node = _root;

                foreach (char c in word)
                {
                    if (!node.Children.ContainsKey(c))
                        break;

                    node = node.Children[c];
                }
                //刚好结束的位置是在wordsContainer里有
                if (node.Index != -1) return node.Index;
                
                var queue = new Queue<TrieNodeStringIndices>();
                queue.Enqueue(node);
                //找出后续的最小长度和相对应的位置
                while (queue.Count > 0)
                {
                    var count = queue.Count;
                    var index = int.MaxValue;
                    var minLength = int.MaxValue;

                    for (var i = 0; i < count; i++)
                    {
                        var child = queue.Dequeue();
                        //说明现在找到了一个完整的word在wordsContainer中
                        if (child.Index != -1)
                        {
                            //更新最小长度和位置；
                            if (wordsContainer[child.Index].Length < minLength)
                            {
                                minLength = wordsContainer[child.Index].Length;
                                index = child.Index;
                            }
                            //如果长度一样，那么就找最先出现在wordsContainer里的
                            else if (wordsContainer[child.Index].Length == minLength && child.Index < index)
                                index = child.Index;
                        }
                        //将子集放入queue中；
                        foreach (var c in child.Children)
                            queue.Enqueue(c.Value);
                    }
                    //如果有index就结束；
                    if (index < int.MaxValue) 
                        return index;
                }

                return 0;
            }
        }        