//Leetcode 2130. Maximum Twin Sum of a Linked List med
//题意：给定一个偶数长度的链表，链表中的每个节点都有一个"twin"，满足如下规则：第 i 个节点（从 0 开始索引）是第 (n-1-i) 个节点的"twin"，其中 n 为链表的长度。
//例如，如果 n = 4，那么节点 0 是节点 3 的"twin"，节点 1 是节点 2 的"twin"。对于 n = 4，这是唯一有"twin"的节点。
//"twin sum" 定义为一个节点及其"twin"之和。
//给定偶数长度链表的头节点，返回链表中"twin sum"的最大值。
//思路：快慢针，用快慢针找到mid并且把mid之前的值都存下，这样slow此时指向mid，然下一个就可以跟list里的最后一个进行相加，算出离mid最近的twin值，然后找出max 
//注：快慢针
//时间复杂度: O(n)
//空间复杂度：O(1)
public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) 
    {
        this.val = val;
        this.next = next;
    }
}
        public int PairSum(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head.next;

            List<int> temp = new List<int>();
            temp.Add(slow.val);

            //用快慢针 找到中心点，
            while (fast.next != null)
            {
                slow = slow.next;
                temp.Add(slow.val);
                fast = fast.next.next;
            }

            //因为temp先找存了前半段，然后找到了mid，这样可以算出离mid最近的twin值，然后找出max           
            int maxTwinSum = int.MinValue;
            for (int i = temp.Count - 1; i >= 0; i--)
            {
                slow = slow.next;
                temp[i] += slow.val;
                maxTwinSum = Math.Max(maxTwinSum, temp[i]);
            }

            return maxTwinSum;
        }