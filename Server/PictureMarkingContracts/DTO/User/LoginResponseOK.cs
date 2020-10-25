using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.User
{
    public class LoginResponseOK : LoginResponse
    {
        public LoginResponseOK(LoginRequest request) : base(request) { }
    }
}
