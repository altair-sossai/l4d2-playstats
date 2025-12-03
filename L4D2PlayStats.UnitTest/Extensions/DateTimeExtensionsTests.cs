using L4D2PlayStats.Extensions;

namespace L4D2PlayStats.UnitTest.Extensions;

[TestClass]
public class DateTimeExtensionsTests
{
    [TestMethod]
    public void ToUnixTimeSeconds_NullDateTime_ReturnsZero()
    {
        DateTime? dateTime = null;

        var result = dateTime.ToUnixTimeSeconds();

        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void ToUnixTimeSeconds_ValidDateTime_ReturnsCorrectUnixTime()
    {
        const long expectedUnixTime = 1696166400;

        var dateTime = new DateTime(2023, 10, 1, 13, 20, 0, DateTimeKind.Utc);
        var result = dateTime.ToUnixTimeSeconds();

        Assert.AreEqual(expectedUnixTime, result);
    }
}