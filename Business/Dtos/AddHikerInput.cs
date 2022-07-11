using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Business.Dtos
{
    public class AddHikerInput
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [MinLength(1)]
        public List<InventoryItemDto> Items { get; set; }
    }
}
