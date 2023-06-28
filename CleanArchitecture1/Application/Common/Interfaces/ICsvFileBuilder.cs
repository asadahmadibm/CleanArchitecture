using Application.Dto;
using Application.TodoLists.Queries.ExportTodos;

namespace Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    byte[] BuildDistrictsFile(IEnumerable<DistrictDto> cities);
}
