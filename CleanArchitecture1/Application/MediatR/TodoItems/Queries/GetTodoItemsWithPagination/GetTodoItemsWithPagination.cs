using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Dto;
using System.Collections.Generic;

namespace Application.TodoItems.Queries.GetTodoItemsWithPagination;

public record GetTodoItemsWithPaginationQuery : IRequestWrapper<PaginatedList<TodoItemBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTodoItemsWithPaginationQueryHandler : IRequestHandlerWrapper<GetTodoItemsWithPaginationQuery, PaginatedList<TodoItemBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<PaginatedList<TodoItemBriefDto>>> Handle(GetTodoItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var list = await _context.TodoItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        return list.Items.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<PaginatedList<TodoItemBriefDto>>(ServiceError.NotFound);
    }
}
