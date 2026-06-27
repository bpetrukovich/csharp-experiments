namespace Template;

public class RecursiveSum
{
    public static int Sum(List<int> nums)
    {
        if (nums.Count == 0)
        {
            return 0;
        }

        if (nums.Count == 1)
        {
            return nums[0];
        }

        return nums[0] + Sum(nums[1..]);
    }
}
