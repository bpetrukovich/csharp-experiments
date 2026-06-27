namespace Template.Tests;

public class SortTestData : TheoryData<int[], int[]>
{
    public SortTestData()
    {
        List<int[]> lists = [
            [],
            [1],
            [1, 2, 3, 4, 5],
            [5, 4, 3, 2, 1],
            [3, 3, 3, 3, 3],
            [4, 1, 2, 4, 5],
            [3, 5, 1, 2, 4],
        ];

        AddRange(lists.Select(list => (list, list.Order().ToArray())));
    }
}
