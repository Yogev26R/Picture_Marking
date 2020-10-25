import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ReadAllMarkersRequest } from 'src/app/DTO/marker/read-all-markers-request';
import { ReadAllMarkersResponse } from 'src/app/DTO/marker/read-all-markers-response';

@Injectable({
  providedIn: 'root'
})
export abstract class MarkerCommService {

  constructor(private httpClient: HttpClient) { }

  readAllMarkers(readAllMarkersRequest: ReadAllMarkersRequest): Observable<ReadAllMarkersResponse> {
    return this.httpClient.post<ReadAllMarkersResponse>('api/readmarkers', readAllMarkersRequest);
  }
}
