using System;
using System.Collections.Generic;
using System.Text;

namespace PictureMarkingContracts.DTO.Marker
{
    public class ReadMarkersRequest
    {
        public string DocumentID { get; set; }
        public MarkerDTO[] Markers { get; set; }
    }
}
