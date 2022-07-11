using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class ReportsService: IReportService
    {
        private readonly InnofocusContext _context;
        public ReportsService(InnofocusContext context)
        {
            _context = context;
        }
        

        public async Task<double> PercentageReportInjuredHikers()
        {
            var hikers = _context.Hikers.Count();
            var injured = _context.Hikers.Count(h => h.IsInjured == true);

            return (injured / hikers) * 100;
        }

        public async Task<double> PercentageReportNonInjuredHikers()
        {
            var hikers = _context.Hikers.Count();
            var injured = _context.Hikers.Count(h => h.IsInjured == false);

            return (injured / hikers) * 100;
        }

        public async Task<List<ItemReportDto>> ItemsOwnedByHikers()
        {
            var items = await _context.InventoryItems.Include(z => z.Hiker).Where(z => z.Hiker.IsInjured == false;).GroupBy(i => i.Name).Select(i => new ItemReportDto
            {
                Name = i.Key,
                AverageQuantityPerHiker = i.Average(x => x.Quantity),
            }).ToListAsync();

            return items;
        }

        public async Task<int> ItemPointsLostByInjuredHikers()
        {
            var hikers = await _context.Hikers.Include(z => z.InventoryItems).Where(h => h.IsInjured == true).ToListAsync();
            var totalPoints = 0;
            foreach (var hiker in hikers)
            {
                foreach (var item in hiker.InventoryItems)
                {
                    totalPoints += item.Points;
                }
            }
            return totalPoints;
        }
    }
}
