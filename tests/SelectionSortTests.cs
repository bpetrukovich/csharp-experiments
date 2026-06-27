namespace Template.Tests;

public class SelectionSortTests
{
    [Theory]
    [MemberData(nameof(GetSortTestData))]
    public void SortTest(List<int> arr, List<int> expected)
    {
        var result = SelectionSort.Sort(arr);

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(GetFindMaxIndexTestData))]
    public void FindMaxIndexTest(List<int> arr, int start, int expected)
    {
        var result = SelectionSort.FindMinIndex(arr, start);

        Assert.Equal(expected, result);
    }

    public static IEnumerable<TheoryDataRow<List<int>, List<int>>> GetSortTestData()
    {
        yield return ([1, 2, 3], [1, 2, 3]);
        yield return ([3, 2, 1], [1, 2, 3]);
        yield return ([9, 3, 2, 1, 4, 5, 6, 7, 8, 0], [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]);
    }

    public static IEnumerable<TheoryDataRow<List<int>, int, int>> GetFindMaxIndexTestData()
    {
        yield return ([1, 2, 3], 0, 0);
        yield return ([3, 2, 1], 0, 2);
        yield return ([1, 2, 3], 1, 1);
        yield return ([3, 2, 1], 1, 2);
    }
}
