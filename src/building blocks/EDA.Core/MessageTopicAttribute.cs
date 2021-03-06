using System;

namespace EDA.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageTopicAttribute : Attribute
    {
        public MessageTopicAttribute(string topic)
        {
            Topic = topic;
        }

        public string Topic { get; }
    }
}