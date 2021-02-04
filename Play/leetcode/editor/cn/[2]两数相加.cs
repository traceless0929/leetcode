//给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。 
//
// 如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。 
//
// 您可以假设除了数字 0 之外，这两个数都不会以 0 开头。 
//
// 示例： 
//
// 输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
//输出：7 -> 0 -> 8
//原因：342 + 465 = 807
// 
// Related Topics 链表 数学 
// 👍 5198 👎 0


//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public partial class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        //结果链表
        ListNode res = new ListNode(0);
        //前一个节点
        var preNode = res;
        //进位
        int val = 0;
        //有一个不为空，计算
        while (l1 != null || l2 != null)
        {
            //当前和（没有进位前，有可能有一个是null，null时为0）
            val = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + val;
            //进位余数，当前与10取余
            preNode.next = new ListNode(val % 10);
            //节点移动
            preNode = preNode.next;
            //进位数，当前与10相除
            val = val / 10;
            //节点移动
            l1 = l1?.next;
            l2 = l2?.next;
        }
        //注意判断最后一次计算还有进位的情况，有的话赋值节点
        if (val != 0) preNode.next = new ListNode(val);
        return res.next;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
