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
public abstract class CustomValidationAttribute<T> : CustomValidationAttribute
{
    public abstract bool Validate(T value);

    public sealed override bool Validate(object? value)
    {
        if (value is null)
        {
            return true;
        }

        return value is T typed ? Validate(typed) : false;
    }
}

public abstract class CustomValidationAttribute : Attribute
{
    public abstract bool Validate(object? value);
}