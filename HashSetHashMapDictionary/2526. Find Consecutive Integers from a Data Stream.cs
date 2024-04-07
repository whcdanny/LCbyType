//Leetcode 2526. Find Consecutive Integers from a Data Stream med
//题意：实现一个数据结构 DataStream，用于处理整数流。该数据结构具有以下功能：
//初始化时指定两个整数 value 和 k。
//向数据流中添加整数，并检查最后 k 个整数是否都等于 value。
//思路：hashtable, 看code
//时间复杂度：O(1) 
 //空间复杂度：队列的空间复杂度为 O(k)。计数器的空间复杂度为 O(1)。
        public class DataStream
        {
            List<bool> m_list;
            int m_value, _k, m_length;
            public DataStream(int value, int k)
            {
                m_list = new List<bool>();
                m_value = value;
                _k = k;
                m_length = 1;
            }

            public bool Consec(int num)
            {
                if (num != m_value)
                {
                    m_length = 1;
                    m_list.Add(false);
                    return false;
                }
                else if (num == m_value && m_length < _k)
                {
                    m_length++;
                    m_list.Add(false);
                }
                else
                {
                    m_length++;
                    m_list.Add(true);
                }
                return m_list.Last();
            }
        }

        /**
         * Your DataStream object will be instantiated and called as such:
         * DataStream obj = new DataStream(value, k);
         * bool param_1 = obj.Consec(num);
         */