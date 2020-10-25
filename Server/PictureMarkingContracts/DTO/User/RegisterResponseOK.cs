using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.User
{
    public class RegisterResponseOK : RegisterResponse
    {
        public RegisterResponseOK(RegisterRequest request): base(request) { }  
    }
}
