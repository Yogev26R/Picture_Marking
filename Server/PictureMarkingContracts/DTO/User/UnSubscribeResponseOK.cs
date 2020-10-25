using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.User
{
    public class UnSubscribeResponseOK : UnSubscribeResponse
    {
        public UnSubscribeResponseOK(UnSubscribeRequest request): base(request) { }
    }
}
