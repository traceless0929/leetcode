//给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串 s ，判断字符串是否有效。 
//
// 有效字符串需满足： 
//
// 
// 左括号必须用相同类型的右括号闭合。 
// 左括号必须以正确的顺序闭合。 
// 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "()"
//输出：true
// 
//
// 示例 2： 
//
// 
//输入：s = "()[]{}"
//输出：true
// 
//
// 示例 3： 
//
// 
//输入：s = "(]"
//输出：false
// 
//
// 示例 4： 
//
// 
//输入：s = "([)]"
//输出：false
// 
//
// 示例 5： 
//
// 
//输入：s = "{[]}"
//输出：true 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 104 
// s 仅由括号 '()[]{}' 组成 
// 
// Related Topics 栈 字符串 
// 👍 2133 👎 0


//leetcode submit region begin(Prohibit modification and deletion)

using System;
using System.Collections.Generic;
using System.Linq;

public partial class Solution
{
    private char[] left = new[] {'(', '[', '{'};
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<Char>();
        foreach (var c in s.ToCharArray())
        {
            bool isLeft = left.Contains(c);
            //左边 入栈
            if (isLeft)
            {
                stack.Push(c);
                continue;
            }
            if (stack.Count > 0)
            {
                char pop = stack.Pop();
                switch (pop)
                {
                    case '(':
                        if (c != ')')
                        {
                            return false;
                        }
                        break;
                    case '[':
                        if (c != ']')
                        {
                            return false;
                        }
                        break;
                    case '{':
                        if (c != '}')
                        {
                            return false;
                        }
                        break;
                }
            }
            //右边
            else
            {
                return false;
            }
        }

        if (stack.Count > 0)
        {
            return false;
        }
        return true;
    }

    
}
//leetcode submit region end(Prohibit modification and deletion)
