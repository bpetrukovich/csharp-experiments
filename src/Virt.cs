namespace Template;

class A { public virtual void Show() => Console.WriteLine("Method A"); }
class B : A { public void Show() => Console.WriteLine("Method B"); }

class Some
{
    public int Number { get; set; }

    public static void Calculate(int number)
    {
        var some = new Some();

        var a = new A();
        A b = new B();

        Console.WriteLine(some.GetType().TypeHandle);
    }
}