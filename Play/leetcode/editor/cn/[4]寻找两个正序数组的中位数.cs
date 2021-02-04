//给定两个大小为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。请你找出并返回这两个正序数组的中位数。 
//
// 进阶：你能设计一个时间复杂度为 O(log (m+n)) 的算法解决此问题吗？ 
//
// 
//
// 示例 1： 
//
// 输入：nums1 = [1,3], nums2 = [2]
//输出：2.00000
//解释：合并数组 = [1,2,3] ，中位数 2
// 
//
// 示例 2： 
//
// 输入：nums1 = [1,2], nums2 = [3,4]
//输出：2.50000
//解释：合并数组 = [1,2,3,4] ，中位数 (2 + 3) / 2 = 2.5
// 
//
// 示例 3： 
//
// 输入：nums1 = [0,0], nums2 = [0,0]
//输出：0.00000
// 
//
// 示例 4： 
//
// 输入：nums1 = [], nums2 = [1]
//输出：1.00000
// 
//
// 示例 5： 
//
// 输入：nums1 = [2], nums2 = []
//输出：2.00000
// 
//
// 
//
// 提示： 
//
// 
// nums1.length == m 
// nums2.length == n 
// 0 <= m <= 1000 
// 0 <= n <= 1000 
// 1 <= m + n <= 2000 
// -106 <= nums1[i], nums2[i] <= 106 
// 
// Related Topics 数组 二分查找 分治算法 
// 👍 3370 👎 0


//leetcode submit region begin(Prohibit modification and deletion)

using System;

public partial class Solution
{
    //题目的关键是复杂度为log(m+n) ，log(m+n)一般就要想到“二分法”，中位数的性质决定，左边一半的数组小于等于中位数，右边一般的数组大于等于中位数，本身又是排好序的，问题转化为，从两个有序数组中寻找第K小的数[k=(m+n)/2]
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int m = nums2.Length;
        int len = n + m;
        int kPre = (len + 1) / 2;
        int k = (len + 2) / 2;
        if (len % 2 == 0)
            return (findKTh(nums1, 0, n - 1, nums2, 0, m - 1, kPre) + findKTh(nums1, 0, n - 1, nums2, 0, m - 1, k)) * 0.5;
        else
            return findKTh(nums1, 0, n - 1, nums2, 0, m - 1, k);

    }

    public double findKTh(int[] nums1, int s1, int e1, int[] nums2, int s2, int e2, int k)
    {
        //计算长度
        int len1 = e1 - s1 + 1;
        int len2 = e2 - s2 + 1;
        if (len1 > len2)
        {
            //比较大小，保证1<2，防止溢出
            return findKTh(nums2, s2, e2, nums1, s1, e1, k);
        }
        if (len1 == 0)
        {
            //短数组没了，直接取长数组中的值
            return nums2[s2 + k - 1];
        }
        if (k == 1)
        {
            //取第1小的数，表示取最小，两个数组的起始中最小的取出来就行了
            return nums1[s1] > nums2[s2] ? nums2[s2] : nums1[s1];
        }
        //取索引，防止数组越界，超过长度取最后一个
        int i = s1 + Math.Min(len1, k / 2) - 1;
        int j = s2 + Math.Min(len2, k / 2) - 1;
        if (nums1[i] > nums2[j])
        {
            //短数组值大于长数组，淘汰长数组前面j个数，相当于找第k + s2 - 1 - j小
            //k + s2 - 1 - j的解释，k表示当前s2开头的数组为0，的第k小，所以在总数组中是第k+s2-1小，j:本次淘汰的个数
            return findKTh(nums1, s1, e1, nums2, j + 1, e2, k + s2 - 1 - j);
        }
        else
        {
            return findKTh(nums1, i + 1, e1, nums2, s2, e2, k + s1 - 1 - i);
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
