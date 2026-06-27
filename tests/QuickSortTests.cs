namespace Template.Tests;

public class QuickSortTests
{
    [Theory]
    [ClassData(typeof(SortTestData))]
    public void SortTest(int[] arr, int[] expected)
    {
        var result = QuickSort.Sort(arr.ToList());

        Assert.Equal(expected, result);
    }
}