//1804. Implement Trie II (Prefix Tree) med
//Trie高效存储，检索一些列字符串；
//思路：TrieMap
public class TrieNode
{
    public int Count;
    public TrieNode[] Children;

    public TrieNode()
    {
        Count = 0;
        Children = new TrieNode[26];
    }
}

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
            int index = c - 'a';

            if (node.Children[index] == null)
            {
                node.Children[index] = new TrieNode();
            }

            node = node.Children[index];
            node.Count++;
        }
    }

    public int CountWordsEqualTo(string word)
    {
        TrieNode node = root;

        foreach (char c in word)
        {
            int index = c - 'a';

            if (node.Children[index] == null)
            {
                return 0;
            }

            node = node.Children[index];
        }

        return node.Count;
    }

    public int CountWordsStartingWith(string prefix)
    {
        TrieNode node = root;

        foreach (char c in prefix)
        {
            int index = c - 'a';

            if (node.Children[index] == null)
            {
                return 0;
            }

            node = node.Children[index];
        }

        return CountNodes(node);
    }

    private int CountNodes(TrieNode node)
    {
        int count = node.Count;

        foreach (TrieNode child in node.Children)
        {
            if (child != null)
            {
                count += CountNodes(child);
            }
        }

        return count;
    }

    public void Erase(string word)
    {
        TrieNode node = root;

        foreach (char c in word)
        {
            int index = c - 'a';

            if (node.Children[index] == null)
            {
                return;
            }

            node = node.Children[index];
            node.Count--;
        }
    }
}

public class Trie2
{
    private Trie trie;

    public Trie2()
    {
        trie = new Trie();
    }

    public void Insert(string word)
    {
        trie.Insert(word);
    }

    public int CountWordsEqualTo(string word)
    {
        return trie.CountWordsEqualTo(word);
    }

    public int CountWordsStartingWith(string prefix)
    {
        return trie.CountWordsStartingWith(prefix);
    }

    public void Erase(string word)
    {
        trie.Erase(word);
    }
}