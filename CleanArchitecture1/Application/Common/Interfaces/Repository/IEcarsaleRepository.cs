using Application.Common.Models;
using Application.Common.Models.AgGrid;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IEcarsaleRepository :IGenericRepository<Ecarsale>
    {
        //Task<List<Ecarsale>> GetAllEcarsalesAsync();
        Task<ResultMessage> GetProfiles(ServerRowsRequest request);
    }
}
