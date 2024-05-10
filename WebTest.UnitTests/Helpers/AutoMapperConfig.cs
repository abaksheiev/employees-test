using AutoMapper;

namespace WebTest.UnitTests.Helpers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            return config.CreateMapper();
        }
    }

}
