namespace FarcasterNet.Application.Reviews.Commands.DeleteReview;

using MediatR;

public class DeleteReviewCommand : IRequest<bool>
{
    public Guid Id { get; init; }
}
