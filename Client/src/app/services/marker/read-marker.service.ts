import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ReadAllMarkersRequest } from 'src/app/DTO/marker/read-all-markers-request';
import { ReadAllMarkersResponse } from 'src/app/DTO/marker/read-all-markers-response';
import { SubscribeService } from '../subscribe.service';
import { MarkerCommService } from './marker-comm.service';

@Injectable({
  providedIn: 'root'
})
export class ReadMarkerService extends SubscribeService {
  responseSubjects = {
    ReadMarkersResponseOK: new Subject<ReadAllMarkersResponse>(),
    ReadMarkersResponseInvalidUserID: new Subject<ReadAllMarkersResponse>(),
  };
  constructor(private markerCommService: MarkerCommService) {
    super();
  }

  readAllMarkers(documentID: string) {
    const request = new ReadAllMarkersRequest(documentID, null);
    this.subscribe(
      this.markerCommService.readAllMarkers(request), this.responseSubjects);
  }

  onReadMarkersResponseOK() {
    return this.responseSubjects.ReadMarkersResponseOK;
  }
}
