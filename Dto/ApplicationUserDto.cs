using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Dto
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public List<string> Roles { get; set; }
    }

    public class ApplicationUserRegisterDto
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class ApplicationUserLoginDto
    {
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
