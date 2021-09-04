using System.Collections.Generic;
using Abstractions.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
