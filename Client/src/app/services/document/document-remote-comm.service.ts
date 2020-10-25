import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateDocumentRequest } from 'src/app/DTO/document/createDocument/create-document-request';
import { CreateDocumentResponse } from 'src/app/DTO/document/createDocument/create-document-response';
import { DeleteDocumentRequest } from 'src/app/DTO/document/deleteDocument/delete-document-request';
import { DeleteDocumentResponse } from 'src/app/DTO/document/deleteDocument/delete-document-response';
import { ReadAllDocumentsRequest } from 'src/app/DTO/document/readAllDocuments/read-all-documents-request';
import { ReadAllDocumentsResponse } from 'src/app/DTO/document/readAllDocuments/read-all-documents-response';
import { ReadDocumentRequest } from 'src/app/DTO/document/readDocument/read-document-request';
import { ReadDocumentResponse } from 'src/app/DTO/document/readDocument/read-document-response';
import { UpdateDocumentRequest } from 'src/app/DTO/document/updateDocument/update-document-request';
import { UpdateDocumentResponse } from 'src/app/DTO/document/updateDocument/update-document-response';
import { SessionService } from '../session.service';
import { DocumentCommService } from './document-comm.service';

@Injectable({
  providedIn: 'root'
})
export class DocumentRemoteCommService implements DocumentCommService {

  constructor(
    private httpClient: HttpClient,
    private sessionService: SessionService) { }

  createDocument(createDocumentRequest: CreateDocumentRequest): Observable<CreateDocumentResponse> {
    createDocumentRequest.document.ownerID = this.sessionService.getUserID();
    console.log(createDocumentRequest.document.ownerID);
    console.log(this.sessionService.getUserID());
    return this.httpClient.post<CreateDocumentResponse>('api/createdocument', createDocumentRequest);
  }

  readDocument(readDocumentRequest: ReadDocumentRequest): Observable<ReadDocumentResponse> {
    return this.httpClient.post<ReadDocumentResponse>('api/readdocument', readDocumentRequest);
  }

  readAllDocuments(readAllDocumentsRequest: ReadAllDocumentsRequest): Observable<ReadAllDocumentsResponse> {
    readAllDocumentsRequest.userID = this.sessionService.getUserID();
    return this.httpClient.post<ReadAllDocumentsResponse>('api/readdocuments', readAllDocumentsRequest);
  }

  updateDocument(updateDocumentRequest: UpdateDocumentRequest): Observable<UpdateDocumentResponse> {
    return this.httpClient.post<UpdateDocumentResponse>('api/updatedocument', updateDocumentRequest);
  }

  deleteDocument(deleteDocumentRequest: DeleteDocumentRequest): Observable<DeleteDocumentResponse> {
    console.log(deleteDocumentRequest.document);
    return this.httpClient.post<DeleteDocumentResponse>('api/deletedocument', deleteDocumentRequest);
  }
}
