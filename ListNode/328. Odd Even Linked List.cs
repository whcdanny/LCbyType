//328. Odd Even Linked List med
//将偶数位置放在奇数位置之后
//思路：奇数偶数针，每一个指向下一个相对于的奇偶位置，相当于奇数的next是奇数位，然后偶数的next是偶数位
//然后预先把一开始的偶数位存下来，等奇数位置全部link上之后 之际link一开始的偶数位，因为此时偶数位也都link上
		public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode odd = head;
            ListNode even = new ListNode(-1);
            if (head.next != null)
                even = head.next;
            else
                even = null;
            ListNode res = even;
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            odd.next = res;
            return head;
        }