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
public partial class Solution
{
    public int LengthOfLongestSubstring_1(string s)
    {
        string nowStr = "";
        int maxRes = 0;
        //遍历字符
        for (int startIndex = 0; startIndex < s.Length; startIndex++)
        {
            int lengthMax = s.Length - startIndex;
            //遍历每个char开头的所有长度的字符串
            for (int i = 1; i <= lengthMax; i++)
            {
                //小于当前最长的可以不遍历
                if (i <= maxRes)
                {
                    continue;
                }
                //当前字符串
                nowStr = s.Substring(startIndex, i);
                bool repeat = isRepeat(nowStr);
                if (!repeat)
                {
                    //没有重复，记录长度
                    maxRes = nowStr.Length;
                }

            }
        }
        return maxRes;
    }

    public bool isRepeat(string s)
    {
        //计算字符串中所有字符的索引，第一个索引和最后一个索引值不一样表示有重复
        foreach (var item in s)
        {
            int fstIndex = s.IndexOf(item);
            int lastIndex = s.LastIndexOf(item);
            if (fstIndex != lastIndex)
            {
                return true;
            }
        }
        return false;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
