using L4D2PlayStats.Enums;

namespace L4D2PlayStats.Extensions;

public static class InfectedStatsExtensions
{
    public static DataType DataType(this InfectedStats infectedStats)
    {
        return infectedStats switch
        {
            InfectedStats.TimeStartPresent
                or InfectedStats.TimeStopPresent
                => Enums.DataType.DateTime,
            _ => Enums.DataType.Number
        };
    }
}