import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ReadAllDocumentsRequest } from 'src/app/DTO/document/readAllDocuments/read-all-documents-request';
import { ReadAllDocumentsResponse } from 'src/app/DTO/document/readAllDocuments/read-all-documents-response';
import { ReadDocumentRequest } from 'src/app/DTO/document/readDocument/read-document-request';
import { ReadDocumentResponse } from 'src/app/DTO/document/readDocument/read-document-response';
import { SubscribeService } from '../subscribe.service';
import { DocumentCommService } from './document-comm.service';

@Injectable({
  providedIn: 'root'
})
export class ReadDocumentService extends SubscribeService {
  responseSubjects = {
    ReadDocumentResponseOK: new Subject<ReadDocumentResponse>(),
    ReadDocumentResponseInvalidDocumentID: new Subject<ReadDocumentResponse>(),
    ReadDocumentsResponseOK: new Subject<ReadAllDocumentsResponse>(),
    ReadDocumentsResponseInvalidUserID: new Subject<ReadAllDocumentsResponse>(),
  };

  constructor(private documentCommService: DocumentCommService) {
    super();
  }

  readDocument(documentID: string) {
    const request = new ReadDocumentRequest(documentID, null);
    this.subscribe(
      this.documentCommService.readDocument(request), this.responseSubjects);
  }

  readAllDocuments() {
    const request = new ReadAllDocumentsRequest(null, null);
    this.subscribe(
      this.documentCommService.readAllDocuments(request), this.responseSubjects);
  }

  onReadAllDocumentsResponseOK() {
    return this.responseSubjects.ReadDocumentsResponseOK;
  }
}
