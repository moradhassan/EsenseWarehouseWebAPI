using System.ComponentModel.DataAnnotations;

namespace WarehouseWebAPI.DTOs
{
    public class ApplicationUserDto
    {
        public string? UserName { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public IList<string>? RoleName { get; set; }

        public int? WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
    }
}
