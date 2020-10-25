namespace PictureMarkingContracts.DTO.Document
{
    public class ReadDocumentsRequest
    {
        public string userID { get; set; }
        public DocumentDTO[] documents { get; set; }
    }
}
