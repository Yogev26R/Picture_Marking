import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DocumentDTO } from '../DTO/document/document-dto';
import { DeleteDocumentService } from '../services/document/delete-document.service';

@Component({
  selector: 'app-delete-document',
  templateUrl: './delete-document.component.html',
  styleUrls: ['./delete-document.component.css']
})
export class DeleteDocumentComponent implements OnInit {
  @Input() document: DocumentDTO;
  @Output() deleteDocument: EventEmitter<any> = new EventEmitter();
  constructor(private deleteDocumentService: DeleteDocumentService) { }

  ngOnInit(): void {
    this.deleteDocumentService.onDeleteDocumentResponseOK().subscribe(
      response => this.deleteDocument.emit()
    );
  }

  delete() {
    // console.log('component delete');
    this.deleteDocumentService.onDeleteDocumentResponseOK().subscribe(
      response => this.deleteDocument.emit()
    );
    console.log(this.document);
    this.deleteDocumentService.deleteDocument(this.document);
  }
}
