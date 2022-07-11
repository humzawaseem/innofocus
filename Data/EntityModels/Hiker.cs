

using Shared;

namespace Data.EntityModels
{
    public class Hiker 
    {
        public Hiker()
        {
            InventoryItems = new List<InventoryItem>();
        }

        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsInjured { get; set; }
        public int InjuryReportedCount { get; set; }

        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
    
}
