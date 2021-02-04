//给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。 
//
// 
//
// 示例 1： 
//
// 
//
// 
//输入：height = [0,1,0,2,1,0,1,3,2,1,2,1]
//输出：6
//解释：上面是由数组 [0,1,0,2,1,0,1,3,2,1,2,1] 表示的高度图，在这种情况下，可以接 6 个单位的雨水（蓝色部分表示雨水）。 
// 
//
// 示例 2： 
//
// 
//输入：height = [4,2,0,3,2,5]
//输出：9
// 
//
// 
//
// 提示： 
//
// 
// n == height.length 
// 0 <= n <= 3 * 104 
// 0 <= height[i] <= 105 
// 
// Related Topics 栈 数组 双指针 动态规划 
// 👍 1983 👎 0


//leetcode submit region begin(Prohibit modification and deletion)

using System;

public partial class Solution {
    public int Trap(int[] height) {
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
            while (left < right){
                //获取左边最高
                leftMax = Math.Max(leftMax, height[left]);
                //获取右边最高
                rightMax = Math.Max(rightMax, height[right]);
                //左右那边高就计算那边的高度
                ans += leftMax <= rightMax ? leftMax - height[left++] : rightMax - height[right--];
            }
            return ans;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
