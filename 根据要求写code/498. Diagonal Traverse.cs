//Leetcode 498. Diagonal Traverse med
//题目：设计一个循环双端队列（Circular Double-Ended Queue，Deque）。
//实现 MyCircularDeque 类，该类支持以下操作：
//MyCircularDeque(int k)：初始化双端队列，最大容量为 k。
//boolean insertFront()：在双端队列的队首插入一个元素。如果操作成功，返回 true，否则返回 false。
//boolean insertLast()：在双端队列的队尾插入一个元素。如果操作成功，返回 true，否则返回 false。
//boolean deleteFront()：删除队首的一个元素。如果操作成功，返回 true，否则返回 false。
//boolean deleteLast()：删除队尾的一个元素。如果操作成功，返回 true，否则返回 false。
//int getFront()：获取队首的元素。如果队列为空，返回 -1。
//int getRear()：获取队尾的元素。如果队列为空，返回 -1。
//boolean isEmpty()：检查队列是否为空。如果为空，返回 true，否则返回 false。
//boolean isFull()：检查队列是否已满。如果已满，返回 true，否则返回 false。
//思路: 定义循环双端队列：
//使用数组实现队列的存储。
//通过两个指针 front 和 rear 表示队首和队尾。
//队列为空的条件：front == rear && size == 0。
//队列满的条件：size == k。
//循环特性：
//数组是固定大小k，为了实现循环：
//插入时的下一位置为(index + 1) % k。循环向后移动
//删除时的上一位置为(index - 1 + k) % k。循环向前移动
//实现方法：
//每次插入、删除时更新 front 或 rear，并调整 size
//时间复杂度：O(1)
//空间复杂度：O(k)
        public class MyCircularDeque
        {
            private int[] deque; // 存储双端队列元素
            private int front;   // 队首指针
            private int rear;    // 队尾指针
            private int size;    // 当前队列大小
            private int capacity; // 队列容量

            public MyCircularDeque(int k)
            {
                deque = new int[k];
                capacity = k;
                front = 0;
                rear = 0;
                size = 0;
            }

            public bool InsertFront(int value)
            {
                if (IsFull()) return false;

                front = (front - 1 + capacity) % capacity; // 循环向前移动
                deque[front] = value;
                size++;
                return true;
            }

            public bool InsertLast(int value)
            {
                if (IsFull()) return false;

                deque[rear] = value;
                rear = (rear + 1) % capacity; // 循环向后移动
                size++;
                return true;
            }

            public bool DeleteFront()
            {
                if (IsEmpty()) return false;

                front = (front + 1) % capacity; // 循环向后移动
                size--;
                return true;
            }

            public bool DeleteLast()
            {
                if (IsEmpty()) return false;

                rear = (rear - 1 + capacity) % capacity; // 循环向前移动
                size--;
                return true;
            }

            public int GetFront()
            {
                if (IsEmpty()) return -1;

                return deque[front];
            }

            public int GetRear()
            {
                if (IsEmpty()) return -1;

                return deque[(rear - 1 + capacity) % capacity]; // 队尾前一个位置
            }

            public bool IsEmpty()
            {
                return size == 0;
            }

            public bool IsFull()
            {
                return size == capacity;
            }
        }