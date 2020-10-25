namespace Contracts.DTO
{
    public class Response
    {
        public string ResponseType { get; }

        public Response()
        {
            ResponseType = this.GetType().Name;
        }
    }
}
