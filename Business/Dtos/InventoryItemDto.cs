using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class InventoryItemDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Points { get; set; }
    }
}
