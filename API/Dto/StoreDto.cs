using System.Runtime.Serialization;

namespace API.Dto
{
    [DataContract]
    public class StoreDto
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Info { get; set; }
        [DataMember]
        public int DistrictID { get; set; }

    }
}
