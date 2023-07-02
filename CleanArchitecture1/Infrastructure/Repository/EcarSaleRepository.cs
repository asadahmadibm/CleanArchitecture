using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Common.Models.AgGrid;
using Application.Dto;
using Azure.Core;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EcarSaleRepository : GenericRepository<Ecarsale>, IEcarsaleRepository
    {
        private ApplicationDbContext _context;
        public EcarSaleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ResultMessage> GetProfiles(ServerRowsRequest request)
        {
            ResultMessage resultMessage = new ResultMessage();
            try
            {
                //var query = _Bizcontext.CBI_Exchanges.AsQueryable();
                //var query = _Bizcontext.CBI_SANASarafi.Join(_Bizcontext.CBI_Exchanges,
                //                                            pk=>pk.ID,fk=>fk.SarafiId,
                //                                            (pk,fk)=> new
                //                                            {
                //                                                SANASarafi = pk,
                //                                                Exchanges = fk
                //                                            }).AsQueryable();
                var query = _context.Ecarsales.AsQueryable();
                #region Make ReportInfo
                var res = query
                .Select(j => new EcarsaleDTO
                {
                    address = j.address,
                    citybirth = j.birthcity,
                    birthdate = j.birthdate,
                    ostanbirth = j.birthostan,

                    citysodoor = j.citysodoor,
                    citysokoonat = j.citysokoonat,
                    family = j.family,
                    fathername = j.fathername,
                    id = j.id,
                    khiyaban = j.khiyaban,
                    kooche = j.kooche,
                    mantaghecode = j.mantaghecode,
                    mellicode = j.mellicode,
                    mobile = j.mobile,
                    name = j.name,
                    ostansodoor = j.ostansodoor,
                    ostansokoonat = j.ostansokoonat,
                    pelak = j.pelak,
                    posticode = j.posticode,
                    sex = j.sex,
                    shenasnameno = j.shenasnameno,
                    sodoordate = j.sodoordate,
                    tel = j.tel




                });
                #endregion



                resultMessage = QueryHelper.GridFilterQuery(res, request.filterModels);
                if (resultMessage.errors.Count > 0)
                {
                    return resultMessage;

                }
                res = (IQueryable<EcarsaleDTO>)resultMessage.data;

                resultMessage = QueryHelper.GridSortQuery(res, request.sortModels);
                if (resultMessage.errors.Count > 0)
                {
                    return resultMessage;
                }

                res = (IOrderedQueryable<EcarsaleDTO>)resultMessage.data;

                int TotalCount = res.Count();
                int skip = (request.PageIndex - 1) * request.PageSize;

                res = res.Skip(skip).Take(request.PageSize);
                var res1 = await res.ToListAsync();

                ServerRowsResponse serverRowsResponse = new ServerRowsResponse
                {
                    totalCount = TotalCount,
                    list = res1
                };

                resultMessage.data = serverRowsResponse;
                return resultMessage;
            }
            catch (Exception ex)
            {
                resultMessage.errors.Add(new ErrorDTO() { code = "4000", Desc = ex.GetBaseException().Message });
            }

            return resultMessage;
        }
    }
}
