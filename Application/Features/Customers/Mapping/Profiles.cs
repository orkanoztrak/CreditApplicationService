using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Queries.GetById;
using Application.Features.Customers.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Mapping;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
        CreateMap<Customer, CreateCustomerResponse>().ReverseMap();
        CreateMap<Customer, GetCustomerListResponse>().ReverseMap();
        CreateMap<Customer, GetCustomerByIdResponse>().ReverseMap();
    }
}
