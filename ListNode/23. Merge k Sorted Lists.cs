//23:给一个ListNode的列表，要求合并所有并且按照升序； hard
//c#暂时还没找到替换PriorityQueue 的办法，所以现在是Java
//思路：把所以ListNode放入这个PriorityQueue 然后根据val来排序 
//算法整体的时间复杂度是 O(Nlogk):其中 k 是链表的条数，N 是这些链表的节点总数
	public ListNode mergeKLists(ListNode[] lists) {
        if (lists.length == 0) return null;       
        ListNode dummy = new ListNode(-1);
        ListNode p = dummy;    
        
        PriorityQueue<ListNode> pq = new PriorityQueue<>(
            lists.length, (a, b)->(a.val - b.val));
        
        for (ListNode head : lists) {
            if (head != null)
                pq.add(head);
        }

        while (!pq.isEmpty()) {        
            ListNode node = pq.poll();
            p.next = node;
            if (node.next != null) {
                pq.add(node.next);
            }            
            p = p.next;
        }
        return dummy.next;
    }