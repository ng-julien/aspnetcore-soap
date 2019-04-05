namespace Roi.Domain.UserAggregate
{
    using System.Collections.Generic;

    public class UserInformation
    {
        public string GivenName { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public IList<string> Emails { get; set; }
    }
}