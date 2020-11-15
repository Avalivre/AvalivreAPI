using System;
using System.Collections.Generic;
using System.Text;

namespace Avalivre.Infrastructure.DTO.UserAuth
{
    public class RegisterUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
