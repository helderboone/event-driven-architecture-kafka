using EDA.Core;

namespace EDA.Pedidos.API.Messages
{
    [MessageTopic("sample-messages")]
    public class SampleMessage : IMessage
    {
        public SampleMessage(string key, string someProperty)
        {
            Key = key;
            SomeProperty = someProperty;
        }

        public string Key { get; }

        public string SomeProperty { get; }
    }
}