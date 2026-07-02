namespace Template.Tests;

public class AttributesTests
{
    public record Person([property: MaxLength(10)][property: AlphabetOnly] string? Name);

    [Theory]
    [MemberData(nameof(GetTestStrings))]
    public void CustomAttrubitesTests(string? message, bool expected)
    {
        var person = new Person(message);

        var res = Validator.Validate(person);

        Assert.Equal(expected, res);
    }

    public static IEnumerable<TheoryDataRow<string?, bool>> GetTestStrings()
    {
        yield return ("The world is yours", false);
        yield return ("The world ", true);
        yield return ("The world1", false);
        yield return ("The world i", false);
        yield return ("", true);
        yield return (null, true);
    }
}