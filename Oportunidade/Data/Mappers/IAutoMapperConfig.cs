using AutoMapper;

namespace Data.Mappers
{
    public interface IAutoMapperConfig
    {
        void RegisterMappings();
        IMapper Mapper { get; set; }
    }
}
