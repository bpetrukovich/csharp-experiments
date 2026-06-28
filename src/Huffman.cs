using System.Diagnostics;

namespace Template;

public class TreeNode(char? value, TreeNode? left = null, TreeNode? right = null)
{
    public TreeNode? Left { get; set; } = left;

    public TreeNode? Right { get; set; } = right;

    public char? Value { get; } = value;
}

public class Huffman
{
    private Dictionary<char, string> Table { get; }

    private TreeNode Root { get; }

    private string Message { get; }

    public string Code { get; private set; }

    public Huffman(string message)
    {
        Message = message;
        Root = BuildTree(Message);
        Table = BuildTable(Root);
        Code = Encode();
    }

    public string Decode(string code)
    {
        var message = "";
        TreeNode node = Root;

        Debug.Assert(node is not null);

        foreach (var c in code)
        {
            Debug.Assert(c == '0' || c == '1');

            if (c == '0')
            {
                node = node.Left!;
                if (node.Value is not null)
                {
                    message += node.Value.Value;
                    node = Root;
                }
            }
            else
            {
                node = node.Right!;
                if (node.Value is not null)
                {
                    message += node.Value.Value;
                    node = Root;
                }
            }
        }

        return message;
    }

    private string Encode()
    {
        return string.Concat(Message.Select(c => Table[c]));
    }

    private static Dictionary<char, string> BuildTable(TreeNode root)
    {
        var table = new Dictionary<char, string>();

        DFS(root, table);

        return table;
    }

    private static void DFS(TreeNode node, Dictionary<char, string> table, string code = "")
    {
        if (node.Value is not null)
        {
            table.Add(node.Value.Value, code);
            return;
        }

        if (node.Left is not null)
        {
            DFS(node.Left, table, code + "0");
        }

        if (node.Right is not null)
        {
            DFS(node.Right, table, code + "1");
        }
    }

    private static TreeNode BuildTree(string message)
    {
        if (message.Length == 0)
        {
            throw new ArgumentException("The message is empty");
        }

        if (message.Length == 1)
        {
            return new TreeNode(null, new TreeNode(message.First()));
        }

        var node_count = message.GroupBy(c => c).ToDictionary((g) => new TreeNode(g.Key), g => g.Count());

        var queue = new PriorityQueue<TreeNode, int>();
        foreach (var (node, count) in node_count)
        {
            queue.Enqueue(node, count);
        }

        while (queue.Count > 1)
        {
            queue.TryDequeue(out TreeNode? a, out int aPriority);
            queue.TryDequeue(out TreeNode? b, out int bPriority);

            queue.Enqueue(new TreeNode(null, a, b), aPriority + bPriority);
        }

        return queue.Dequeue();
    }
}