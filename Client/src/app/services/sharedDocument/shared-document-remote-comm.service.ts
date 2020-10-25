import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateSharedDocumentRequest } from 'src/app/DTO/sharedDocument/createSharedDocument/create-shared-document-request';
import { CreateSharedDocumentResponse } from 'src/app/DTO/sharedDocument/createSharedDocument/create-shared-document-response';
import { ReadAllSharedDocumentsRequest } from 'src/app/DTO/sharedDocument/readAllDocuments/read-all-shared-documents-request';
import { ReadAllSharedDocumentsResponse } from 'src/app/DTO/sharedDocument/readAllDocuments/read-all-shared-documents-response';
import { SessionService } from '../session.service';
import { SharedDocumentCommService } from './shared-document-comm.service';

@Injectable({
  providedIn: 'root'
})
export class SharedDocumentRemoteCommService implements SharedDocumentCommService {

  constructor(
    private httpClient: HttpClient,
    private sessionService: SessionService) { }

  createSharedDocument(createSharedDocumentRequest: CreateSharedDocumentRequest): Observable<CreateSharedDocumentResponse> {
    console.log(createSharedDocumentRequest);

    return this.httpClient.post<CreateSharedDocumentResponse>('api/createshareddocument', createSharedDocumentRequest);
  }


  readAllSharedDocuments(readAllSharedDocumentsRequest: ReadAllSharedDocumentsRequest): Observable<ReadAllSharedDocumentsResponse> {
    readAllSharedDocumentsRequest.userID = this.sessionService.getUserID();
    return this.httpClient.post<ReadAllSharedDocumentsResponse>('api/readshareddocuments', readAllSharedDocumentsRequest);
  }
}
