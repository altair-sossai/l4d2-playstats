namespace L4D2PlayStats.Extensions;

public static class StringExtensions
{
    private const char Separator = ';';
    private const StringSplitOptions Options = StringSplitOptions.TrimEntries;

    public static Queue<string> Queue(this string value, int? count = null)
    {
        var segments = count.HasValue
            ? value.Split(Separator, count.Value, Options)
            : value.Split(Separator, Options);

        return new Queue<string>(segments);
    }
}