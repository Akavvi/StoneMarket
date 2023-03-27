using Domain.Entities;
using Mapster;

namespace Application;

public class Mapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<BaseEntity<long>, long>()
            .MapWith(entity => entity.Id);
        
        config.NewConfig<Enum, string>()
            .MapWith(enumeration => enumeration.ToString().ToUpper());
    }
}