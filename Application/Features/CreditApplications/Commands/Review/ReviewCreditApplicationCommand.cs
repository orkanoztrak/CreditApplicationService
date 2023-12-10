using MediatR;

namespace Application.Features.CreditApplications.Commands.Review;

public class ReviewCreditApplicationCommand  :IRequest<ReviewCreditApplicationResponse>
{
    public Guid Id { get; set; }
    public bool Approved { get; set; }
}
