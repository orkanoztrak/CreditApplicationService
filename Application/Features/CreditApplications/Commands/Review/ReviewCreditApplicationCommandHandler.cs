using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Core;
using Domain.Entities;
using MediatR;

namespace Application.Features.CreditApplications.Commands.Review;

public class ReviewCreditApplicationCommandHandler : IRequestHandler<ReviewCreditApplicationCommand, ReviewCreditApplicationResponse>
{
    private readonly CreditApplicationRepository creditApplicationRepository;

    public ReviewCreditApplicationCommandHandler(CreditApplicationRepository creditApplicationRepository)
    {
        this.creditApplicationRepository = creditApplicationRepository;
    }

    public async Task<ReviewCreditApplicationResponse> Handle(ReviewCreditApplicationCommand request, CancellationToken cancellationToken)
    {
        CreditApplication? result = await creditApplicationRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken : cancellationToken);
        creditApplicationRepository.Retrieve(result);
        if (result is null)
        {
            return new ReviewCreditApplicationResponse
            {
                Success = false
            };
        }
        if (result.Status != CreditApplicationStatus.Pending)
        {
            return new ReviewCreditApplicationResponse
            {
                Success = false
            };
        }
        if (request.Approved)
        {
            result.Status = CreditApplicationStatus.Success;
            result.StatusMessage = ApplicationStatusMessage.CreditApplicationResultValid;
            result.LinkedCustomer.Debt = result.Amount * (100 + result.Interest) / 100;
        }
        else
        {
            result  .StatusMessage = ApplicationStatusMessage.CreditApplicationResultManuallyRejected;
            result.Status = CreditApplicationStatus.Fail;
        }
        await creditApplicationRepository.UpdateAsync(result);
        return new ReviewCreditApplicationResponse
        {
            Success = true
        };
    }
}
