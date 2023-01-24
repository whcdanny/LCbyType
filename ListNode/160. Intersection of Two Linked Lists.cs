//160. Intersection of Two Linked Lists ez
//思路： 类似找闭环的交点，
//第一种：p1 走一步，如果走到 A 链表末尾，转到 B 链表； p2 走一步，如果走到 B 链表末尾，转到 A 链表；
//直到找到是否有交点
		public ListNode getIntersectionNode(ListNode headA, ListNode headB)
        {
            // p1 指向 A 链表头结点，p2 指向 B 链表头结点
            ListNode p1 = headA, p2 = headB;
            while (p1 != p2)
            {
                // p1 走一步，如果走到 A 链表末尾，转到 B 链表
                if (p1 == null) p1 = headB;
                else p1 = p1.next;
                // p2 走一步，如果走到 B 链表末尾，转到 A 链表
                if (p2 == null) p2 = headA;
                else p2 = p2.next;
            }
            return p1;
        }
//第二种：先算出A,B的长度，然后让 p1 和 p2 到达尾部的距离相同，	
//看两个指针是否会相同	
		public ListNode getIntersectionNode1(ListNode headA, ListNode headB)
        {
            int lenA = 0, lenB = 0;
            ListNode p1 = headA;
            ListNode p2 = headB;

            // 计算两条链表的长度
            for (; p1 != null; p1 = p1.next)
            {
                lenA++;
            }
            for (; p2 != null; p2 = p2.next)
            {
                lenB++;
            }
            p1 = headA;
            p2 = headB;
            // 让 p1 和 p2 到达尾部的距离相同            
            if (lenA > lenB)
            {
                for (int i = 0; i < lenA - lenB; i++)
                {
                    p1 = p1.next;
                }
            }
            else
            {
                for (int i = 0; i < lenB - lenA; i++)
                {
                    p2 = p2.next;
                }
            }
            // 看两个指针是否会相同，p1 == p2 时有两种情况：
            // 1、要么是两条链表不相交，他俩同时走到尾部空指针
            // 2、要么是两条链表相交，他俩走到两条链表的相交点
            while (p1 != p2)
            {
                p1 = p1.next;
                p2 = p2.next;
            }
            return p1;
        }