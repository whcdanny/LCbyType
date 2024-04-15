//Leetcode 2166. Design Bitset med
//题意：实现一个 Bitset 类，该类支持以下操作：
//Bitset(int size) : 初始化一个大小为 size 的 Bitset，所有位都为 0。
//void fix(int idx): 将索引为 idx 的位的值更新为 1。如果值已经是 1，则不做修改。
//void unfix(int idx): 将索引为 idx 的位的值更新为 0。如果值已经是 0，则不做修改。
//void flip(): 反转 Bitset 中每个位的值。换句话说，所有值为 0 的位现在将值变为 1，反之亦然。
//boolean all(): 检查 Bitset 中的每个位的值是否都为 1。如果满足条件，则返回 true，否则返回 false。
//boolean one(): 检查 Bitset 中是否至少有一个值为 1 的位。如果满足条件，则返回 true，否则返回 false。
//int count(): 返回 Bitset 中值为 1 的位的总数。
//String toString(): 返回 Bitset 的当前状态。注意，在结果字符串中，第 i 个索引的字符应该与 Bitset 的第 i 位的值相符。
//思路：hashtable 看code
//时间复杂度：O(n)
//空间复杂度：O(1)
        public class Bitset
        {            
            StringBuilder stringBuilder;
            int hasOneCount;

            StringBuilder flip;
            int length;

            public Bitset(int size)
            {
                stringBuilder = new StringBuilder();
                hasOneCount = 0;

                flip = new StringBuilder();

                length = size;

                for (int i = 0; i < length; i++)
                {
                    stringBuilder.Append('0');
                    flip.Append('1');
                }
            }

            public void Fix(int idx)
            {
                if (stringBuilder[idx] != '1')
                {
                    stringBuilder[idx] = '1';
                    hasOneCount++;

                    flip[idx] = '0';
                }
            }

            public void Unfix(int idx)
            {
                if (stringBuilder[idx] != '0')
                {
                    stringBuilder[idx] = '0';
                    hasOneCount--;

                    flip[idx] = '1';
                }
            }

            public void Flip()
            {               
                hasOneCount = length - hasOneCount;

                StringBuilder tempPointer = stringBuilder;
                stringBuilder = flip;
                flip = tempPointer;
            }

            public bool All()
            {
                return (hasOneCount == length);
            }

            public bool One()
            {
                return (hasOneCount > 0);
            }

            public int Count()
            {
                return hasOneCount;
            }

            public string ToString()
            {
                return stringBuilder.ToString();
            }
        }