//Leetcode 981. Time Based Key-Value Store med
//题意：题目要求设计一个时序数据库，支持以下两种操作：
//set(string key, string value, int timestamp) : 存储键值对(key, value) ，并在给定的时间戳 timestamp 处设置它。
//get(string key, int timestamp) : 检索键 key 在给定的时间戳 timestamp 处存储的值。
//如果不存在键 key 对应的值在给定时间戳处的记录，那么函数应该返回空字符串 ""。
//思路：使用字典存储键值对：
//对于每个键 key，使用一个字典来存储该键在不同时间戳下的值。字典的键为时间戳，值为对应的值。
//get 操作中使用二分查找：
//对于 get 操作，使用二分查找来找到给定时间戳 timestamp 下的最大的小于等于该时间戳的键值对。
//时间复杂度: set 操作的时间复杂度为 O(1)。get 操作的时间复杂度为 O(log N)，其中 N 是给定键在不同时间戳下的记录数量。
//空间复杂度：O(n)
        public class TimeMap
        {

            private Dictionary<string, List<(int timestamp, string value)>> keyValueMap;

            public TimeMap()
            {
                keyValueMap = new Dictionary<string, List<(int, string)>>();
            }

            public void Set(string key, string value, int timestamp)
            {
                if (!keyValueMap.ContainsKey(key))
                {
                    keyValueMap[key] = new List<(int, string)>();
                }
                keyValueMap[key].Add((timestamp, value));
            }

            public string Get(string key, int timestamp)
            {
                if (keyValueMap.ContainsKey(key))
                {
                    var records = keyValueMap[key];
                    int left = 0, right = records.Count - 1;

                    while (left <= right)
                    {
                        int mid = left + (right - left) / 2;
                        if (records[mid].timestamp <= timestamp)
                        {
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }

                    if (right >= 0)
                    {
                        return records[right].value;
                    }
                }

                return "";
            }
        }

        /**
         * Your TimeMap object will be instantiated and called as such:
         * TimeMap obj = new TimeMap();
         * obj.Set(key,value,timestamp);
         * string param_2 = obj.Get(key,timestamp);
         */
