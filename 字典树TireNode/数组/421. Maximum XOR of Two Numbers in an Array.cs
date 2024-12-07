//Leetcode 421. Maximum XOR of Two Numbers in an Array med
//题意：给定一个整数数组 nums，返回其中两个数的最大异或 (XOR) 结果，即找到两个索引 
//i 和 j(0≤i≤j<n)，使得nums[i]⊕nums[j] 的结果最大。
//思路：Trie 树定义：
//TrieNode 类：包含 Children（用于存储子节点）。分别表示二进制的 0 和 1
// 构建前缀树根节点 将数字插入前缀树
//从高位到低位,提取当前位
//计算最大异或值
//尝试选择相反的位 (bit ^ 1 是相反的值)
//当前位的异或值为 1，则累加到 currXOR
//移动到相反路径
//没有相反路径，只能选择相同路径                
//时间复杂度: O(n) 
//空间复杂度：O(n) 
        public class TrieNode_421
        {
            public TrieNode_421[] children;
            public TrieNode_421()
            {
                // 每个节点最多有两个子节点，分别表示二进制的 0 和 1。
                children = new TrieNode_421[2];
            }
        }
        public int FindMaximumXOR(int[] nums)
        {
            //构建前缀树根节点
            TrieNode_421 root = new TrieNode_421();

            //将数字插入前缀树
            foreach (int num in nums)
            {
                TrieNode_421 curr = root;
                for (int i = 31; i >= 0; i--)//从高位到低位
                {
                    int bit = (num >> i) & 1;// 提取当前位
                    if (curr.children[bit] == null)
                    {
                        curr.children[bit] = new TrieNode_421();
                    }
                    curr = curr.children[bit];
                }
            }

            int maxXOR = int.MinValue;

            //计算最大异或值
            foreach (int num in nums)
            {
                TrieNode_421 curr = root;
                int currXOR = 0;
                for (int i = 31; i >= 0; i--)
                {
                    int bit = (num >> i) & 1;
                    if (curr.children[bit ^ 1] != null)//尝试选择相反的位 (bit ^ 1 是相反的值)
                    {
                        currXOR += (1 << i);//当前位的异或值为 1，则累加到 currXOR
                        curr = curr.children[bit ^ 1];// 移动到相反路径
                    }
                    else
                    {
                        curr = curr.children[bit];// 没有相反路径，只能选择相同路径
                    }
                }
                maxXOR = Math.Max(maxXOR, currXOR);
            }

            return maxXOR;
        }