using BlogSite.Common;
using System;

namespace BlogSite.Intrastructure
{
    public sealed class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
