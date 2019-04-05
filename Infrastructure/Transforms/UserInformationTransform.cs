using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Transforms
{
    using System.Linq.Expressions;

    using Infrastructure.Repositories.Entities;
    using Infrastructure.Transforms.Core;

    using Roi.Domain.UserAggregate;

    internal class UserInformationTransform : TranformBase<Person, UserInformation>
    {
        public override Expression<Func<Person, UserInformation>> Projection =>
            person => new UserInformation
                            {
                                GivenName = person.FirstName,
                                Emails = person.EmailAddresses.Select(email => email.EmailAddress1).ToList(),
                                Id = person.BusinessEntityId,
                                Name = person.LastName
                            };
    }
}
