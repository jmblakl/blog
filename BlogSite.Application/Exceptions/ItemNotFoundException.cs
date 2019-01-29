using System;

namespace BlogSite.Application.Exceptions
{
    public sealed class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string itemName, Exception inner)
            : base($"Item type: {itemName} is not found", inner)
        {

        }
        public ItemNotFoundException(string itemName)
            : base($"Item type: {itemName} is not found")
        {

        }
    }
}
