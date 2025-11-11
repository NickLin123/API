using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API1.DTO.DataModel
{
    public class User
    {
        [Key]
        public string Uid { get; set; }
        public string? Name { get; set; }

        public string? Account { get; set; }

        public string? Password { get; set; }

        public bool Banned { get; set; } = false;
    }
}