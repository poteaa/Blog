using AutoMapper;
using System.Collections.Generic;

namespace Helper
{
    public class MapperConfig<TSource, TDestination>
    {
        public static TDestination Map(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<TSource, TDestination>(source);
        }

        public static IEnumerable<TDestination> MapIEnumerable(IEnumerable<TSource> source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }
    }
}
