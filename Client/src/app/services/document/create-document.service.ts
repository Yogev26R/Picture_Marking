import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { CreateDocumentRequest } from 'src/app/DTO/document/createDocument/create-document-request';
import { CreateDocumentResponse } from 'src/app/DTO/document/createDocument/create-document-response';
import { DocumentDTO } from 'src/app/DTO/document/document-dto';
import { SubscribeService } from '../subscribe.service';
import { DocumentCommService } from './document-comm.service';

@Injectable({
  providedIn: 'root'
})
export class CreateDocumentService extends SubscribeService {
  responseSubjects = {
    CreateDocumentResponseOK: new Subject<CreateDocumentResponse>(),
    CreateDocumentResponseDocumentNameExists: new Subject<CreateDocumentResponse>()
  };

  constructor(private documentService: DocumentCommService) {
    super();
  }

  create(createDocumentFormValue: any) {
    const request = new CreateDocumentRequest(this.DocumentFormToRequest(createDocumentFormValue));
    this.subscribe(
      this.documentService.createDocument(request), this.responseSubjects);
  }

  DocumentFormToRequest(createDocumentFormValue): DocumentDTO {
    return new DocumentDTO(
      null,
      createDocumentFormValue.imageURL.value,
      createDocumentFormValue.documentName.value,
      null);
  }

  onCreateDocumentResponseOK() {
    return this.responseSubjects.CreateDocumentResponseOK;
  }

  onCreateDocumentResponseDocumentNameExists() {
    return this.responseSubjects.CreateDocumentResponseDocumentNameExists;
  }
}
