using System;
using System.Runtime.Serialization;

namespace InsureMe
{
    [DataContract]
    public class BasePremium
    {
        [DataMember]
        public string age;

        [DataMember]
        public int premium;
    }
}
