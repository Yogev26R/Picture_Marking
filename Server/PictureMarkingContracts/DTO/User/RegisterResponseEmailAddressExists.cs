using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.User
{
    public class RegisterResponseEmailAddressExists : RegisterResponse
    {
        public RegisterResponseEmailAddressExists(RegisterRequest request) : base(request) { }
    }
}
