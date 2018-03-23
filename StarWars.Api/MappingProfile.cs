using AutoMapper;
using StarWars.Core.Models;
using Character = StarWars.Api.Models.Character;
using Droid = StarWars.Api.Models.Droid;
using Human = StarWars.Api.Models.Human;

namespace StarWars.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Character
            CreateMap<Core.Models.Character, Character>(MemberList.Destination)
                .ForMember(dest => dest.Friends, opt => opt.Ignore())
                .ForMember(dest => dest.AppearsIn, opt => opt.Ignore()
            );

            // Droid
            CreateMap<Core.Models.Droid, Droid>(MemberList.Destination).IncludeBase<Core.Models.Character, Character>();

            // Human
            CreateMap<Core.Models.Human, Human>(MemberList.Destination)
                .IncludeBase<Core.Models.Character, Character>()
                .ForMember(
                    dest => dest.HomePlanet,
                    opt => opt.MapFrom(src => src.HomePlanet.Name)
                );
            
            CreateMap<Human, Core.Models.Human>(MemberList.Destination)
                .IncludeBase<Character, Core.Models.Character>()
                .ForMember(
                    dest => dest.HomePlanet,
                    opt => opt.UseValue((Planet) null)
                );
        }
    }
}
