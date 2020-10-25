using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.User
{
    public class RegisterResponseUserNameExists : RegisterResponse
    {
        public RegisterResponseUserNameExists(RegisterRequest request) : base(request) { }
    }
}
