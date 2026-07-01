using System.Reflection;

namespace Template;

public class Attributes
{
    public Attributes()
    {
        var a = new Person("SomeLongName1");

        var res = Validator.Validate(a);
        Console.WriteLine(res);
    }
}

class Validator
{
    public static bool Validate<T>(T value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return value.GetType().GetProperties().All(property =>
            property.GetCustomAttributes().OfType<CustomValidationAttribute>().All(attr => attr.Validate(property.GetValue(value)))
        );
    }
}

public record Person([property: MaxLength(10)][property: AlphabetOnly] string Name);

public class MaxLengthAttribute(int maxLength) : CustomValidationAttribute<string>
{
    public int MaxLength { get; } = maxLength;

    public override bool Validate(string s)
    {
        return s.Length <= MaxLength;
    }
}

public class AlphabetOnlyAttribute : CustomValidationAttribute<string>
{
    public override bool Validate(string s)
    {
        return !"1234567890".Any(s.Contains);
    }
}

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public abstract class CustomValidationAttribute<T> : CustomValidationAttribute where T : class
{
    public abstract bool Validate(T value);

    public override bool Validate(object? value)
    {
        var typed = value as T;
        ArgumentNullException.ThrowIfNull(typed);

        return Validate(typed);
    }
}

public abstract class CustomValidationAttribute : Attribute
{
    public abstract bool Validate(object? value);
}