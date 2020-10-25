import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateSharedDocumentRequest } from 'src/app/DTO/sharedDocument/createSharedDocument/create-shared-document-request';
import { CreateSharedDocumentResponse } from 'src/app/DTO/sharedDocument/createSharedDocument/create-shared-document-response';
import { ReadAllSharedDocumentsRequest } from 'src/app/DTO/sharedDocument/readAllDocuments/read-all-shared-documents-request';
import { ReadAllSharedDocumentsResponse } from 'src/app/DTO/sharedDocument/readAllDocuments/read-all-shared-documents-response';

@Injectable({
  providedIn: 'root'
})
export abstract class SharedDocumentCommService {

  constructor() { }

  abstract createSharedDocument(createSharedDocumentRequest: CreateSharedDocumentRequest): Observable<CreateSharedDocumentResponse>;

  abstract readAllSharedDocuments(readAllSharedDocumentsRequest: ReadAllSharedDocumentsRequest): Observable<ReadAllSharedDocumentsResponse>;

}
