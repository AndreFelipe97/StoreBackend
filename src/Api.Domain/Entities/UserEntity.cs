using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public enum Role
    {
        Admin,
        Manager,
        Employee
    }
    public class UserEntity : PersonEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }
    }
}
