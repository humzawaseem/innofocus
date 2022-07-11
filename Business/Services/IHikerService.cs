using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;
using Data.EntityModels;

namespace Business.Services
{
    public interface IHikerService
    {
        
        Task<Hiker> AddHiker(AddHikerInput input);
        Task<Hiker> UpdateHikerLocation(UpdateHikerLocationInput input);
        Task<Hiker> MarkHikerInjured(int id);
        //trade items from one hiker to another
        Task<Hiker> TradeItems(TradeItemsInput input);
    }
}
