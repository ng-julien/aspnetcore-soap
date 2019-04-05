namespace Roi.Domain.UserAggregate
{
    public interface IUserInformationAdapter
    {
        UserInformation Get(int id);
    }
}