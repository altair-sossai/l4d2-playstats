using System.Globalization;

namespace L4D2PlayStats.Extensions;

public static class QueueExtensions
{
	private static readonly CultureInfo CultureInfo = new("en-us");

	public static char DequeueAsChar(this Queue<string> queue)
	{
		return queue.Dequeue().First();
	}

	public static int DequeueAsInt(this Queue<string> queue)
	{
		return int.Parse(queue.Dequeue());
	}

	public static decimal DequeueAsDecimal(this Queue<string> queue)
	{
		return decimal.Parse(queue.Dequeue(), CultureInfo);
	}

	public static DateTime? DequeueAsDateTime(this Queue<string> queue)
	{
		return queue.DequeueAsLong().ToDateTime();
	}

	private static long DequeueAsLong(this Queue<string> queue)
	{
		return long.Parse(queue.Dequeue());
	}
}