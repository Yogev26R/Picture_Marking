using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.User
{
    public class UnSubscribeResponseInvalidEmailAddress : UnSubscribeResponse
    {
        public UnSubscribeResponseInvalidEmailAddress(UnSubscribeRequest request) : base(request) { }
    }
}
