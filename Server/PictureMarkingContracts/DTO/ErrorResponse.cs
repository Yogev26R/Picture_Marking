using Contracts.DTO;

namespace PictureMarkingContracts.DTO
{
    public class ErrorResponse : Response
    {
        public string Message { get; }

        public ErrorResponse(string msg)
        {
            Message = msg;
        }
    }
}
