using Contracts;
using Contracts.DTO;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.Marker;
using PictureMarkingContracts.Interface.DAL;
using PictureMarkingContracts.Interface.Marker;
using System;
using System.Collections.Generic;
using System.Data;

namespace ReadMarkerService
{
    [Register(Policy.Transient, typeof(IReadMarkerService))]

    public class ReadMarkerServiceImpl : IReadMarkerService
    {

        IMarkerDAL _dal;

        public ReadMarkerServiceImpl(IMarkerDAL dal)
        {
            _dal = dal;
        }

        public Response ReadMarkers(ReadMarkersRequest request)
        {
            try
            {
                var ds = _dal.ReadMarkers(request.DocumentID);
                var tbl = ds.Tables[0];

                ReadMarkersResponse retval = new ReadMarkersResponseOK(request);
                if (tbl.Rows.Count >= 0)
                {
                    List<MarkerDTO> list = new List<MarkerDTO>();
                    foreach (DataRow row in tbl.Rows)
                    {
                        MarkerDTO marker = new MarkerDTO()
                        {
                            MarkerID = row["MARKER_ID"].ToString(),
                            MarkerType = row["MARKER_TYPE"].ToString(),
                            MarkerLocation = row["MARKER_LOCATION"].ToString(),
                            DocumentID = row["DOCUMENT_ID"].ToString(),
                            MarkerColor = row["MARKER_COLOR"].ToString(),
                            UserID = row["USER_ID"].ToString(),
                        };
                        list.Add(marker);
                    }
                    request.Markers = list.ToArray();
                    retval = new ReadMarkersResponseOK(request);
                }
                return retval;
            }

            catch (Exception ex)
            {
                return new ErrorResponse(ex.Message);
            }
        }
    }
}
