//给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。 
//
// 示例 1: 
//
// 输入: "abcabcbb"
//输出: 3 
//解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
// 
//
// 示例 2: 
//
// 输入: "bbbbb"
//输出: 1
//解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
// 
//
// 示例 3: 
//
// 输入: "pwwkew"
//输出: 3
//解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
//     请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
// 
// Related Topics 哈希表 双指针 字符串 Sliding Window 
// 👍 4538 👎 0


//leetcode submit region begin(Prohibit modification and deletion)
using System.Collections.Generic;
public partial class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        //特殊处理，空字符串直接返回
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }
        //非空字符串最小返回值也是1
        int maxRes = 1;
        //当前窗口
        List<char> nowWindow = new List<char>();
        foreach (var nowChar in s)
        {
            //遍历字符串的每个字符，窗口中存在，则抛弃前一个字符以前的所有
            //如 字符串abcb 当前abc 遇到第2个b 则窗口abc->c(去掉b及b以前的所有)
            if (nowWindow.Contains(nowChar))
            {
                nowWindow.RemoveRange(0, nowWindow.IndexOf(nowChar) + 1);
            }
            //再加上b到末尾成为窗口成为cb
            nowWindow.Add(nowChar);
            //当前窗口是否大于历史最大尺寸，大于则刷新纪录
            if (nowWindow.Count > maxRes)
            {
                maxRes = nowWindow.Count;
            }
        }
        return maxRes;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
