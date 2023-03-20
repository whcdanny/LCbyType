//460. LFU Cache hard
//按要求写Least Frequently Used (LFU) cache.
//思路：要让 put 和 get 方法的时间复杂度为 O(1)； 如果容量满了，就找到使用率最少的移除，所以建立三个dictionary，分别存储，keyvalur，keyfrequency，frequencykeys；更新keyvalue的时候注意要更新所有的dictionary；
		public class LFUCache
        {
            // key 到 val 的映射，我们后文称为 KV 表
            Dictionary<int, int> keyToVal;
            // key 到 freq 的映射，我们后文称为 KF 表
            Dictionary<int, int> keyToFreq;
            // freq 到 key 列表的映射，我们后文称为 FK 表
            Dictionary<int, List<int>> freqToKeys;
            // 记录最小的频次
            int minFreq;
            // 记录 LFU 缓存的最大容量
            int cap;
            public LFUCache(int capacity)
            {
                keyToVal = new Dictionary<int, int>();
                keyToFreq = new Dictionary<int, int>();
                freqToKeys = new Dictionary<int, List<int>>();
                this.cap = capacity;
                this.minFreq = 0;
            }

            public int Get(int key)
            {
                if (!keyToVal.ContainsKey(key))
                {
                    return -1;
                }
                // 增加 key 对应的 freq
                increaseFreq(key);
                return keyToVal[key];
            }

            public void Put(int key, int value)
            {
                if (this.cap <= 0) return;

                /* 若 key 已存在，修改对应的 val 即可 */
                if (keyToVal.ContainsKey(key))
                {
                    keyToVal[key] = value;
                    // key 对应的 freq 加一
                    increaseFreq(key);
                    return;
                }

                /* key 不存在，需要插入 */
                /* 容量已满的话需要淘汰一个 freq 最小的 key */
                if (this.cap <= keyToVal.Count)
                {
                    removeMinFreqKey();
                }

                /* 插入 key 和 val，对应的 freq 为 1 */
                // 插入 KV 表
                if (keyToVal.ContainsKey(key))
                    keyToVal[key] = value;
                else
                    keyToVal.Add(key, value);
                // 插入 KF 表
                if (keyToFreq.ContainsKey(1))
                    keyToFreq[key] = 1;
                else
                    keyToFreq.Add(key, 1);
                // 插入 FK 表
                if (freqToKeys.ContainsKey(1))
                    freqToKeys[1].Add(key);
                else
                {
                    freqToKeys.Add(1, new List<int>());
                    freqToKeys[1].Add(key);
                }                                    
                // 插入新 key 后最小的 freq 肯定是 1
                this.minFreq = 1;
            }
            private void removeMinFreqKey()
            {
                // freq 最小的 key 列表
                List<int> keyList = freqToKeys[this.minFreq];
                // 其中最先被插入的那个 key 就是该被淘汰的 key
                int deletedKey = keyList[0];
                /* 更新 FK 表 */
                keyList.Remove(deletedKey);
                if (keyList.Count==0)
                {
                    freqToKeys.Remove(this.minFreq);
                    // 问：这里需要更新 minFreq 的值吗？
                }
                /* 更新 KV 表 */
                keyToVal.Remove(deletedKey);
                /* 更新 KF 表 */
                keyToFreq.Remove(deletedKey);
            }
            private void increaseFreq(int key)
            {
                int freq = keyToFreq[key];
                /* 更新 KF 表 */
                keyToFreq[key] = freq + 1;
                /* 更新 FK 表 */
                // 将 key 从 freq 对应的列表中删除
                freqToKeys[freq].Remove(key);
                // 将 key 加入 freq + 1 对应的列表中
                if (freqToKeys.ContainsKey(freq + 1))
                    freqToKeys[freq + 1].Add(key);
                else
                {
                    freqToKeys.Add(freq + 1, new List<int>());
                    freqToKeys[freq + 1].Add(key);
                }                
                // 如果 freq 对应的列表空了，移除这个 freq
                if (freqToKeys[freq].Count==0)
                {
                    freqToKeys.Remove(freq);
                    // 如果这个 freq 恰好是 minFreq，更新 minFreq
                    if (freq == this.minFreq)
                    {
                        this.minFreq++;
                    }
                }
            }
        }

        /**
         * Your LFUCache object will be instantiated and called as such:
         * LFUCache obj = new LFUCache(capacity);
         * int param_1 = obj.Get(key);
         * obj.Put(key,value);
         */