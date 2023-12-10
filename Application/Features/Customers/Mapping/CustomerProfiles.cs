using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Queries.GetById;
using Application.Features.Customers.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Customers.Mapping;

public class CustomerProfiles : Profile
{
    public CustomerProfiles()
    {
        CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
        CreateMap<Customer, CreateCustomerResponse>().ReverseMap();
        CreateMap<Customer, GetCustomerListResponse>().ReverseMap();
        CreateMap<Customer, GetCustomerByIdResponse>().ReverseMap();
    }
}
