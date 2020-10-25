import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { DeleteDocumentRequest } from 'src/app/DTO/document/deleteDocument/delete-document-request';
import { DocumentDTO } from 'src/app/DTO/document/document-dto';
import { SubscribeService } from '../subscribe.service';
import { DocumentCommService } from './document-comm.service';

@Injectable({
  providedIn: 'root'
})
export class DeleteDocumentService extends SubscribeService {
  responseSubjects = {
    DeleteDocumentResponseOK: new Subject<any>(),
    DeleteDocumentResponseInvalidDocumentID: new Subject<any>()
  };

  constructor(private documentCommSerice: DocumentCommService) {
    super();
  }

  deleteDocument(document: DocumentDTO) {
    console.log(document);
    const request = new DeleteDocumentRequest(document);
    this.subscribe(
      this.documentCommSerice.deleteDocument(request), this.responseSubjects);
  }

  onDeleteDocumentResponseOK() {
    return this.responseSubjects.DeleteDocumentResponseOK;
  }

  onDeleteDocumentResponseInvalidDocumentID() {
    return this.responseSubjects.DeleteDocumentResponseInvalidDocumentID;
  }
}
