using GreenDonut.Data;
using HotChocolate.Types.Pagination;
using HotChocolateIssueReproduction.Data;

namespace HotChocolateIssueReproduction.Types;

[QueryType]
public static partial class Query
{
    [UseConnection(IncludeTotalCount = true)]
    public static async Task<PageConnection<SpeakerDto>> GetSpeakersAsync(
        PagingArguments pagingArguments,
        QueryContext<SpeakerDto> queryContext,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        var page = await dbContext.Speakers
            .MapToDto()
            .With(queryContext, sort => sort.AddAscending(e => e.Id))
            .ToPageAsync(pagingArguments, cancellationToken);

        return new PageConnection<SpeakerDto>(page);
    }
    
    [UsePaging]
    public static async Task<Connection<SpeakerDto>> GetSpeakers2Async(
        PagingArguments pagingArguments,
        QueryContext<SpeakerDto> queryContext,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        var page = await dbContext.Speakers
            .MapToDto()
            .With(queryContext, sort => sort.AddAscending(e => e.Id))
            .ToPageAsync(pagingArguments, cancellationToken);

        return page.ToConnection();
    }
}