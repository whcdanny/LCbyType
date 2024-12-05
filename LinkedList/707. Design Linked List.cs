//Leetcode 707. Design Linked List med
//题意：设计一个链表实现，可以选择实现单链表或双链表。
//节点结构：
//单链表节点包含两个属性：val 表示节点值，next 表示指向下一个节点的指针。
//双链表节点额外包含一个 prev 属性，表示指向前一个节点的指针。
//需要实现的操作：
//MyLinkedList()：初始化链表对象。
//int get(int index)：获取索引为 index 的节点的值。如果索引无效，返回 -1。
//void addAtHead(int val)：在链表头部添加值为 val 的节点。
//void addAtTail(int val)：在链表尾部添加值为 val 的节点。
//void addAtIndex(int index, int val)：在索引为 index 的节点之前插入值为 val 的节点。
//如果 index == 链表长度，则将节点追加到链表尾部。
//如果 index > 链表长度，则不插入节点。
//void deleteAtIndex(int index)：删除索引为 index 的节点，如果索引无效则不进行任何操作
//思路：动态数组模拟链表：
//通过动态扩展数组容量（Resize 方法）来支持动态增长。
//由于底层存储是连续内存，Get 操作的性能优于实际链表实现（O(1) 时间复杂度）。
//实现简单：
//代码逻辑基于数组操作，易于实现。
//使用 Swap 和 DeSwap 进行插入和删除操作。
//1. 核心数据结构capacity当前数组容量; size当前链表节点数int[] values动态数组存储节点值
//Get(int index):通过索引直接访问数组元素。
//AddAtHead(int val)在头部插入新值，需调整所有后续元素位置（通过 Swap）。如果数组已满，调用 Resize 扩容。
//AddAtTail(int val)在尾部追加值，如果数组已满则扩容。
//AddAtIndex(int index, int val)在指定索引处插入新值，需调整后续元素（通过 Swap）。如果数组已满，调用 Resize 扩容。
//DeleteAtIndex(int index)删除指定索引处的元素，需调整后续元素（通过 DeSwap）。如果删除后数组容量过大，调用 Resize 缩容。
//Resize(bool increase, int index)动态扩容或缩容数组，并将原数据拷贝到新数组。如果指定 index，会在 index 后空出一个位置。
//时间复杂度：O(n)
//空间复杂度：O(m)
        public class MyLinkedList
        {
            int capacity;
            int size;
            int[] values;

            public MyLinkedList()
            {
                this.capacity = 1;
                this.size = 0;
                this.values = new int[capacity];
            }
            public int Get(int index)
            {
                if (index < 0 || index > size - 1) return -1;
                else return values[index];
            }
            public void AddAtHead(int val)
            {
                if (this.size + 1 == this.capacity) 
                    Resize(true, 0);
                else 
                    Swap(0);

                this.values[0] = val;
                this.size++;
            }
            public void AddAtTail(int val)
            {
                if (this.size + 1 == this.capacity) 
                    Resize();

                this.values[this.size] = val;
                this.size++;
            }
            public void Resize(bool increase = true, int index = -1)
            {
                if (increase) 
                    this.capacity *= 2;
                else 
                    this.capacity = this.size + 1;

                int[] newArr = new int[this.capacity];

                for (int i = 0; i < this.size; i++)
                {
                    if (i >= index && index != -1) 
                        newArr[i + 1] = values[i];
                    else 
                        newArr[i] = values[i];
                }

                this.values = newArr;
            }
            public void AddAtIndex(int index, int val)
            {
                if (index > this.size) 
                    return;

                if (this.size + 1 == this.capacity) 
                    Resize(true, index);
                else 
                    Swap(index);

                this.values[index] = val;
                this.size++;
            }
            public void DeleteAtIndex(int index)
            {
                if (index > this.size - 1) 
                    return;

                DeSwap(index);
                this.size--;

                if (this.size == capacity / 2) Resize(false);
            }
            public void Swap(int index)
            {
                for (int i = this.size; i >= index; i--) 
                    this.values[i + 1] = this.values[i];
            }

            public void DeSwap(int index)
            {
                for (int i = index; i < this.size - 1; i++) 
                    this.values[i] = this.values[i + 1];

                this.values[this.size - 1] = 0;
            }                                                         
        }