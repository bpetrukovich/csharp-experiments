namespace Template.Tests;

public class RecursiveBinarySearchTests
{
    [Theory]
    [MemberData(nameof(BinarySearchTestData))]
    public void OrdinaryBinarySearchTest(List<int> nums, int num, int? expected)
    {
        var result = RecursiveBinarySearch.OrdinaryBinarySearch(nums, num);

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(BinarySearchTestData))]
    public void RecursiveBinarySearchTest(List<int> nums, int num, int? expected)
    {
        var result = RecursiveBinarySearch.BinarySearch(nums, num);

        Assert.Equal(expected, result);
    }

    public static IEnumerable<TheoryDataRow<List<int>, int, int?>> BinarySearchTestData()
    {
        yield return ([1, 2, 3, 4, 5, 6, 7, 8, 9], 1, 0);
        yield return ([1, 2, 3, 4, 5, 6, 7, 8, 9], 2, 1);
        yield return ([1, 2, 3, 4, 5, 6, 7, 8, 9], 3, 2);
        yield return ([1, 2, 3, 4, 5, 6, 7, 8, 9], 4, 3);
        yield return ([1, 2, 3, 4, 5, 6, 7, 8, 9], 5, 4);
        yield return ([1, 2, 3, 4, 5, 6, 7, 8, 9], 6, 5);
        yield return ([1, 2, 3, 4, 5, 6, 7, 8, 9], 7, 6);
        yield return ([1, 2, 3, 4, 5, 6, 7, 8, 9], 8, 7);
        yield return ([1, 2, 3, 4, 5, 6, 7, 8, 9], 9, 8);
        yield return ([1, 2, 3, 4, 5, 6, 7, 8, 9], 10, null);
        yield return ([1, 2, 3, 4, 5, 6, 7, 8, 9], 0, null);
        yield return ([], 1, null);
        yield return ([1], 1, 0);
    }
}
