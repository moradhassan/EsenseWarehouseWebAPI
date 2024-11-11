using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseWebAPI.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public Warehouse? warehouse { get; set; }
       
        [ForeignKey(nameof(warehouse))]
        public int? WarehouseId { get; set; }
    }
}
