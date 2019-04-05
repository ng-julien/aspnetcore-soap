namespace Roi.Application.Queries
{
    using Roi.Domain.UserAggregate;

    public interface IGetUserInformationByIdQuery
    {
        UserInformation Get(int id);
    }

    internal class GetUserInformationByIdQuery : IGetUserInformationByIdQuery
    {
        private readonly IUserInformationAdapter userInformationAdapter;

        public GetUserInformationByIdQuery(IUserInformationAdapter userInformationAdapter)
        {
            this.userInformationAdapter = userInformationAdapter;
        }

        public UserInformation Get(int id)
        {
            var userInformation = this.userInformationAdapter.Get(id);
            return userInformation;
        }
    }
}