namespace Template.Selection;

public class SelectionSort
{
    public static List<int> Sort(List<int> a)
    {
        var arr = new List<int>(a);
        for (int i = 0; i < arr.Count; i++)
        {
            var index = FindMinIndex(arr, i);

            (arr[i], arr[index]) = (arr[index], arr[i]);
        }

        return arr;
    }

    internal static int FindMinIndex(List<int> arr, int start)
    {
        int minIndex = start;
        for (int i = start; i < arr.Count; i++)
        {
            var val = arr[i];
            var max = arr[minIndex];
            if (val < max)
            {
                minIndex = i;
            }
        }

        return minIndex;
    }
}
