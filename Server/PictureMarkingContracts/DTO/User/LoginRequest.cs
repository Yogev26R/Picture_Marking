using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.User
{
    public class LoginRequest
    {
        public LoginDTO Login { get; set; }
        public string UserID { get; set; }
    }
}
