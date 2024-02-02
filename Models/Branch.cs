// Branch.cs
namespace BlazorTestApp.Models
{
    public class Branch
    {
        public int B_Id { get; set; }
        public string B_Name { get; set; }
        public int B_Active { get; set; }
        public string B_Code { get; set; }

        // Navigation properties
        public ICollection<UserModel> Users { get; set; }
        public ICollection<Warehouse> Warehouses { get; set; }
    }
}
