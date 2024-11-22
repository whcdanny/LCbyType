//Leetcode 146. LRU Cache med
//题意：设计并实现一个 LRU (最近最少使用) 缓存机制。它应该支持以下操作：获取数据 get 和写入数据 put。
//get(key) - 如果密钥 key 存在于缓存中，则获取密钥的值（总是正数），否则返回 -1。
//put(key, value) - 如果密钥不存在，则写入其数据值。当缓存容量达到上限时，它应该在写入新数据之前删除最久未使用的数据值，从而为新数据值留出空间。
//思路：LRU Cache需要在常数时间内完成 get 和 put 操作。使用哈希表（HashMap）来存储键值对，并且使用双向链表来维护最近访问的顺序。
//时间复杂度：get 操作的时间复杂度是 O(1)。 put 操作的时间复杂度是 O(1)。
//空间复杂度：O(capacity)
        public class LRUCache
        {
            private Dictionary<int, LinkedListNode<(int, int)>> keyToNode;
            private LinkedList<(int, int)> cache;
            private int capacity;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                keyToNode = new Dictionary<int, LinkedListNode<(int, int)>>();
                cache = new LinkedList<(int, int)>();
            }

            public int Get(int key)
            {
                if (keyToNode.TryGetValue(key, out var node))
                {
                    cache.Remove(node);
                    cache.AddFirst(node);
                    return node.Value.Item2;
                }
                return -1;
            }

            public void Put(int key, int value)
            {
                if (keyToNode.TryGetValue(key, out var node))
                {
                    cache.Remove(node);
                    cache.AddFirst((key, value));
                    keyToNode[key] = cache.First;
                }
                else
                {
                    if (cache.Count >= capacity)
                    {
                        var last = cache.Last;
                        cache.RemoveLast();
                        keyToNode.Remove(last.Value.Item1);
                    }
                    cache.AddFirst((key, value));
                    keyToNode[key] = cache.First;
                }
            }
        }