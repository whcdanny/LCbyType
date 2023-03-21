//208. Implement Trie (Prefix Tree) med
//前缀树是一种数据结构，用于高效存储和检索字符串数据集；
//思路：按要求写code；triemap；
public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (!node.ContainsKey(c))
            {
                node[c] = new TrieNode();
            }
            node = node[c];
        }
        node.IsWord = true;
    }

    public bool Search(string word)
    {
        TrieNode node = FindNode(word);
        return node != null && node.IsWord;
    }

    public bool StartsWith(string prefix)
    {
        return FindNode(prefix) != null;
    }

    private TrieNode FindNode(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (!node.ContainsKey(c))
            {
                return null;
            }
            node = node[c];
        }
        return node;
    }
}

public class TrieNode
{
    private TrieNode[] children;
    public bool IsWord { get; set; }

    public TrieNode()
    {
        children = new TrieNode[26];
    }

    public TrieNode this[char c]
    {
        get { return children[c - 'a']; }
        set { children[c - 'a'] = value; }
    }

    public bool ContainsKey(char c)
    {
        return children[c - 'a'] != null;
    }
}