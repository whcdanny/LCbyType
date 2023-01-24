//83. Remove Duplicates from Sorted List med
//移除重复元素，给出无重复的ListNode
//思路：使用快慢针，慢针的next永远指向不重复的元素
public ListNode DeleteDuplicates(ListNode head)
            {
                if (head == null) return null;
                ListNode slow = head, fast = head;
                while (fast != null)
                {
                    if (fast.val != slow.val)
                    {                        
                        slow.next = fast;                        
                        slow = slow.next;
                    }                    
                    fast = fast.next;
                }
                // 断开与后面重复元素的连接
                slow.next = null;

                return head;
            }