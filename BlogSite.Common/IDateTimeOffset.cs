using System;

namespace BlogSite.Common
{
    public interface IDateTimeOffset
    {
        DateTimeOffset Now { get; }
        DateTimeOffset UtcNow { get; }
    }
}
