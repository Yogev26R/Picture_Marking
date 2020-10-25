using Contracts.DTO;

namespace PictureMarkingContracts.DTO.User
{
    public class RegisterResponse : Response
    {
        public RegisterRequest Request { get; }

        public RegisterResponse(RegisterRequest request)
        {
            Request = request;
        }
    }
}
