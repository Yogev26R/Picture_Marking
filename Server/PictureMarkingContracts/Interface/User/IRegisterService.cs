using Contracts.DTO;
using PictureMarkingContracts.DTO.User;

namespace PictureMarkingContracts.Interface
{
    public interface IRegisterService
    {
        Response Register(RegisterRequest request);
    }
}
