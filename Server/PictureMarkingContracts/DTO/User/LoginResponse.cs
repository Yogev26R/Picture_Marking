using Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.User
{
    public class LoginResponse : Response
    {
        public LoginRequest Request { get; }

        public LoginResponse(LoginRequest request)
        {
            Request = request;
        }
    }
}
