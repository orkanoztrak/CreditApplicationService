namespace Domain.Core;

public enum ApplicationStatusMessage
{
    CreditApplicationResultValid = 0,
    CreditApplicationResultPending = 1,
    CreditApplicationResultInvalidCreditScore = 2,
    CreditApplicationResultInvalidDebtToSalaryRatio = 3,
    CreditApplicationResultInvalidInstallmentCount = 4,
    CreditApplicationResultInvalidAmount = 5,
    CreditApplicationResultInvalidBadReputation = 6,
    CreditApplicationResultManuallyRejected = 7
}
