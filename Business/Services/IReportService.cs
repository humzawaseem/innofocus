using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;

namespace Business.Services
{
    public interface IReportService
    {
        Task<double> PercentageReportInjuredHikers();
        Task<double> PercentageReportNonInjuredHikers();
        Task<List<ItemReportDto>> ItemsOwnedByHikers();
        Task<int> ItemPointsLostByInjuredHikers();
    }
}
