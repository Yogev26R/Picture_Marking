using Contracts;
using PictureMarkingContracts.Interface;
using System;

namespace DrawingService
{
    [Register(Policy.Transient, typeof(ISocketService))]
    public class DrawingServiceImpl
    {
        ICreateMarkerService _createMarkerService;
    }
}
