using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.User
{
    public class LoginResponseInvalidUserName : LoginResponse
    {
        public LoginResponseInvalidUserName(LoginRequest request) : base(request) { }
    }
}
