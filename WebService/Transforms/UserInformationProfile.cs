namespace WebService.Transforms
{
    using AutoMapper;

    using Roi.Domain.UserAggregate;

    public class UserInformationProfile : Profile
    {
        public UserInformationProfile()
        {
            this.CreateMap<UserInformation, Models.UserInformation>();
        }
    }
}