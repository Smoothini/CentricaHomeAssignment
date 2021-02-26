using System.Runtime.Serialization;

namespace DataLayer.Model
{
    [DataContract]
    public class SalesPerson
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
    }
}
