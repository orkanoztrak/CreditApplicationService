using Application.Features.CreditApplications.Queries.GetList;
using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CreditApplications.Queries.GetList;

public class GetCreditApplicationListQueryHandler : IRequestHandler<GetCreditApplicationListQuery, IList<GetCreditApplicationListResponse>>
{
    private readonly IMapper mapper;
    private readonly CreditApplicationRepository creditApplicationRepository;

    public GetCreditApplicationListQueryHandler(IMapper mapper, CreditApplicationRepository creditApplicationRepository)
    {
        this.mapper = mapper;
        this.creditApplicationRepository = creditApplicationRepository;
    }

    public async Task<IList<GetCreditApplicationListResponse>> Handle (GetCreditApplicationListQuery request, CancellationToken cancellationToken)
    {
        IList<CreditApplication>? result = await creditApplicationRepository.GetAllAsync(cancellationToken : cancellationToken);
        if (result is null)
        {
            throw new ArgumentNullException(nameof(result));
        }
        IList<GetCreditApplicationListResponse> response = mapper.Map<IList<GetCreditApplicationListResponse>>(result);
        return response;
    }
}