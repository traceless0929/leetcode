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
using System.Collections.Generic;

public partial class Solution {
    public int Trap_1(int[] height) {
        if (null == height)
        {
            return 0;
        }
        int ans = 0;
        int index = 0;
        Stack<int> stack = new Stack<int>();
        //遍历数组
        while (index<height.Length)
        {
            //栈非空 且当前高度大于栈顶高度
            while (stack.Count>0&&height[index]>height[stack.Peek()])
            {
                //底边
                int bottomIndex = stack.Pop();
                //没有左边了，直接出去
                if (stack.Count < 1)
                {
                    break;
                }
                //计算宽度，索引相减再-1
                int width = index - stack.Peek() - 1;
                //最终高度 两边较低的那个减去底边高度
                int heightFianl = Math.Min(height[index], height[stack.Peek()]) - height[bottomIndex];
                ans += width * heightFianl;
            }
            stack.Push(index++);
        }
        return ans;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
