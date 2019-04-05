namespace Infrastructure.Adapters.Roi
{
    using System.Linq;

    using global::Roi.Domain.UserAggregate;

    using Infrastructure.Repositories;
    using Infrastructure.Repositories.Entities;
    using Infrastructure.Specifications;
    using Infrastructure.Transforms.Core;

    internal class UserInformationAdapter : IUserInformationAdapter
    {
        private readonly IReader<Person> peopleReader;

        private readonly ITranform<Person, UserInformation> toDomainTranform;

        private readonly IUserInformationSpecification userInformationSpecification;

        public UserInformationAdapter(
            IReader<Person> peopleReader,
            IUserInformationSpecification userInformationSpecification,
            ITranform<Person, UserInformation> toDomainTranform)
        {
            this.peopleReader = peopleReader;
            this.userInformationSpecification = userInformationSpecification;
            this.toDomainTranform = toDomainTranform;
        }

        public UserInformation Get(int id)
        {
            var peopleQuery = this.peopleReader
                                  .Get(
                                      Queryable.Where,
                                      a => a.BusinessEntityId == id,
                                      this.userInformationSpecification).Select(this.toDomainTranform.Projection);
            var userInformation =
                peopleQuery.Value<UserInformation, NotFoundUserInformation>(id, Queryable.SingleOrDefault);

            return userInformation;
        }
    }
}