namespace L4D2PlayStats.Extensions;

public static class LongExtensions
{
	public static DateTime? ToDateTime(this long value)
	{
		if (value <= 0)
			return null;

		var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		return dateTime.AddMilliseconds(value * 1000);
	}
}