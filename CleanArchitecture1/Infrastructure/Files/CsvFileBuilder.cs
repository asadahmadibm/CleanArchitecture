using System.Globalization;
using Application.Common.Interfaces;
using Application.TodoLists.Queries.ExportTodos;
using Infrastructure.Files.Maps;
using CsvHelper;
using Application.Dto;
using System.Text;

namespace Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
    public byte[] BuildDistrictsFile(IEnumerable<DistrictDto> cities)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<DistrictMap>();
            csvWriter.WriteRecords(cities);
        }

        return memoryStream.ToArray();
    }
}
