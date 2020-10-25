using Contracts.DTO;
using PictureMarkingContracts.DTO.User;

namespace PictureMarkingContracts.Interface
{
    public interface ILoginService
    {
        Response Login(LoginRequest request);
    }
}
