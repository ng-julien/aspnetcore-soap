namespace WebService.Core
{
    using AutoMapper;

    using Roi.Domain.Commons.Models;

    internal static class MapperExtensions
    {
        public static TDestination Map<TDestination, TNotFoundDestination>(this IMapper mapper, object source)
            where TNotFoundDestination : TDestination
        {
            if (source is INotFound)
            {
                return mapper.Map<TNotFoundDestination>(source);
            }

            return mapper.Map<TDestination>(source);
        }
    }
}