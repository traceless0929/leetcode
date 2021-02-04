//给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。 
//
// 你可以假设每种输入只会对应一个答案。但是，数组中同一个元素不能使用两遍。 
//
// 
//
// 示例: 
//
// 给定 nums = [2, 7, 11, 15], target = 9
//
//因为 nums[0] + nums[1] = 2 + 7 = 9
//所以返回 [0, 1]
// 
// Related Topics 数组 哈希表 
// 👍 9522 👎 0


//leetcode submit region begin(Prohibit modification and deletion)
public partial class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] res = new int[2];
        int i = 0;
        foreach (var nowItem in nums)
        {
            //最后一位不用遍历，后面没有数了
            if (i == nums.Length)
            {
                return res;
            }
            //剩余值
            int remain = target - nowItem;
            //从下一个下标开始遍历，到末尾结束
            for (int nowIndex = i + 1; nowIndex < nums.Length; nowIndex++)
            {
                if (nums[nowIndex] == remain)
                {
                    //找到了，赋值下标
                    res[0] = i;
                    res[1] = nowIndex;
                    return res;
                }
            }
            i++;
        }
        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
