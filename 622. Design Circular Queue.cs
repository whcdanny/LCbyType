622. Design Circular Queue
//C#
	public class MyCircularQueue
        {
            private int[] circularArr;
            private int front;
            private int rear;
            private int count; 

            public MyCircularQueue(int k)
            {
                circularArr = new int[k];
                front = 0;
                rear = -1;
                count = 0;
            }

            public bool EnQueue(int value)
            {
                if (count == circularArr.Length)
                {
                    return false;
                }
                rear = (rear + 1) % circularArr.Length;
                circularArr[rear] = value;
                count++;
                return true;
            }

            public bool DeQueue()
            {
                if (count == 0)
                {
                    return false;
                }
                front = (front + 1) % circularArr.Length;
                count--;
                return true;
            }

            public int Front()
            {
                if (count == 0)
                { 
                    return -1;
                }
                return circularArr[front];
            }

            public int Rear()
            {
                if (count == 0)
                { 
                    return -1;
                }
                return circularArr[rear];
            }

            public bool IsEmpty()
            {
                return count == 0;
            }

            public bool IsFull()
            {
                return count == circularArr.Length;
            }
        }