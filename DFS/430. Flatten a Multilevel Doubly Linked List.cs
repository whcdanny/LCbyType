//Leetcode 430. Flatten a Multilevel Doubly Linked List med
//题意：给定一个具有多级结构的双向链表，其中节点除了有一个 next 指针指向下一个节点，还有一个 child 指针指向链表中的一个子链表。如果存在 child 指针，则将子链表展平到当前节点的 next 指针之后。
//要求在展平后的链表中，所有节点的 child 指针都应为 null。       
//思路：深度优先搜索（DFS）从头节点开始，按顺序遍历每个节点。如果当前节点有 child 指针，递归展平子链表。将展平后的子链表连接到当前节点的 next 指针之后。继续遍历下一个节点。        
//时间复杂度: O(N)，其中 N 是链表的节点数量。
//空间复杂度：O(N
        public class Node_Flatten
        {
            public int val;
            public Node_Flatten prev;
            public Node_Flatten next;
            public Node_Flatten child;
        }
        public Node_Flatten Flatten(Node_Flatten head)
        {
            DFS_Flatten(head);
            return head;
        }

        private Node_Flatten DFS_Flatten(Node_Flatten node)
        {
            if (node == null) return null;

            Node_Flatten curr = node;
            Node_Flatten tail = node;

            while (curr != null)
            {
                Node_Flatten child = curr.child;
                Node_Flatten next = curr.next;

                if (child != null)
                {
                    curr.child = null;
                    Node_Flatten childTail = DFS_Flatten(child);
                    childTail.next = next;

                    if (next != null)
                    {
                        next.prev = childTail;
                    }

                    curr.next = child;
                    child.prev = curr;

                    curr = tail;
                }

                if (curr.next != null)
                {
                    curr = curr.next;
                    tail = curr;
                }
                else
                {
                    break;
                }
            }
            return tail;
        }