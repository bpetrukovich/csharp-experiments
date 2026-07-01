using System.Collections;
using System.Diagnostics;

namespace Template;

public class ArrayListBoxing
{
    public ArrayListBoxing()
    {
        var num = 5000000;

        var a = new ArrayList();

        var sw = Stopwatch.StartNew();

        for (var i = 0; i < num; i++)
        {
            a.Add(i);
        }

        sw.Stop();

        Console.WriteLine("ArrayList: " + sw.ElapsedMilliseconds);

        var list = new List<int>();

        sw.Restart();

        for (var i = 0; i < num; i++)
        {
            list.Add(i);
        }

        sw.Stop();

        Console.WriteLine("List: " + sw.ElapsedMilliseconds);
    }
}