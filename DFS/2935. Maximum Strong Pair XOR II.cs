//Leetcode 2935. Maximum Strong Pair XOR II hard
//题意：给定一个0索引的整数数组nums。如果一对整数x和y满足以下条件，则称其为强对（strong pair）：
//∣x−y∣≤min(x, y)
//你需要从nums中选择两个整数，使其构成强对并且它们的按位异或值（XOR）在所有强对中是最大的。
//返回所有可能的强对中最大XOR值。
//思路：深度优先搜索（DFS）+ TrieNode
//观察|x - y| <= min(x, y)， 假设x是其中较大的那个，很容易推得y<=x<=2y。
//所以我们将nums从小到大排序之后，考察某个数作为y时，可以将一段滑窗内的元素[y,2y]加入一个集合，
//根据y在这个集合里找能与y异或得到最大值的那个元素。
//随着y的移动，这个滑窗的移动也是单调的，说明每个式子进入集合与移出集合都只需要操作一次，时间复杂度是o(N).
//对于求最大XOR pair而言，这样的“集合”必然是用Trie。
//将符合y条件的数字加入Trie之后，从高到低遍历y的每个bit位：
//如果y的bit是1，那么我们就选择在Trie里向下走0的分支（如果存在的话），
//反之我们就在Trie里向下走1的分支。这样走到底之后，你选择的路径所对应的数字就是能与y异或得到最大的结果。
//PS：在Trie里实时加入一条路径很简单，但是如何移除一条路径呢？
//显然不能盲目地删除该路径上的所有节点，因为它可能被其他路径共享。
//技巧是，给每个节点标记一个计数器。
//加入一条路径时，将沿路的节点的计数器加一；
//反之删除一个条路径时，将沿路的节点的计数器减一。
//如果某个节点的计数器为零，意味着该分支已经“虚拟地”从Trie里移出了，就不能再被访问了。
//时间复杂度: O(n log n + n * 32)
//空间复杂度：O(n * 32)
        public class TrieNode_2935
        {
            //只有0，1因为是XOR
            public TrieNode_2935[] next = new TrieNode_2935[2];
            //计数>0表示还在Trie中，如果==0移除了；
            public int count = 0;
        }
        private TrieNode_2935 root;

        public int MaximumStrongPairXor(int[] nums)
        {
            root = new TrieNode_2935();

            Array.Sort(nums);
            int j = 0;
            int ret = int.MinValue / 2;
            for (int i = 0; i < nums.Length; i++)
            {
                //右边界；
                while (j < nums.Length && nums[j] <= 2 * nums[i])
                {
                    //加到字典里
                    Add_Trie(nums[j]);
                    j++;
                }
                ret = Math.Max(ret, Dfs_MaximumStrongPairXor(nums[i], root, 31));
                Remove_Trie(nums[i]);
            }
            return ret;
        }
        private void Add_Trie(int num)
        {
            TrieNode_2935 node = root;
            //从高到低；000000000
            for (int k = 31; k >= 0; k--)
            {
                int bit = (num >> k) & 1;
                //不存在节点建立一个；
                if (node.next[bit] == null)
                    node.next[bit] = new TrieNode_2935();
                //有的话 往下走；
                node = node.next[bit];
                //计数+1；
                node.count += 1;
            }
        }

        private void Remove_Trie(int num)
        {
            TrieNode_2935 node = root;
            for (int k = 31; k >= 0; k--)
            {
                int bit = (num >> k) & 1;
                //不会真的释放，所以用count来表示是否还在Trie中；
                node = node.next[bit];
                //计数-1；
                node.count -= 1;
            }
        }
        //k表示层数；
        private int Dfs_MaximumStrongPairXor(int num, TrieNode_2935 node, int k)
        {
            //走到底了，所以直接+0；
            if (k == -1) return 0;
            int bit = (num >> k) & 1;
            //当前bit是0；
            if (bit == 0)
            {
                //首选1，并且count>0表示存在Trie；
                if (node.next[1] != null && node.next[1].count > 0)
                    return Dfs_MaximumStrongPairXor(num, node.next[1], k - 1) + (1 << k);//可以XOR1； 1 左移 k 位(1 << 0 是 1 （二进制：0001）1 << 1 是 2 （二进制：0010）)
                else if (node.next[0] != null && node.next[0].count > 0)
                    return Dfs_MaximumStrongPairXor(num, node.next[0], k - 1);//都是0，0 XOR 0 还是0；
            }
            //当前bit是1;
            else
            {
                if (node.next[0] != null && node.next[0].count > 0)
                    return Dfs_MaximumStrongPairXor(num, node.next[0], k - 1) + (1 << k);//可以XOR0； 1 左移 k 位
                else if (node.next[1] != null && node.next[1].count > 0)
                    return Dfs_MaximumStrongPairXor(num, node.next[1], k - 1);
            }

            return int.MinValue / 2;
        }