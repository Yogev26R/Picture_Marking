using Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.User
{
    public class UnSubscribeResponse : Response
    {
        public UnSubscribeResponse(UnSubscribeRequest request)
        {
            Request = request;
        }
        public UnSubscribeRequest Request { get; }
    }
}
