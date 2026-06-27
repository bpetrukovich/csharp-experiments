namespace Template;

public class RecursiveBinarySearch
{
    public static int? OrdinaryBinarySearch(List<int> nums, int num)
    {
        int left = 0;
        int right = nums.Count - 1;

        int middle;
        while (left <= right)
        {
            middle = left + (right - left) / 2;
            if (num < nums[middle])
            {
                right = middle - 1;
            }
            else if (num > nums[middle])
            {
                left = middle + 1;
            }
            else
            {
                return middle;
            }
        }

        return null;
    }

    public static int? BinarySearch(List<int> nums, int num)
    {
        return BinarySearch(nums, num, 0, nums.Count - 1);
    }

    private static int? BinarySearch(List<int> nums, int num, int left, int right)
    {
        if (left > right)
        {
            return null;
        }

        var middle = left + (right - left) / 2;

        if (num < nums[middle])
        {
            return BinarySearch(nums, num, left, middle - 1);
        }
        else if (num > nums[middle])
        {
            return BinarySearch(nums, num, middle + 1, right);
        }
        else
        {
            return middle;
        }
    }
}
