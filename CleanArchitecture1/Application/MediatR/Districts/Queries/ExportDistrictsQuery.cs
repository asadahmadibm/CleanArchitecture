
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Security;
using Application.Dto;


namespace Application.Districts.Queries
{
    [Authorize(Roles = "Administrator")]
    public class ExportDistrictsQuery : IRequest<ExportDto>
    {
        public int CityId { get; set; }
    }

    public class ExportDistrictsQueryHandler : IRequestHandler<ExportDistrictsQuery, ExportDto>
    {
        private readonly IDistrictRepository _Repository;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportDistrictsQueryHandler(IDistrictRepository Repository, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _Repository = Repository;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportDto> Handle(ExportDistrictsQuery request, CancellationToken cancellationToken)
        {
            var result = new ExportDto();

            var records = _mapper.Map<List<DistrictDto>>(_Repository.GetByCityIdAsync(request.CityId));

            result.Content = _fileBuilder.BuildDistrictsFile(records);
            result.ContentType = "text/csv";
            result.FileName = "Districts.csv";

            return await Task.FromResult(result);
        }
    }
}
