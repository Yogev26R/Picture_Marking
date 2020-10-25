using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.User
{
    public class UnSubscribeDTO
    {
        public LoginDTO Login { get; set; }
        public string UserID { get; set; }
    }
}
