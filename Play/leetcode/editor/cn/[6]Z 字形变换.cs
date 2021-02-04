//将一个给定字符串根据给定的行数，以从上往下、从左到右进行 Z 字形排列。 
//
// 比如输入字符串为 "LEETCODEISHIRING" 行数为 3 时，排列如下： 
//
// L   C   I   R
//E T O E S I I G
//E   D   H   N
// 
//
// 之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："LCIRETOESIIGEDHN"。 
//
// 请你实现这个将字符串进行指定行数变换的函数： 
//
// string convert(string s, int numRows); 
//
// 示例 1: 
//
// 输入: s = "LEETCODEISHIRING", numRows = 3
//输出: "LCIRETOESIIGEDHN"
// 
//
// 示例 2: 
//
// 输入: s = "LEETCODEISHIRING", numRows = 4
//输出: "LDREOEIIECIHNTSG"
//解释:
//
//L     D     R
//E   O E   I I
//E C   I H   N
//T     S     G 
// Related Topics 字符串 
// 👍 888 👎 0

//leetcode submit region begin(Prohibit modification and deletion)
using System;
using System.Collections.Generic;
using System.Text;

public partial class Solution {
    public string Convert(string s, int numRows)
    {
        if (numRows < 2)
        {
            return s;
        }
        var list = new List<StringBuilder>();
        for (var i = 0; i < numRows; i++)
        {
            list.Add(new StringBuilder());
        }
        var charArr = s.ToCharArray();
        var col = 0;
        var row = 0;
        foreach (var nowChar in charArr)
        {
            list[row].Append(nowChar);
                
            //是否满列
            var isFullCol = ((col % (numRows - 1)) == 0);
            if (isFullCol && row < (numRows - 1))
            {
                //满列非最后一个，直接下移一行
                row++;
                continue;
            }
            //否则，直接
            row--;
            col++;
        }

        var sb = new StringBuilder();
        foreach (var sbItem in list)
        {
            sb.Append(sbItem.ToString());
        }

        return sb.ToString();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
