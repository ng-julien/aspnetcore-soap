namespace WebService.Endpoints
{
    using System.ServiceModel;

    using AutoMapper;

    using Roi.Application.Queries;

    using WebService.Models;

    [ServiceContract]
    public interface IRoiService
    {
        [OperationContract]
        UserInformation GetUserById(int id);
    }

    public class RoiService : IRoiService
    {
        private readonly IGetUserInformationByIdQuery getUserInformationByIdQuery;

        private readonly IMapper mapper;

        public RoiService(IMapper mapper, IGetUserInformationByIdQuery getUserInformationByIdQuery)
        {
            this.mapper = mapper;
            this.getUserInformationByIdQuery = getUserInformationByIdQuery;
        }

        public UserInformation GetUserById(int id)
        {
            var userInformation = this.getUserInformationByIdQuery.Get(id);
            return this.mapper.Map<UserInformation>(userInformation);
        }
    }
}