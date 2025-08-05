using AutoMapper;
using SolarLabDR.Contracts.Image;
using SolarLabDR.Contracts.Person;
using SolarLabDR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLabDR.MapProfile
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDto>(MemberList.None).ReverseMap(); ;
        }
    }
}
