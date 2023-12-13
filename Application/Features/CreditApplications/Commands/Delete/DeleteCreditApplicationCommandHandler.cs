using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CreditApplications.Commands.Delete;

public class DeleteCreditApplicationCommandHandler : IRequestHandler<DeleteCreditApplicationCommand, DeleteCreditApplicationResponse>
{
    private readonly CreditApplicationRepository creditApplicationRepository;

    public DeleteCreditApplicationCommandHandler(CreditApplicationRepository creditApplicationRepository)
    {
        this.creditApplicationRepository = creditApplicationRepository;
    }

    public async Task<DeleteCreditApplicationResponse> Handle(DeleteCreditApplicationCommand request, CancellationToken cancellationToken)
    {
        CreditApplication? result = await creditApplicationRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        if (result == null)
        {
            throw new ArgumentNullException(nameof(result));
        }
        await creditApplicationRepository.DeleteAsync(result);
        return new DeleteCreditApplicationResponse
        {
            Id = request.Id
        };
    } 
}
