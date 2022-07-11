using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;
using Data;
using Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Business.Services
{
    public class HikerService : IHikerService
    {
        private readonly InnofocusContext _context;
        public HikerService(InnofocusContext context)
        {
            _context = context;
        }


        public async Task<Hiker> AddHiker(AddHikerInput input)
        {
            var hiker = new Hiker
            {
                Age = input.Age,
                Name = input.Name,
                Gender = input.Gender,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                InventoryItems = input.Items.Select(z => new InventoryItem
                {
                    Name = z.Name,
                    Quantity = z.Quantity,
                    Points = z.Points
                }).ToList()
                
            };

        
            await _context.Hikers.AddAsync(hiker);
            await _context.SaveChangesAsync();
            return hiker;

        }

        public async Task<Hiker> UpdateHikerLocation(UpdateHikerLocationInput input)
        {
            var hiker = await _context.Hikers.FirstOrDefaultAsync(h => h.Id == input.Id);
            hiker.Latitude = input.Latitude;
            hiker.Longitude = input.Longitude;
            await _context.SaveChangesAsync();
            return hiker;
        }

        public async Task<Hiker> MarkHikerInjured(int id)
        {
            var hiker = await _context.Hikers.FirstOrDefaultAsync(h => h.Id == id);
            if (hiker != null)
            {
                hiker.InjuryReportedCount += 1;
                if (hiker.InjuryReportedCount >= 3)
                {
                    hiker.IsInjured = true;
                }

                await _context.SaveChangesAsync();
                return hiker;
            }

            return null;


        }

        public async Task<Hiker> TradeItems(TradeItemsInput input)
        {
            var hiker = await _context.Hikers.Include(z => z.InventoryItems).FirstOrDefaultAsync(h => h.Id == input.HikerId);

            if (hiker.IsInjured)
                throw new Exception("Hiker is injured and cannot traded or be traded with");

            var otherHiker = await _context.Hikers.Include(z => z.InventoryItems).FirstOrDefaultAsync(h => h.Id == input.OtherHikerId);
            if (hiker is not null && otherHiker is not null)
            {
                var yourPoints = 0;
                var yourItems = hiker.InventoryItems.Where(z => input.ItemsGiving.Any(x => x.Id == z.Id)).ToList();

                foreach (var item in yourItems)
                {
                    yourPoints = yourPoints + (item.Points * input.ItemsGiving.First(z => z.Id == item.Id).Quantity);

                }


                var hisPoints = 0;
                var hisItems = otherHiker.InventoryItems.Where(z => input.ItemsNeeded.Any(x => x.Id == z.Id)).ToList();

                foreach (var item in hisItems)
                {
                    hisPoints = hisPoints + (item.Points * input.ItemsNeeded.First(z => z.Id == item.Id).Quantity);

                }

                if (yourPoints == hisPoints)
                {
                    

                    hiker.InventoryItems = hisItems;
                    otherHiker.InventoryItems = yourItems;
                   
                }
                else
                {
                    throw new Exception("Points not equal for trading.");
                }

                 _context.Hikers.Update(hiker);
                 _context.Hikers.Update(otherHiker);
                await _context.SaveChangesAsync();
              
            }
            return hiker;
        }
    }
}
