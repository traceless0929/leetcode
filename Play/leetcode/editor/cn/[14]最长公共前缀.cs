//编写一个函数来查找字符串数组中的最长公共前缀。 
//
// 如果不存在公共前缀，返回空字符串 ""。 
//
// 示例 1: 
//
// 输入: ["flower","flow","flight"]
//输出: "fl"
// 
//
// 示例 2: 
//
// 输入: ["dog","racecar","car"]
//输出: ""
//解释: 输入不存在公共前缀。
// 
//
// 说明: 
//
// 所有输入只包含小写字母 a-z 。 
// Related Topics 字符串 
// 👍 1330 👎 0


//leetcode submit region begin(Prohibit modification and deletion)

using System;

public partial class Solution {
    public string LongestCommonPrefix(string[] strs) {
			if(strs==null || strs.Length==0)return "";
            Array.Sort(strs,string.CompareOrdinal);
            string s1=strs[0];
            string s2=strs[strs.Length-1];
            int maxIndex=s1.Length<=s2.Length?s1.Length:s2.Length;
            for(int i=0;i<maxIndex;i++){
                if(s1[i]!=s2[i]){
                    s1=s1.Substring(0,i);
                    break;
                }                   
            }
            return s1;
    }
}
//leetcode submit region end(Prohibit modification and deletion)