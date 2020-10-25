import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { CreateSharedDocumentRequest } from 'src/app/DTO/sharedDocument/createSharedDocument/create-shared-document-request';
import { CreateSharedDocumentResponse } from 'src/app/DTO/sharedDocument/createSharedDocument/create-shared-document-response';
import { SharedDocumentDTO } from 'src/app/DTO/sharedDocument/shared-document-dto';
import { DocumentCommService } from '../document/document-comm.service';
import { SubscribeService } from '../subscribe.service';
import { SharedDocumentCommService } from './shared-document-comm.service';

@Injectable({
  providedIn: 'root'
})
export class CreateSharedDocumentService extends SubscribeService {
  responseSubjects = {
    CreateSharedDocumentResponseOK: new Subject<CreateSharedDocumentResponse>(),
    CreateSharedDocumentResponseInvalidUserName: new Subject<CreateSharedDocumentResponse>()
  };

  constructor(private sharedDocumentService: SharedDocumentCommService) {
    super();
  }

  createSharedDocument(userName: string, documentID: string) {
    const sharedDocument = new SharedDocumentDTO(userName, documentID);
    const request = new CreateSharedDocumentRequest(sharedDocument);
    this.subscribe(
      this.sharedDocumentService.createSharedDocument(request), this.responseSubjects);
  }

  onShareDocumentOK() {
    return this.responseSubjects.CreateSharedDocumentResponseOK;
  }

  onInvalidUserName() {
    return this.responseSubjects.CreateSharedDocumentResponseInvalidUserName;
  }
}
