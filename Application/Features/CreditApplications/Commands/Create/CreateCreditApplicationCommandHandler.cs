using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Core;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.CreditApplications.Commands.Create;

public class CreateCreditApplicationCommandHandler : IRequestHandler <CreateCreditApplicationCommand, CreateCreditApplicationResponse>
{
    private readonly IMapper mapper;
    private readonly CreditApplicationRepository creditApplicationRepository;

    public CreateCreditApplicationCommandHandler(IMapper mapper, CreditApplicationRepository creditApplicationRepository)
    {
        this.mapper = mapper;
        this.creditApplicationRepository = creditApplicationRepository;
    }

    public async Task<CreateCreditApplicationResponse> Handle(CreateCreditApplicationCommand request, CancellationToken cancellationToken)
    {
        CreditApplication result = await CreateAndReview(request);
        CreateCreditApplicationResponse createCreditApplicationResponse = mapper.Map<CreateCreditApplicationResponse>(result);
        return createCreditApplicationResponse;
    }

    private async Task<CreditApplication> CreateAndReview(CreateCreditApplicationCommand request)
    {
        CreditApplication application = mapper.Map<CreditApplication>(request);
        application.Id = Guid.NewGuid();
        await creditApplicationRepository.Attach(application);
        if (application.LinkedCustomer is null)
        {
            throw new ArgumentNullException(nameof(application.LinkedCustomer));
        }
        if (application.Amount > ApplicationCreationConstants.CreditAmountThreshold)
        {
            application.Status = CreditApplicationStatus.Fail;
            application.StatusMessage = ApplicationStatusMessage.CreditApplicationResultInvalidAmount;
            creditApplicationRepository.Save();
            return application;
        }
        if (application.InstallmentCount > ApplicationCreationConstants.CreditInstallmentCountThreshold)
        {
            application.Status = CreditApplicationStatus.Fail;
            application.StatusMessage = ApplicationStatusMessage.CreditApplicationResultInvalidInstallmentCount;
            creditApplicationRepository.Save();
            return application;
        }
        if (application.LinkedCustomer.Debt/application.LinkedCustomer.Salary > ApplicationCreationConstants.CustomerDebtSalaryRatioThreshold)
        {
            application.Status = CreditApplicationStatus.Fail;
            application.StatusMessage = ApplicationStatusMessage.CreditApplicationResultInvalidDebtToSalaryRatio;
            creditApplicationRepository.Save();
            return application;
        }
        if(application.LinkedCustomer.CreditScore < ApplicationCreationConstants.CreditScoreThreshold)
        {
            application.Status = CreditApplicationStatus.Fail;
            application.StatusMessage = ApplicationStatusMessage.CreditApplicationResultInvalidCreditScore;
            creditApplicationRepository.Save();
            return application;
        }
        foreach(CreditApplication a in application.LinkedCustomer.CreditApplications)
        {
            if (a.PaidBackIn > a.CreatedDate.AddMonths(60))
            {
                application.Status = CreditApplicationStatus.Fail;
                application.StatusMessage = ApplicationStatusMessage.CreditApplicationResultInvalidBadReputation;
                creditApplicationRepository.Save();
                return application;
            }
        }
        creditApplicationRepository.Save();
        return application;
    }
}
