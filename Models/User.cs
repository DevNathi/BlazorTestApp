// User.cs
namespace BlazorTestApp.Models
{
    public class UserModel
    {
        public int U_Id { get; set; }
        public string U_Firstname { get; set; }
        public string U_Lastname { get; set; }
        public string U_Email { get; set; }
        public int U_BranchId { get; set; }
        public int U_WarehouseId { get; set; }
        public int U_Active { get; set; }

        // Navigation properties
        public Branch Branch { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
