using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Marker
{
    public class MarkerDTO
    {
        public string DocumentID { get; set; }
        public string MarkerID { get; set; }
        public string MarkerType { get; set; }
        public string MarkerLocation { get; set; }
        public string MarkerColor { get; set; }
        public string UserID { get; set; }
    }
}
