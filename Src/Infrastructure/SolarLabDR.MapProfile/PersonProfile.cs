using AutoMapper;
using SolarLabDR.Contracts.Person;
using SolarLabDR.Domain;

namespace SolarLabDR.MapProfile
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>(MemberList.None).ReverseMap(); ;
        }
    }
}
