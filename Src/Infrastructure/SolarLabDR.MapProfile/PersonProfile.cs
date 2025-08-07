using AutoMapper;
using SolarLabDR.Contracts.Image;
using SolarLabDR.Contracts.Person;
using SolarLabDR.Domain;

namespace SolarLabDR.MapProfile
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>(MemberList.None).ReverseMap();
            CreateMap<PersonRequest, PersonDto>(MemberList.None);
            CreateMap<PersonDto, PersonResponse>(MemberList.None);
        }
    }
}
