namespace Template.Tests;

public class SelectionSortTests
{
    [Theory]
    [ClassData(typeof(SortTestData))]
    public void SortTest(int[] arr, int[] expected)
    {
        var result = SelectionSort.Sort(arr.ToList());

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(GetFindMaxIndexTestData))]
    public void FindMaxIndexTest(List<int> arr, int start, int expected)
    {
        var result = SelectionSort.FindMinIndex(arr, start);

        Assert.Equal(expected, result);
    }

    public static IEnumerable<TheoryDataRow<List<int>, int, int>> GetFindMaxIndexTestData()
    {
        yield return ([1, 2, 3], 0, 0);
        yield return ([3, 2, 1], 0, 2);
        yield return ([1, 2, 3], 1, 1);
        yield return ([3, 2, 1], 1, 2);
    }
}
