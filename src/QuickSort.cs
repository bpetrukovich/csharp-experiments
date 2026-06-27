namespace Template;

public class QuickSort
{
    public static List<int> Sort(List<int> nums)
    {
        if (nums.Count == 0)
        {
            return [];
        }

        if (nums.Count == 1)
        {
            return [nums.First()];
        }

        var x = nums[0];
        var lessOrEqualThanX = nums.Where((num, index) => num <= x && index != 0).ToList();
        var moreThanX = nums.Where((num) => num > x).ToList();

        return [.. Sort(lessOrEqualThanX), x, .. Sort(moreThanX)];
    }
}