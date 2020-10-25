import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ReadDocumentResponse } from 'src/app/DTO/document/readDocument/read-document-response';
import { ReadDocumentRequest } from 'src/app/DTO/document/readDocument/read-document-request';
import { ReadAllDocumentsResponse } from 'src/app/DTO/document/readAllDocuments/read-all-documents-response';
import { ReadAllDocumentsRequest } from 'src/app/DTO/document/readAllDocuments/read-all-documents-request';
import { CreateDocumentRequest } from 'src/app/DTO/document/createDocument/create-document-request';
import { CreateDocumentResponse } from 'src/app/DTO/document/createDocument/create-document-response';
import { DeleteDocumentRequest } from 'src/app/DTO/document/deleteDocument/delete-document-request';
import { DeleteDocumentResponse } from 'src/app/DTO/document/deleteDocument/delete-document-response';

@Injectable({
  providedIn: 'root'
})
export abstract class DocumentCommService {

  constructor() { }

  abstract readDocument(readDocumentRequest: ReadDocumentRequest): Observable<ReadDocumentResponse>;

  abstract readAllDocuments(readAllDocumentsRequest: ReadAllDocumentsRequest): Observable<ReadAllDocumentsResponse>;

  abstract createDocument(createDocumentRequest: CreateDocumentRequest): Observable<CreateDocumentResponse>;

  abstract deleteDocument(deleteDocumentRequest: DeleteDocumentRequest): Observable<DeleteDocumentResponse>;
}
