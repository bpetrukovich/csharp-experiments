namespace Template.Tests;

public class RecursiveSumTests
{
    [Theory]
    [MemberData(nameof(GetRecursionSumTestData))]
    public void SortTest(List<int> nums, int expected)
    {
        var result = RecursiveSum.Sum(nums);

        Assert.Equal(expected, result);
    }

    public static IEnumerable<TheoryDataRow<List<int>, int>> GetRecursionSumTestData()
    {
        yield return ([1, 2, 3], 6);
        yield return ([], 0);
        yield return ([10], 10);
    }
}
