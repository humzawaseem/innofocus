using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.EntityModels
{
    public class InventoryItem
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Points { get; set; }

        [JsonIgnore]
        public virtual Hiker Hiker { get; set; }
    }
}
