//677. Map Sum Pairs med
//实现function
//思路： triemap

public class TrieNode
{
    public int Value;
    public TrieNode[] Children;

    public TrieNode()
    {
        Value = 0;
        Children = new TrieNode[26];
    }
}

public class MapSum
{
    private TrieNode root;

    public MapSum()
    {
        root = new TrieNode();
    }

    public void Insert(string key, int val)
    {
        TrieNode node = root;

        foreach (char c in key)
        {
            int index = c - 'a';

            if (node.Children[index] == null)
            {
                node.Children[index] = new TrieNode();
            }

            node = node.Children[index];
        }

        node.Value = val;
    }

    public int Sum(string prefix)
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

        return SumNodes(node);
    }

    private int SumNodes(TrieNode node)
    {
        int sum = node.Value;

        foreach (TrieNode child in node.Children)
        {
            if (child != null)
            {
                sum += SumNodes(child);
            }
        }

        return sum;
    }
}