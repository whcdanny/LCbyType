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
        //146. LRU Cache med
        //按要求写Least Recently Used (LRU) cache.
        //思路：要让 put 和 get 方法的时间复杂度为 O(1)；LRU 缓存算法的核心数据结构就是哈希链表，双向链表和哈希表的结合体；这里我们用自创的doublelist，因为C#没有LinkedHashMap；这个双向连表明尾部为最近使用，因为我们要考虑到容量，满了就要删掉不常用的也就是双向连的头部； 因为是双向链，所以当年添加在尾部的时候不仅要明确添加的prev和next，也要把尾部的prev和next明确；
        class DoubleListNode
        {
            public int key, val;
            public DoubleListNode next, prev;
            public DoubleListNode(int k, int v)
            {
                this.key = k;
                this.val = v;
            }
        }
        class DoubleList
        {
            // 头尾虚节点
            public DoubleListNode head, tail;
            // 链表元素数
            public int size;

            public DoubleList()
            {
                // 初始化双向链表的数据
                head = new DoubleListNode(0, 0);
                tail = new DoubleListNode(0, 0);
                head.next = tail;
                tail.prev = head;
                size = 0;
            }

            // 在链表尾部添加节点 x，时间 O(1)
            public void addLast(DoubleListNode x)
            {
                x.prev = tail.prev;
                x.next = tail;
                tail.prev.next = x;
                tail.prev = x;
                size++;
            }

            // 删除链表中的 x 节点（x 一定存在）
            // 由于是双链表且给的是目标 Node 节点，时间 O(1)
            public void remove(DoubleListNode x)
            {
                x.prev.next = x.next;
                x.next.prev = x.prev;
                size--;
            }

            // 删除链表中第一个节点，并返回该节点，时间 O(1)
            public DoubleListNode removeFirst()
            {
                if (head.next == tail)
                    return null;
                DoubleListNode first = head.next;
                remove(first);
                return first;
            }

            // 返回链表长度，时间 O(1)
            public int Size() { return size; }

        }
        public class LRUCache_old
        {
            private Dictionary<int, DoubleListNode> map;
            // Node(k1, v1) <-> Node(k2, v2)...
            private DoubleList cache;
            // 最大容量
            private int cap;
            public LRUCache_old(int capacity)
            {
                this.cap = capacity;
                map = new Dictionary<int, DoubleListNode>();
                cache = new DoubleList();
            }

            public int Get(int key)
            {
                if (!map.ContainsKey(key))
                {
                    return -1;
                }
                // 将该数据提升为最近使用的
                makeRecently(key);
                return map[key].val;
            }

            public void Put(int key, int value)
            {
                if (map.ContainsKey(key))
                {
                    // 删除旧的数据
                    deleteKey(key);
                    // 新插入的数据为最近使用的数据
                    addRecently(key, value);
                    return;
                }

                if (cap == cache.Size())
                {
                    // 删除最久未使用的元素
                    removeLeastRecently();
                }
                // 添加为最近使用的元素
                addRecently(key, value);
            }
            /* 将某个 key 提升为最近使用的 */
            private void makeRecently(int key)
            {
                DoubleListNode x = map[key];
                // 先从链表中删除这个节点
                cache.remove(x);
                // 重新插到队尾
                cache.addLast(x);
            }

            /* 添加最近使用的元素 */
            private void addRecently(int key, int val)
            {
                DoubleListNode x = new DoubleListNode(key, val);
                // 链表尾部就是最近使用的元素
                cache.addLast(x);
                // 别忘了在 map 中添加 key 的映射
                map.Add(key, x);
            }

            /* 删除某一个 key */
            private void deleteKey(int key)
            {
                DoubleListNode x = map[key];
                // 从链表中删除
                cache.remove(x);
                // 从 map 中删除
                map.Remove(key);
            }

            /* 删除最久未使用的元素 */
            private void removeLeastRecently()
            {
                // 链表头部的第一个元素就是最久未使用的
                DoubleListNode deletedNode = cache.removeFirst();
                // 同时别忘了从 map 中删除它的 key
                int deletedKey = deletedNode.key;
                map.Remove(deletedKey);
            }
        }

        /**
         * Your LRUCache object will be instantiated and called as such:
         * LRUCache obj = new LRUCache(capacity);
         * int param_1 = obj.Get(key);
         * obj.Put(key,value);
         */