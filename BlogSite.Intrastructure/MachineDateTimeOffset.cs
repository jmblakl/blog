using BlogSite.Common;
using System;

namespace BlogSite.Intrastructure
{
    public sealed class MachineDateTimeOffset : IDateTimeOffset
    {
        public DateTimeOffset Now => DateTimeOffset.Now;

        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
