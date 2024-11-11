using System.ComponentModel.DataAnnotations;

namespace WarehouseWebAPI.DTOs
{
    public class SignUpDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RoleName { get; set; }

        public int? WarehouseId { get; set; }
    }
}
