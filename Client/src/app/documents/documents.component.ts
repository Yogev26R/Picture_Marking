import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DocumentDTO } from '../DTO/document/document-dto';
import { ReadDocumentService } from '../services/document/read-document.service';
import { ReadSharedDocumentService } from '../services/sharedDocument/read-shared-document.service';

@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html',
  styleUrls: ['./documents.component.css']
})
export class DocumentsComponent implements OnInit {
  docs: Array<DocumentDTO> = new Array<DocumentDTO>();
  sharedDocs: Array<DocumentDTO> = new Array<DocumentDTO>();
  constructor(
    private readDocumentService: ReadDocumentService,
    private readSharedDocumentService: ReadSharedDocumentService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.readDocumentService.onReadAllDocumentsResponseOK().subscribe(
      response => this.docs = response.request.documents
    );

    this.readSharedDocumentService.onReadAllSharedDocumentsResponseOK().subscribe(
      response => this.sharedDocs = response.request.documents
    );

    this.readDocumentService.readAllDocuments();
    this.readSharedDocumentService.readAllSharedDocuments();
  }

  createDocument() {
    this.router.navigate(['createdocument']);
  }

  onDeleteDocument() {
    this.readDocumentService.readAllDocuments();
  }
}
