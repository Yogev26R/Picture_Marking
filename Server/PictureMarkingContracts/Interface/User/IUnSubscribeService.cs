﻿using Contracts.DTO;
using PictureMarkingContracts.DTO.User;

namespace PictureMarkingContracts.Interface
{
    public interface IUnSubscribeService
    {
        Response UnSubscribe(UnSubscribeRequest request);
    }
}
