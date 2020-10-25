import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ReadAllSharedDocumentsRequest } from 'src/app/DTO/sharedDocument/readAllDocuments/read-all-shared-documents-request';
import { ReadAllSharedDocumentsResponse } from 'src/app/DTO/sharedDocument/readAllDocuments/read-all-shared-documents-response';
import { SubscribeService } from '../subscribe.service';
import { SharedDocumentCommService } from './shared-document-comm.service';

@Injectable({
  providedIn: 'root'
})
export class ReadSharedDocumentService extends SubscribeService {
  responseSubjects = {
    ReadSharedDocumentsResponseOK: new Subject<ReadAllSharedDocumentsResponse>(),
    ReadSharedDocumentsResponseInvalidUserID: new Subject<ReadAllSharedDocumentsResponse>(),
  };

  constructor(private sharedDocumentCommService: SharedDocumentCommService) {
    super();
  }

  readAllSharedDocuments() {
    const request = new ReadAllSharedDocumentsRequest(null, null);
    this.subscribe(
      this.sharedDocumentCommService.readAllSharedDocuments(request), this.responseSubjects);
  }


  onReadAllSharedDocumentsResponseOK() {
    return this.responseSubjects.ReadSharedDocumentsResponseOK;
  }
}
