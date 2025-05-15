using L4D2PlayStats.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace L4D2PlayStats.UnitTest.Extensions;

[TestClass]
public class LongExtensionsTests
{
    [TestMethod]
    public void ToDateTime_NegativeValue_ReturnsNull()
    {
        const long value = -1;

        var result = value.ToDateTime();

        Assert.IsNull(result);
    }

    [TestMethod]
    public void ToDateTime_ZeroValue_ReturnsNull()
    {
        const long value = 0;

        var result = value.ToDateTime();

        Assert.IsNull(result);
    }

    [TestMethod]
    public void ToDateTime_ValidValue_ReturnsCorrectDateTime()
    {
        const long value = 1696166400;

        var expectedDateTime = new DateTime(2023, 10, 1, 13, 20, 0, DateTimeKind.Utc);

        var result = value.ToDateTime();

        Assert.AreEqual(expectedDateTime, result);
    }
}