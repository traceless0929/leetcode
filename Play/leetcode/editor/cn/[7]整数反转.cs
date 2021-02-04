//给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。 
//
// 示例 1: 
//
// 输入: 123
//输出: 321
// 
//
// 示例 2: 
//
// 输入: -123
//输出: -321
// 
//
// 示例 3: 
//
// 输入: 120
//输出: 21
// 
//
// 注意: 
//
// 假设我们的环境只能存储得下 32 位的有符号整数，则其数值范围为 [−231, 231 − 1]。请根据这个假设，如果反转后整数溢出那么就返回 0。 
// Related Topics 数学 
// 👍 2307 👎 0


//leetcode submit region begin(Prohibit modification and deletion)

using System;

public partial class Solution {
    public int Reverse(int x)
    {
        try
        {
            bool isB = x > -1;
            string str = Math.Abs(x)+"";
            str = ReverseString(str);
            int now = int.Parse(str);
            now = isB ? now : -now;
            return now;
        }
        catch (Exception e)
        {
            return 0;
        }
        
    }
    
    public string ReverseString(string input)
    {
        if (String.IsNullOrEmpty(input))
        {
            return input; 
        }

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new String(charArray); 
    }
}
//leetcode submit region end(Prohibit modification and deletion)
