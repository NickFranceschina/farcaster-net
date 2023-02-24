namespace FarcasterNet.Application.Casts.Queries;

using AutoMapper;
using Entities;
using FarcasterNet.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class GetDefaultRecommendedCastsQuery : IRequest<List<Cast>>
{
    public int Limit { get; init; } = 20;
    public string Cursor { get; init; }
    public string Auth { get; init; }
}


public class GetDefaultRecommendedCastsQueryHandler : IRequestHandler<GetDefaultRecommendedCastsQuery, List<Cast>>
{
    private readonly ICasts repository;
    private readonly IMapper mapper;

    public GetDefaultRecommendedCastsQueryHandler(ICasts repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<List<Cast>> Handle(GetDefaultRecommendedCastsQuery request, CancellationToken cancellationToken)
    {
        var casts = await this.repository.GetDefaultRecommendedFeed(request.Limit, request.Cursor, request.Auth, cancellationToken);
        var ecasts = this.mapper.Map<List<Cast>>(casts);
        return ecasts;
    }
}
