using System.Collections.Generic;
using Abstractions.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class ReportProfile:Profile
    {
        public ReportProfile()
        {
            CreateMap<Reports, ReportsDto>().ReverseMap();
        }
    }
}
