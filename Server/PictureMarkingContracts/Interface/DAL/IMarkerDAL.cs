using PictureMarkingContracts.DTO.Marker;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PictureMarkingContracts.Interface.DAL
{
    public interface IMarkerDAL
    {
        public DataSet CreateMarker(MarkerDTO marker);

        public DataSet ReadMarkers(string documentID);
    }
}
