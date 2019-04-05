namespace WebService.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserInformation
    {
        [DataMember]
        public string GivenName { get; set; }
    }
}