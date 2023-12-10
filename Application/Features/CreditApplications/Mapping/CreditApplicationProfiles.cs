using Application.Features.CreditApplications.Commands.Create;
using Application.Features.CreditApplications.Queries.GetById;
using Application.Features.CreditApplications.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.CreditApplications.Mapping;

public class CreditApplicationProfiles : Profile
{
    public CreditApplicationProfiles()
    {
        CreateMap<CreditApplication, CreateCreditApplicationCommand>().ReverseMap();
        CreateMap<CreditApplication, CreateCreditApplicationResponse>().ReverseMap();
        CreateMap<CreditApplication, GetCreditApplicationListResponse>().ReverseMap();
        CreateMap<CreditApplication, GetCreditApplicationByIdResponse>().ReverseMap();
    }
}
