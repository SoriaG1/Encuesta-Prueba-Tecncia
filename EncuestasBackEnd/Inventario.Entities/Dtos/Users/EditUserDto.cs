using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Dtos.Users
{
    public class EditUserDto
    {
        [Required]
        [StringLength(256)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256)]
        public string LastName { get; set; }
        public string Username { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
