// Warehouse.cs
namespace BlazorTestApp.Models
{
    public class Warehouse
    {
        public int W_Id { get; set; }
        public string W_Name { get; set; }
        public int W_Active { get; set; }
        public int W_Wms { get; set; }
        public int W_TradingWarehouse { get; set; }
        public int W_BranchId { get; set; }

        // Navigation property
        public Branch Branch { get; set; }
        public ICollection<UserModel> Users { get; set; }
    }
}
