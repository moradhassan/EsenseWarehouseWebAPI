using System.ComponentModel.DataAnnotations;

namespace WarehouseWebAPI.DTOs
{
    public class SignInDTO
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
