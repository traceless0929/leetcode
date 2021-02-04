//给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。 
//
// 示例 1： 
//
// 输入: "babad"
//输出: "bab"
//注意: "aba" 也是一个有效答案。
// 
//
// 示例 2： 
//
// 输入: "cbbd"
//输出: "bb"
// 
// Related Topics 字符串 动态规划 
// 👍 2866 👎 0


//leetcode submit region begin(Prohibit modification and deletion)
public partial class Solution
{
  //思路
  //回文 可能是aba形式【奇数】 也有可能是abba形式【偶数】
  public string LongestPalindrome(string s)
  {
    //记录最大长度
    int nowMax = 0;
    //记录最大字符串
    string nowStr = "";
    for (int i = 0; i < s.Length; i++)
    {
      //奇数回文查找
      string singleStr = findSignlePalind(s, i, nowMax);
      if (singleStr.Length > nowMax)
      {
        nowMax = singleStr.Length;
        nowStr = singleStr;
      }
      //偶数回文查找
      string doubleStr = findDoublePalind(s, i, nowMax);
      if (doubleStr.Length > nowMax)
      {
        nowMax = doubleStr.Length;
        nowStr = doubleStr;
      }
    }
    return nowStr;
  }


  ///<summary>
  /// 查找字符串中的奇数回文字符串
  /// </summary>
  /// <param name="rawStr">原始字符串</param>
  /// <param name="index">当前轴索引</param>
  /// <param name="nowMax">当前最大长度</param>
  public string findSignlePalind(string rawStr, int index, int nowMax)
  {
    //处理"a"这种单个字符的字符串，也是回文
    if (rawStr.Length < 2) return rawStr;
    //最后偏移量
    var finalOffset = 0;
    //转char数组，比每次substring效率高
    var charArr = rawStr.ToCharArray();
    for (var offset = 1; ; offset++)
    {
      //数组越界检查
      if (index - offset < 0 || index + offset >= rawStr.Length) break;
      //对称轴左字符
      var leftChar = charArr[index - offset];
      //对称轴右字符
      var rightChar = charArr[index + offset];
      if (leftChar == rightChar)
      {
        //相同，继续偏移
        finalOffset = offset;
        continue;
      }

      break;
    }
    //计算起始位置
    var left = index - finalOffset;
    //获取最终字符串
    return rawStr.Substring(left, finalOffset * 2 + 1);
  }

  public string findDoublePalind(string rawStr, int index, int nowMax)
  {
    //处理"a"这种单个字符的字符串，也是回文
    if (rawStr.Length < 2) return rawStr;
    //最后偏移量
    var finalOffset = 0;
    //转char数组，比每次substring效率高
    var charArr = rawStr.ToCharArray();
    //记录是否有结果
    var hasRes = false;
    for (var offset = 0; ; offset++)
    {
      //数组越界检查
      if (index - offset < 0 || index + offset + 1 >= rawStr.Length) break;
      //"abba"这种情况，把对称轴左边的字符当做对称轴
      //取左字符
      var leftChar = charArr[index - offset];
      //取右字符
      var rightChar = charArr[index + offset + 1];
      if (leftChar == rightChar)
      {
        //相同，继续偏移
        finalOffset = offset;
        hasRes = true;
        continue;
      }

      break;
    }

    if (!hasRes) return "";
    //计算起始位置
    var left = index - finalOffset;
    //获取最终字符串
    return rawStr.Substring(left, 2 * finalOffset + 2);
  }
}
//leetcode submit region end(Prohibit modification and deletion)
