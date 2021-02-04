//罗马数字包含以下七种字符: I， V， X， L，C，D 和 M。
//
// 字符          数值
//I             1
//V             5
//X             10
//L             50
//C             100
//D             500
//M             1000
//
// 例如， 罗马数字 2 写做 II ，即为两个并列的 1。12 写做 XII ，即为 X + II 。 27 写做 XXVII, 即为 XX + V + I
//I 。
//
// 通常情况下，罗马数字中小的数字在大的数字的右边。但也存在特例，例如 4 不写做 IIII，而是 IV。数字 1 在数字 5 的左边，所表示的数等于大数 5
// 减小数 1 得到的数值 4 。同样地，数字 9 表示为 IX。这个特殊的规则只适用于以下六种情况：
//
//
// I 可以放在 V (5) 和 X (10) 的左边，来表示 4 和 9。
// X 可以放在 L (50) 和 C (100) 的左边，来表示 40 和 90。
// C 可以放在 D (500) 和 M (1000) 的左边，来表示 400 和 900。
//
//
// 给定一个罗马数字，将其转换成整数。输入确保在 1 到 3999 的范围内。
//
//
//
// 示例 1:
//
// 输入: "III"
//输出: 3
//
// 示例 2:
//
// 输入: "IV"
//输出: 4
//
// 示例 3:
//
// 输入: "IX"
//输出: 9
//
// 示例 4:
//
// 输入: "LVIII"
//输出: 58
//解释: L = 50, V= 5, III = 3.
//
//
// 示例 5:
//
// 输入: "MCMXCIV"
//输出: 1994
//解释: M = 1000, CM = 900, XC = 90, IV = 4.
//
//
//
// 提示：
//
//
// 题目所给测试用例皆符合罗马数字书写规则，不会出现跨位等情况。
// IC 和 IM 这样的例子并不符合题目要求，49 应该写作 XLIX，999 应该写作 CMXCIX 。
// 关于罗马数字的详尽书写规则，可以参考 罗马数字 - Mathematics 。
//
// Related Topics 数学 字符串
// 👍 1104 👎 0


//leetcode submit region begin(Prohibit modification and deletion)

using System.Collections.Generic;

public partial class Solution {
private static Dictionary<string, int> _oneDic = new Dictionary<string, int>()
        {
            {"I",1},
            {"V",5},
            {"X",10},
            {"L",50},
            {"C",100},
            {"D",500},
            {"M",1000},

        };

        private static Dictionary<string, int> _twoDic = new Dictionary<string, int>()
        {
            {"IV", 4},
            {"IX", 9},
            {"XL", 40},
            {"XC", 90},
            {"CD", 400},
            {"CM", 900}
        };
    public int RomanToInt(string s) {
// int res = 0;
//             foreach (var keyValuePair in _twoDic)
//             {
//                 while (s.IndexOf(keyValuePair.Key)>-1)
//                 {
//                     int index = s.IndexOf(keyValuePair.Key);
//                     res += keyValuePair.Value;
//                     s = s.Substring(0, index) +"@"+ s.Substring(index + keyValuePair.Key.Length);
//                 }
//             }
//             foreach (var keyValuePair in _oneDic)
//             {
//                 while (s.IndexOf(keyValuePair.Key)>-1)
//                 {
//                     int index = s.IndexOf(keyValuePair.Key);
//                     res += keyValuePair.Value;
//                     s = s.Substring(0, index) +"@"+ s.Substring(index + keyValuePair.Key.Length);
//                 }
//             }

//             return res;

			int res = 0;
            for (int i = 0; i < s.Length;)
            {
                //查看是否是连续的特殊字符串
                if (i < s.Length - 1 && _twoDic.ContainsKey(s.Substring(i, 2)))
                {
                    res += _twoDic[s.Substring(i, 2)];
                    i = i + 2;
                }
                else
                {
                    res += _oneDic[s.Substring(i, 1)];
                    i = i + 1;
                }
            }

            return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
