namespace Template.Tests;

public class HuffmanTests
{
    [Theory]
    [MemberData(nameof(GetHuffmanTestMessages))]
    public void Haffman_DecodedShouldBeEqualToInitialMessage(string message)
    {
        var huffman = new Huffman(message);

        var encoded = huffman.Code;

        var decoded = huffman.Decode(encoded);

        Assert.Equal(message, decoded);
    }

    [Theory]
    [MemberData(nameof(GetHuffmanTestData))]
    public void HaffmanTest(string message, string expectedEncoded)
    {
        var huffman = new Huffman(message);

        var encoded = huffman.Code;

        Assert.Equal(expectedEncoded, encoded);
    }

    public static IEnumerable<TheoryDataRow<string>> GetHuffmanTestMessages()
    {
        yield return "A";
        yield return "Hello";
        yield return "HeLlo world";
        yield return "The world is yours";
    }

    public static IEnumerable<TheoryDataRow<string, string>> GetHuffmanTestData()
    {
        yield return ("A", "0");
    }
}