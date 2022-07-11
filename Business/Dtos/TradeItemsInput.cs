using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class TradeItemsInput
    {
        
        public List<TradeItemInput> ItemsGiving { get; set; }
        public List<TradeItemInput> ItemsNeeded { get; set; }

        public int HikerId { get; set; }
        public int OtherHikerId { get; set; }
    }

    public class TradeItemInput
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
