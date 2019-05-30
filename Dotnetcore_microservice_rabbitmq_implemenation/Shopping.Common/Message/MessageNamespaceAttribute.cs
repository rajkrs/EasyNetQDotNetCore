using Shopping.Common.Enums;
using System;

namespace Shopping.Common.Message
{
    /// <summary>
    /// Act as Topic to create routing key.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageForwardedToAttribute : Attribute
    {
        public string Service { get; }

        public MessageForwardedToAttribute(Service services)
        {
            Service = services.ToString()?.ToLowerInvariant();
        }
    }
}
