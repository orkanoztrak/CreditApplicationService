using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CreditApplications.Queries.GetById;

public class GetCreditApplicationByIdQueryHandler : IRequestHandler<GetCreditApplicationByIdQuery, GetCreditApplicationByIdResponse>
{
    private readonly IMapper mapper;
    private readonly CreditApplicationRepository creditApplicationRepository;

    public GetCreditApplicationByIdQueryHandler(IMapper mapper, CreditApplicationRepository creditApplicationRepository)
    {
        this.mapper = mapper;
        this.creditApplicationRepository = creditApplicationRepository;
    }

    public async Task<GetCreditApplicationByIdResponse> Handle(GetCreditApplicationByIdQuery request, CancellationToken cancellationToken)
    {
        CreditApplication? result = await creditApplicationRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        if (result is null)
        {
            throw new ArgumentNullException(nameof(result));
        }
        GetCreditApplicationByIdResponse getCreditApplicationByIdResponse = mapper.Map<GetCreditApplicationByIdResponse>(result);
        return getCreditApplicationByIdResponse;
    }
}
