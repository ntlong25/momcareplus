namespace MomCarePlus.Domain.Extensions;

public static class DateTimeExtensions
{
    public static DateTime ToUtc(this DateTime dateTime)
    {
        if (dateTime.Kind == DateTimeKind.Unspecified)
        {
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }
        return dateTime.ToUniversalTime();
    }
} 