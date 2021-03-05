using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Play
{
    class Program
    {
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

        static void Main(string[] args)
        {

        }


        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            //安全检查 终止条件
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }
            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l2.next, l1);
                return l2;
            }

        }
        public ListNode ReverseList(ListNode head)
        {

            if (head == null || head.next == null)
            {
                return head;
            }

            ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return head;
            // ListNode guardHead = null;
            // while (head != null)
            // {
            //     head = head.next;
            //     ListNode newNode = head;
            //     newNode.next = guardHead;
            //     guardHead = newNode;
            // }
            //
            // return guardHead;
        }

        public int MaxArea(int[] height)
        {
            if (height == null || height.Length <= 0) return 0;
            //左指针
            int left = 0;
            //右指针
            int right = height.Length - 1;
            //左边最高
            int leftMax = 0;
            //右边最高
            int rightMax = 0;
            int ans = 0;
            //左右指针没有碰面
            while (left < right)
            {
                //获取左边最高
                leftMax = Math.Max(leftMax, height[left]);
                //获取右边最高
                rightMax = Math.Max(rightMax, height[right]);
                //左右那边低就计算那边的高度
                ans += leftMax <= rightMax ? leftMax - height[left++] : rightMax - height[right--];
            }
            return ans;

        }
    }
}